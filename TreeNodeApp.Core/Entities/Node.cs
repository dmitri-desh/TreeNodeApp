namespace TreeNodeApp.Core.Entities
{
    public class Node
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public int TreeId { get; set; }

        public Node Parent { get; set; }
        public Tree Tree { get; set; }
        public ICollection<Node> Children { get; set; } = new List<Node>();
    }
}
