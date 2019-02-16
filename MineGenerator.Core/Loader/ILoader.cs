using System;
using System.Collections.Generic;
using System.Text;

namespace MineGenerator.Core
{
    /// <summary>
    /// Represents a block loader.
    /// </summary>
    public interface ILoader
    {
        IEnumerable<IBlock> Load();
    }
}
