using System.Text.Json;
using System.Text.Json.Serialization;
using RBTree;

var tree = new RedBlackTree<int>();

for (int i = 0; i < 100000; i++)
{
    tree.Insert(i);
}

using (var fs = new FileStream("tree.json", FileMode.Create))
{
    JsonSerializer.Serialize(fs, tree);
}

for (int i = 1000; i < 20000; i+=100)
{
    var node = tree.Find(i);
    tree.Remove(node);
}
Console.WriteLine(tree.Verify());