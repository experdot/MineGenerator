using System;
using System.Collections.Generic;
using System.Text;

namespace MineGenerator.Core.Storage
{
    public class Package
    {
        public Guid Id { get; set; }
        public IEnumerable<IBlock> Blocks { get; set; }
        public Dictionary<string, object> ExtendProperties { get; set; }
    }
}
