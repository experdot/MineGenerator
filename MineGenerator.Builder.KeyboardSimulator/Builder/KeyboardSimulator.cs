using MineGenerator.Core;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MineGenerator.Builder
{
    public class KeyboardSimulator : IBuilder
    {
        public void Build(IEnumerable<IRegion> regions)
        {
            System.Threading.Thread.Sleep(8000);// Delay 3000ms
            foreach (var item in regions)
            {
                BuildSingleBlock(item);
            }
        }

        public void BuildSingleBlock(IRegion region)
        {
            var command = GenerateCommand(region);
            VirtualKeyboard.SendKey(VirtualKeys.VK_T);
            System.Threading.Thread.Sleep(200);
            VirtualKeyboard.SendKey(VirtualKeys.VK_RETURN);
            System.Threading.Thread.Sleep(200);
            Clipboard.SetText(command);
            VirtualKeyboard.SendCouple(VirtualKeys.VK_CONTROL, VirtualKeys.VK_V);
            System.Threading.Thread.Sleep(100);
            VirtualKeyboard.SendKey(VirtualKeys.VK_RETURN);
            System.Threading.Thread.Sleep(100);
        }

        public string GenerateCommand(IRegion region)
        {
            var sx = Math.Round(region.Start.X);
            var sy = Math.Round(region.Start.Y);
            var sz = Math.Round(region.Start.Z);
            var ex = Math.Round(region.End.X);
            var ey = Math.Round(region.End.Y);
            var ez = Math.Round(region.End.Z);

            return $"/fill ~{sx} ~{sy} ~{sz} ~{ex} ~{ey} ~{ez} concrete";
        }
    }
}
