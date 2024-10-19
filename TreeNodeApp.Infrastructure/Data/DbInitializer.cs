using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeNodeApp.Core.Entities;

namespace TreeNodeApp.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context)
        {
            await context.Database.MigrateAsync();

            if (await context.Trees.AnyAsync()) return;

            var rootTree = new Tree
            {
                Name = "Root Tree",
                Nodes = new List<Node>()
            };

            var rootNode = new Node
            {
                Name = "Root Node",
                Tree = rootTree,
                Children = new List<Node>()
            };

            rootTree.Nodes.Add(rootNode);

            context.Trees.Add(rootTree);

            await context.SaveChangesAsync();
        }
    }
}
