using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MineGenerator.Core.Storage
{
    public interface IReader
    {
        Package Read(Stream stream);
    }
}
