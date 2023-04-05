using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SingletonPattern
    {
        public void Execute()
        {
            Singleton<GameManager>.Instance.GetHello();
        }
    }

    public class Singleton<T> where T : Singleton<T>, new()
    {
        private static T _instance;
        #region [Singleton Part]
        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new T();
                    _instance.Init();
                }
                return _instance;
            }
        }

        protected virtual void Init()
        {

        }
        protected virtual void Release()
        {

        }
        protected virtual void Regist()
        {

        }
        #endregion
    }

    public sealed class GameManager : Singleton<GameManager>
    {
        public string GetHello()
        {
            return "HElloejo world')";
        }
    }
}
