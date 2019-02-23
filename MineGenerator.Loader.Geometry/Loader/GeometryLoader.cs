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
            return GenerateRectangle();
        }

        private IEnumerable<IRegion> GenerateCircle()
        {
            var radius = 50;
            var regions = new List<IRegion>();
            var line = new Vector2(0, radius);
            var circumference = Math.Ceiling(radius * 2 * Math.PI);

            for (int i = 0; i < circumference; i += 5)
            {
                var rotation = (float)(Math.PI * 2 * i / circumference);
                var current = Vector2.Transform(line, Matrix3x2.CreateRotation(rotation));
                regions.Add(new Region(new Vector3(current.X, current.Y, 10)));
            }
            return regions;
        }

        private IEnumerable<IRegion> GenerateRectangle()
        {
            var regions = new List<IRegion>();
            var random = new Random();

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    var offsetX = random.Next(5);
                    var offsetY = random.Next(5);
                    regions.Add(new Region(new Vector3(i * 5 + offsetX, -1, j * 5 + offsetY)));
                }
            }

            return regions;
        }
    }
}
