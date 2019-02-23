using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MineGenerator.Core
{
    public class Region : IRegion
    {
        public Vector3 Start { get; set; }
        public Vector3 End { get; set; }
        public BlockType Type { get; set; }

        public Region(Vector3 start)
        {
            Start = start;
            End = start;
        }

        public Region(Vector3 start, Vector3  end)
        {
            Start = start;
            End = end;
        }
    }
}
