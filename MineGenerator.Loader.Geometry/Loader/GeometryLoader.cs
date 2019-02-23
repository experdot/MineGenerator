using MineGenerator.Core;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MineGenerator.Loader.Geometry
{
    public class GeometryLoader : ILoader
    {
        public IEnumerable<IBlock> Load()
        {
            var radius = 20;
            var blocks = new List<Block>();
            var line = new Vector2(0, radius);
            var circumference = Math.Ceiling(radius * 2 * Math.PI);
            for (int i = 0; i < circumference; i++)
            {
                var rotation = (float)(Math.PI * 2 * i / circumference);
                var current = Vector2.Transform(line, Matrix3x2.CreateRotation(rotation));
                blocks.Add(new Block(new Vector3(current.X, current.Y, 0)));
            }
            return blocks;
        }
    }
}
