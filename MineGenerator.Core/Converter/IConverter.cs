using System;
using System.Collections.Generic;
using System.Text;

namespace MineGenerator.Core.Converter
{
    /// <summary>
    /// Represents a block converter
    /// </summary>
    public interface IConverter
    {
        IEnumerable<IBlock> Convert();
    }
}
