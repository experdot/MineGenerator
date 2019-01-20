using System.Numerics;

namespace MineGenerator.Core
{
    public interface IBlock
    {
        Vector3 Location { get; set; }
        BlockType Type { get; set; }
    }
}