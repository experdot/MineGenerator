using System;
using System.Collections.Generic;
using System.Text;

namespace MineGenerator.Core
{
    /// <summary>
    /// Represents a blocks builder
    /// </summary>
    public interface IBuilder
    {
        void Build(IEnumerable<IBlock> blocks);
    }
}
