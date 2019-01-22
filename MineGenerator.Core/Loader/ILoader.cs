using System;
using System.Collections.Generic;
using System.Text;

namespace MineGenerator.Core.Loader
{
    /// <summary>
    /// Represents a block loader.
    /// </summary>
    interface ILoader
    {
        IEnumerable<IBlock> Load();
    }
}
