using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBasicCS
{
    abstract class GameObject
    {
        // state
        protected string _name;
        protected int _hp;

        // property
        public string name
        {
            get { return _name; }
        }
        public int hp
        {
            get { return _hp; }
            set { _hp = value; }
        }


        public GameObject(string name, int hp)
        {
            _name = name;
            _hp = hp;
        }

        public abstract void Die();
        public virtual void Attack()
        {
            Console.WriteLine($"{_name}: 공격 발생함");
        }
    }

    sealed class Player : GameObject
    {
        public Player(string name, int hp) : base(name, hp)
        {
        }

        public override void Die()
        {
        }
    }

    class Monster : GameObject
    {
        public Monster(string name, int hp) : base(name, hp)
        {
        }

        public override void Die()
        {
        }
    }
}
