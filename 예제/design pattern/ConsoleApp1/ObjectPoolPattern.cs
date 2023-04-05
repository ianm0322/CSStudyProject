using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ObjectPoolPattern
    {
    }

    public interface IPoolingObject
    {
        void Reset();
    }

    public class MonsterManager : Singleton<MonsterManager>
    {
        public Queue<Monster> objectPool;
        public List<Monster> enableObjectList;

        #region Override Method
        protected override void Init()
        {
            objectPool = new Queue<Monster>();
            AddCapacity(100);
        }

        private void AddCapacity(int capacity)
        {
            for (int i = 0; i < capacity; i++)
            {
                var obj = new Monster();
                objectPool.Enqueue(obj);
            }
        }

        protected override void Release()
        {
            while(objectPool.Count > 0)
            {
                objectPool.Dequeue();
                // 
            }
        }
        #endregion

        public Monster GetObject()
        {
            if(objectPool.Count == 0)
            {
                AddCapacity(100);
            }
            var obj = objectPool.Dequeue();
            if (obj != null)
            {
                obj.Reset();
                enableObjectList.Add(obj);
                return obj;
            }
            else
            {
                throw new Exception("몬스터 Die에서 객체 삭제 발생 의심됨. 확인해볼 것.");
            }
        }

        public void RegistPool(Monster obj)
        {
            if(obj.IsActive == false)
            {
                obj.Disable();
            }
            objectPool.Enqueue(obj);
        }

        [Obsolete]
        public void ReleaseObject(Monster obj)
        {
            enableObjectList.Remove(obj);
            objectPool.Enqueue(obj);
        }
    }

    public class Monster
    {
        private string name;
        private int hp;
        private int atk;
        private bool isActive;

        public bool IsActive => isActive;

        public Monster(bool isActive = false)
        {
            if (isActive)
            {
                Reset();
            }
        }

        public void Reset()
        {
            name = "몬스터";
            hp = 100;
            atk = 10;
        }

        public void Disable()
        {

        }

        public void Die()
        {
            Console.WriteLine("몬스터 사망함.");
            Disable();
            Singleton<MonsterManager>.Instance.RegistPool(this);
        }
    }
}
