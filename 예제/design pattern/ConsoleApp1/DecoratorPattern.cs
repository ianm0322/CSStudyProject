using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DecoratorPattern
    {
    }
    
    public abstract class Shape
    {
        public abstract void Draw(string a);
        public Point point;
    }

    public abstract class ShapeDecorator : Shape
    {
        protected Shape component;
        public ShapeDecorator(Shape shape)
        {
            component = shape;
        }
    }

    public class FillShapeDecorator : ShapeDecorator
    {
        public FillShapeDecorator(Shape shape) : base(shape)
        {

        }

        public override void Draw(string a)
        {
            component.Draw(a);
        }

        public void ExtendedFillMethod()
        {
            Console.WriteLine("도형 채움.");
        }
    }
}
