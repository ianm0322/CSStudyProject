using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandwishMaker
{
    public class Restorant
    {
        public void Enter()
        {

        }
    }

    class JuiceMachine
    {
        // dictionary<key: 주스 이름, value: 주스 정보> 
        private Dictionary<string, Juice> juiceTable;
        
        public JuiceMachine()
        {
            juiceTable = new Dictionary<string, Juice>()
            {
                {"콜라", new Juice("콜라", "상쾌한 맛", 1500) },
                {"닥터 페퍼", new Juice("닥터 페퍼", "체리 맛", 1800) },
                {"생수", new Juice("생수", "맑고 깨끗한 지하 암반수", 1000) }
            };
        }

        public Juice GetJuice(string juiceName, Wallet wallet)
        {
            // JuiceTable에서 Juice를 꺼낸다.
            Juice output;
            if (juiceTable.ContainsKey(juiceName) == true)
            {
                output = juiceTable[juiceName];
            }
            else
            {
                return default(Juice);
            }

            // wallet에 돈이 충분한지 확인한다.

            // Wallet에서 juice.price만큼의 돈을 제거한다.

            // juice 반환

            return default(Juice);
        }
    }

    class Person
    {
        // 소유물
        private Wallet wallet;
        private Juice juice;

        // 메소드
        public Person(Wallet wallet)
        {
            this.wallet = wallet;
        }

        public void BuyJuice(JuiceMachine target, string juiceName)
        {
            var buyJuice = target.GetJuice(juiceName, wallet);
            // 사려는 주스가 자판기에 없으면 예외 반환.
            if(buyJuice.name == null)
            {
                throw new Exception("없는 음료수.");
            }
            else
            {
                juice = buyJuice;
            }
        }

        public void Drink()
        {
            Console.WriteLine($"{juice.name}의 맛은 {juice.flavor}한 맛!");
        }
    }

    class Wallet
    {
        public Dictionary<int, int> moneyList = new Dictionary<int, int>();

        public Wallet()
        {
            moneyList = new Dictionary<int, int>();
        }
    }

    struct Juice
    {
        public string name;
        public string flavor;
        public int price;

        public Juice(string name, string flavor, int price)
        {
            this.name = name;
            this.flavor = flavor;
            this.price = price;
        }
    }

    public enum eMoneyType
    {
        오천원 = 5000,
        천원 = 1000,
        오백원 = 500,
        백원 = 100,
        END = 0
    }
}