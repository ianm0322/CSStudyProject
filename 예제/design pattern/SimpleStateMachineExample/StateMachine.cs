using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleStateMachineExample
{
    interface IAIState
    {
        public void Behavior();
        public void Interaction();
        public void Detect(int range);
    }

    class Monster
    {
        public IAIState state;          // Monster AI 상태머신

        public int HaxHP = 100;         // 최대체력
        public int HP = 100;            // 현재 체력
        public int PanicHP = 30;        // HP < PanicHP 이면 몬스터가 패닉에 빠짐.
        public int Sight = 10;          // 플레이어를 감지하는 시야 범위
        public int SuspicionRange = 15; // 경계하는 시야 범위
        public int Speed = 1;           // 이동 속도

        public int Pos = 0;
    }

    abstract class StateBase : IAIState     // AI State 기본 클래스
    {
        protected Monster monster;          // State 실행하는 객체

        public StateBase(Monster monster)
        {
            this.monster = monster;
        }

        public abstract void Behavior();        // 주기적으로 작동하는 행동
        public abstract void Interaction();     // 플레이어와 상호작용시 작동하는 행동
        public abstract void Detect(int range); // 주위 상태를 감시하는 행동
                                                // 인자로 플레이어와의 거리를 받음.

        public void Detect(int pos1, int pos2)
        {
            Detect(Math.Abs(pos2 - pos1));
        }
    }

    class PatrolState : StateBase
    {
        private int _lookDir = 1;
        private int _PatrolRange = 10;

        public PatrolState(Monster monster) : base(monster)
        {
        }

        public override void Behavior()
        {
            if(monster.Pos <= -_PatrolRange)            // 왼쪽 끝에 도달했다면 뒤돌기
            {
                _lookDir *= -1;
            }
            else if(monster.Pos >= _PatrolRange)        // 오른쪽 끝에 도달했다면 뒤돌기
            {
                _lookDir *= -1;
            }
            else
            {
                monster.Pos += _lookDir * monster.Speed;
            }
        }

        public override void Interaction()
        {
            Console.WriteLine("나도 한때 모험가였지. 무릎에 화살을 맞지 않았더라면...");
        }

        // 교전 범위 내에 플레이어 존재할 시
            // 체력 > 패닉체력 => 전투 상태
            // 체력 < 패닉체력 => 도망 상태
        // 경계 범위 내에 플레이어 존재할 시 => 경계 상태
        // 아니면 현상태 유지
        public override void Detect(int range)
        {
            if(range <= monster.Sight)
            {
                if(monster.HP < monster.PanicHP)
                {
                    monster.state = new PanicState(monster);
                }
                else
                {
                    monster.state = new CombatState(monster);
                }
            }
            else if(range <= monster.SuspicionRange)
            {
                monster.state = new ObservingState(monster);
            }
        }
    }

    class ObservingState : StateBase
    {
        public const int RELEASE_TIME = 5;

        public int ReleaseTimer = RELEASE_TIME;
        public ObservingState(Monster monster) : base(monster)
        {
        }

        public override void Behavior()
        {
            if(ReleaseTimer < 0)
            {
                monster.state = new PatrolState(monster);
            }
            ReleaseTimer--;
        }

        public override void Interaction()
        {
            Console.WriteLine("거기 누구냐!");
        }

        public override void Detect(int range)
        {
            if (range <= monster.Sight)
            {
                if (monster.HP < monster.PanicHP)
                {
                    monster.state = new PanicState(monster);
                }
                else
                {
                    monster.state = new CombatState(monster);
                }
            }
        }
    }

    class CombatState : StateBase
    {
        public CombatState(Monster monster) : base(monster)
        {
        }

        public override void Behavior()
        {
            Console.WriteLine("적이 공격했다! 하지만 땅을 박차고 회피! 공격은 허무하게 빗나갔다!");
        }

        public override void Interaction()
        {
            Console.WriteLine("말걸지 마람마!");
        }

        public override void Detect(int range)
        {
            if(range > monster.SuspicionRange)
            {
                monster.state = new PatrolState(monster);
            }
            else if(monster.HP < monster.PanicHP)
            {
                monster.state = new PanicState(monster);
            }
        }
    }

    class PanicState : StateBase
    {
        public PanicState(Monster monster) : base(monster)
        {
        }

        public override void Behavior()
        {
            Console.WriteLine("아이에에에에");
            monster.Pos += monster.Speed * 2;
        }

        public override void Interaction()
        {
            Console.WriteLine("아이에에에에");
        }

        public override void Detect(int range)
        {
            throw new NotImplementedException();
        }
    }
}
