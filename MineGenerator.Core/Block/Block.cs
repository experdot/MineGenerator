using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MineGenerator.Core
{
    /// <summary>
    /// Represents a block.
    /// </summary>
    public class Block : IBlock
    {
        public Block(Vector3 location)
        {
            Location = location;
        }

        public Block(Vector3 location, BlockType type)
        {
            Location = location;
            Type = type;
        }

        /// <summary>
        /// Gets or sets the <see cref="BlockType"/> of block.
        /// </summary>
        public BlockType Type { get; set; }
        /// <summary>
        /// Gets or sets the location of block.
        /// </summary>
        public Vector3 Location { get; set; }
    }
}
