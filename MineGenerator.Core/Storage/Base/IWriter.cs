using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MineGenerator.Core.Storage
{
    public interface IWriter
    {
        void Write(Stream stream, Package package);
    }
}
