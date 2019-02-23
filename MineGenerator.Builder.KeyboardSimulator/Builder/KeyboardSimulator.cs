using MineGenerator.Core;
using System;
using System.Collections.Generic;
using System.Windows;

namespace MineGenerator.Builder
{
    public class KeyboardSimulator : IBuilder
    {
        public void Build(IEnumerable<IBlock> blocks)
        {
            System.Threading.Thread.Sleep(8000);// Delay 3000ms
            foreach (var item in blocks)
            {
                BuildSingleBlock(item);
            }
        }

        public void BuildSingleBlock(IBlock block)
        {
            var command = GenerateCommand(block);
            VirtualKeyboard.SendKey(VirtualKeys.VK_T);
            System.Threading.Thread.Sleep(200);
            VirtualKeyboard.SendKey(VirtualKeys.VK_RETURN);
            System.Threading.Thread.Sleep(200);
            Clipboard.SetText(command);
            System.Threading.Thread.Sleep(100);
            VirtualKeyboard.SendCouple(VirtualKeys.VK_CONTROL, VirtualKeys.VK_V);
            System.Threading.Thread.Sleep(100);
            VirtualKeyboard.SendKey(VirtualKeys.VK_RETURN);
            System.Threading.Thread.Sleep(200);
        }

        public string GenerateCommand(IBlock block)
        {
            var x = Math.Round(block.Location.X);
            var y = Math.Round(block.Location.Y);
            var z = Math.Round(block.Location.Z);

            return $"/fill ~{x} ~{y} ~{z} ~{x} ~{y} ~{z + 100} concrete";
        }
    }
}
