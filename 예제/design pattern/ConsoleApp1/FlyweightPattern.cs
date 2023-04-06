using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// * 객체들간의 공통된 데이터를 공유하여 RAM에 더 많은 객체를 포함할 수 있도록 하는 패턴.
// * 비슷한 데이터는 하나의 객체만 만들고 다른 객체가 이를 참조하는 형태.
// * ≡유니티의 프리팹

namespace ConsoleApp1
{
    public class Flyweight
    {
        Data data;
        public Flyweight(Data data)
        {
            this.data = data;
        }
    }

    public class Data
    {

    }
}
