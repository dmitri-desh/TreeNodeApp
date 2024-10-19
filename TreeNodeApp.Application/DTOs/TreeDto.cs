using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeNodeApp.Application.DTOs
{
    public class TreeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<NodeDto> Nodes { get; set; }
    }
}
