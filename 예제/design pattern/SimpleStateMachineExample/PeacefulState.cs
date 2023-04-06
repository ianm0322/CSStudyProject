using System;

namespace SimpleStateMachineExample
{
    class PatrolState : StateBase
    {
        public override void Behavior()
        {

        }

        public override void Interaction()
        {
            Console.WriteLine("떼껄룩");
        }

        public override bool Detect(int range)
        {
            if(range < )
        }
    }
}
