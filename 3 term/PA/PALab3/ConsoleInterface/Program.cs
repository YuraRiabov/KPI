using System.Text.Json;
using System.Text.Json.Serialization;
using RBTree;

var tree = new RedBlackTree<int>();

for (int i = 0; i < 10; i++)
{
    tree.Insert(i);
}

using (var fs = new FileStream("tree.json", FileMode.Create))
{
    JsonSerializer.Serialize(fs, tree);
}

RedBlackTree<int> newTree;
using (var fs = new FileStream("tree.json", FileMode.Open))
{
    newTree = JsonSerializer.Deserialize<RedBlackTree<int>>(fs);
    newTree.RestoreConnections();
    for (int i = 10; i < 20; i++)
    {
        newTree.Insert(i);
    }
}

using (var fs = new FileStream("tree.json", FileMode.Create))
{
    JsonSerializer.Serialize(fs, newTree);
}