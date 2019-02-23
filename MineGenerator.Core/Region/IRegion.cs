using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MineGenerator.Core
{
    public interface IRegion
    {
        Vector3 Start { get; set; }
        Vector3 End { get; set; }
        BlockType Type { get; set; }
    }
}
