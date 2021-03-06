﻿using MineGenerator.Core;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Region = MineGenerator.Core.Region;

namespace MineGenerator.Loader
{
    public class BitmapLoader : ILoader
    {
        public Bitmap Image { get; set; }

        public BitmapLoader(Bitmap image)
        {
            Image = image;
        }

        public IEnumerable<IRegion> Load()
        {
            var width = Image.Width;
            var height = Image.Height;
            if (Image.PixelFormat == PixelFormat.Format32bppArgb)
            {
                var data = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                var regions = new List<Region>();
                if (Vector.IsHardwareAccelerated)
                {
                    HardwareAcceleratedUnsafeConvert(data, regions);
                }
                else
                {
                    PortableUnsafeConvert(data, regions);
                }
                Image.UnlockBits(data);
                return regions;
            }
            else
            {
                // unsafe code cann't use yield directly
                return SlowConvert();
            }
        } // End Sub

        private static unsafe void PortableUnsafeConvert(BitmapData data, List<Region> blocks)
        {
            int height = data.Height;
            int stride = data.Stride;
            int* lineStart = (int*)data.Scan0.ToPointer();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < stride; x++)
                {
                    // Replace regular block selector code here.
                    if (*lineStart++ != 0)
                    {
                        blocks.Add(new Region(new Vector3(x, y, 0)));
                    }
                }
            }
        } // End Sub

        private static unsafe void HardwareAcceleratedUnsafeConvert(BitmapData data, List<Region> regions)
        {
            int height = data.Height;
            int stride = data.Stride;
            byte* lineStart = (byte*)data.Scan0.ToPointer();
            ArrayPool<int> sharedArrayPool = ArrayPool<int>.Shared;
            var vectorData = sharedArrayPool.Rent(Vector<int>.Count);
            int blockX = 0;
            for (int blockY = 0; blockY < height; blockY++)
            {
                byte* endOfLine = lineStart + stride;
                int* curPos = (int*)lineStart;

                // Sse4 / Avx2 / Avx512
                curPos = HardwareAcceleratedLineInputBlocks(regions, vectorData, ref blockX, blockY, endOfLine, curPos);
                // 64-bit
                curPos = Int64LineInputBlocks(regions, ref blockX, blockY, endOfLine, curPos);
                // 32-bit
                curPos = PortableLineInputBlocks(regions, ref blockX, blockY, endOfLine, curPos);

                lineStart = endOfLine;
            }
            sharedArrayPool.Return(vectorData, true);
        } // End Sub

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe int* PortableLineInputBlocks(List<Region> regions, ref int blockX, int blockY, byte* endOfLine, int* curPos)
        {
            while (curPos < endOfLine)
            {
                // Replace regular block selector code here.
                if (*curPos++ != 0)
                {
                    // Slow. converted int to float.
                    // Why should we use Vector3 here?
                    regions.Add(new Region(new Vector3(blockX, blockY, 0)));
                }
                blockX++;
            }
            return curPos;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe int* Int64LineInputBlocks(List<Region> regions, ref int blockX, int blockY, byte* endOfLine, int* curPos)
        {
            while (curPos < endOfLine - sizeof(long))
            {
                // Replace 64-bit optimized block selector code here.
                if (*(long*)curPos != 0)
                {
                    if (curPos[0] != 0)
                    {
                        regions.Add(new Region(new Vector3(blockX, blockY, 0)));
                    }
                    blockX++;
                    if (curPos[1] != 0)
                    {
                        regions.Add(new Region(new Vector3(blockX, blockY, 0)));
                    }
                    blockX++;
                }
                else
                {
                    blockX += 2;
                }
                curPos += 2;
            }
            return curPos;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static unsafe int* HardwareAcceleratedLineInputBlocks(List<Region> regions, int[] vectorData, ref int blockX, int blockY, byte* endOfLine, int* curPos)
        {
            while (curPos < endOfLine - Vector<byte>.Count)
            {
                // .net framework 4.6.1 does not support creating vector from Span.
                // Heap allocated array instead.
                for (int i = 0; i < Vector<int>.Count; i++)
                {
                    vectorData[i] = curPos[i];
                }
                var vec = new Vector<int>(vectorData);
                // Replace vectorized block selector code here.
                var equalsVector = Vector.Equals<int>(vec, Vector<int>.Zero);

                for (int i = 0; i < Vector<int>.Count; i++)
                {
                    if (equalsVector[i] != 0)
                    {
                        regions.Add(new Region(new Vector3(blockX, blockY, 0)));
                    }
                    blockX++;
                }
                curPos += Vector<int>.Count;
            }
            return curPos;
        }

        private IEnumerable<IRegion> SlowConvert()
        {
            var width = Image.Width;
            var height = Image.Height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Replace regular block selector code here.
                    if (Image.GetPixel(x, y).A > 128)
                    {
                        yield return new Region(new Vector3(x, y, 0));
                    }
                }
            }
        } // End Sub

    } // End Class
} // End Namespace
