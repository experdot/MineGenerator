using MineGenerator.Core;
using MineGenerator.Core.Converter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Text;

namespace MineGenerator.Converter.BitmapConverter
{
    public class BitmapConverter : IConverter
    {
        public Bitmap Image { get; set; }

        public BitmapConverter(Bitmap image)
        {
            Image = image;
        }

        public IEnumerable<IBlock> Convert()
        {
            var width = Image.Width;
            var height = Image.Height;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (Image.GetPixel(x, y).A == 0)
                    {
                        yield return new Block(new Vector3(x, y, 0));
                    }
                }
            }
        }
    }
}
