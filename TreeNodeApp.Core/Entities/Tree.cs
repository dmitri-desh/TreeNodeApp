using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeNodeApp.Core.Entities
{
    public class Tree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Node> Nodes { get; set; }
    }
}
