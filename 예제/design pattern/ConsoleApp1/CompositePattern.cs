using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CompositePattern
    {
    }

    public abstract class Node
    {
        public string Id { get; protected set; }
        public abstract void Display(); // debugging 용.
    }

    public class File : Node    // 밑의 Leaf단말이 될 객체
    {
        public File(string id)
        {
            this.Id = id;
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }
    }

    public class Directory : Node
    {
        List<Node> children = new List<Node>();     // directory는 fild도 가질 수 있고, directory도 가질 수 있음
        public Dictionary(string id)
        {
            this.Id = id;
        }

        public override void Display()
        {
            throw new NotImplementedException();
        }
    }
}
