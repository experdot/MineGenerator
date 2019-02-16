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
            System.Threading.Thread.Sleep(3000);// Delay 3000ms
            foreach (var item in blocks)
            {
                BuildSingleBlock(item);
            }
        }

        public void BuildSingleBlock(IBlock block)
        {
            var command = GenerateCommand(block);
            VirtualKeyboard.SendKey(VirtualKeys.VK_T);
            Clipboard.SetText(command);
            VirtualKeyboard.SendCouple(VirtualKeys.VK_CONTROL, VirtualKeys.VK_V);
            VirtualKeyboard.SendKey(VirtualKeys.VK_RETURN);
        }

        public string GenerateCommand(IBlock block)
        {
            var x = block.Location.X;
            var y = block.Location.Y;
            var z = block.Location.Z;

            return $"/fill ~{x} ~{y} ~{z} ~{x} ~{y} ~{z} concrete";
        }
    }
}
