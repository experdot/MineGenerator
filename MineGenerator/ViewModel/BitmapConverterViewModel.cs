using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MineGenerator
{
    public class BitmapConverterViewModel
    {
        public Bitmap Image { get; set; }

        public ICommand GenerateCommand { get; set; }

        public BitmapConverterViewModel()
        {
            // TODO
            this.Image = new Bitmap(@"E:\logo.png");
            this.GenerateCommand = new GenerateCommand();
        }
    }
}
