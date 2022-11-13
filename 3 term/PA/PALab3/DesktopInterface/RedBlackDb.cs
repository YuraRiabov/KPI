using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RBTree;

namespace DesktopInterface
{
    public class RedBlackDb
    {
        public int CurrentIndex { get; set; }

        public RedBlackTree<DbEntrance> Tree { get; set; } = new();
    }
}
