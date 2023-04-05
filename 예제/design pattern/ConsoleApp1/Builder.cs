using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BuilderPattern
    {
    }

    class Builder
    {

    }

    public interface IBuilder_Bed
    {
        IBuilder_Bed MakeMattress();
        IBuilder_Bed MakeFrame();
        IBuilder_Bed MakePillow();
        IBuilder_Bed MakeSheet();
        IBuilder_Bed Build();
    }

    public class Product_Bed
    {
        public string Frame { get; set; }
        public string mattress { get; set; }
        public string Pillow { get; set; }
        public string Sheet { get; set; }
    }

    public class ConcreteBuilder_Bed : IBuilder_Bed
    {
        Product_Bed bed = new Product_Bed();

        public Product_Bed Build()
        {
            return bed;
        }

        public IBuilder_Bed MakeFrame()
        {
            throw new NotImplementedException();
        }

        public IBuilder_Bed MakeMattress()
        {
            throw new NotImplementedException();
        }

        public IBuilder_Bed MakePillow()
        {
            throw new NotImplementedException();
        }

        public IBuilder_Bed MakeSheet()
        {
            throw new NotImplementedException();
        }

        IBuilder_Bed IBuilder_Bed.Build()
        {
            throw new NotImplementedException();
        }
    }

    class DirectorClass // 
    {
        public Product_Bed Construct(IBuilder_Bed builder)
        {
            builder.MakeFrame();
            builder.();
            builder.MakeFrame();
        }
    }
}
