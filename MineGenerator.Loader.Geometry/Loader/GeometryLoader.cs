using MineGenerator.Core;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MineGenerator.Loader.Geometry
{
    public class GeometryLoader : ILoader
    {
        public IEnumerable<IRegion> Load()
        {
            var radius = 50;
            var regions = new List<IRegion>();
            var line = new Vector2(0, radius);
            var circumference = Math.Ceiling(radius * 2 * Math.PI);
            for (int i = 0; i < circumference; i += 5)
            {
                var rotation = (float)(Math.PI * 2 * i / circumference);
                var current = Vector2.Transform(line, Matrix3x2.CreateRotation(rotation));
                regions.Add(new Region(new Vector3(current.X, current.Y, 10), new Vector3(0, 0, 10)));
            }
            return regions;
        }
    }
}
