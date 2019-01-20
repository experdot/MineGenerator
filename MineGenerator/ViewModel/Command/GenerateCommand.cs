using MineGenerator.Converter.BitmapConverter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MineGenerator
{
    public class GenerateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var converter = new BitmapConverter(parameter as System.Drawing.Bitmap);
            var blocks = converter.Convert();
            Console.WriteLine(blocks.Count());
        }
    }
}
