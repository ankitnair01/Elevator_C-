using System;

namespace ElevatorControl
{
    public abstract class ElevatorState
    {
        protected Elevator elevator;
        protected ElevatorState(Elevator e) { elevator = e; }
        public abstract void Enter();
        public abstract void MoveTo(int floor);
    }

    public class IdleState : ElevatorState
    {
        public IdleState(Elevator e) : base(e) { }
        public override void Enter() { }
        public override void MoveTo(int floor)
        {
            elevator.SetTarget(floor);
            elevator.ChangeState(new MovingState(elevator));
        }
    }

    public class MovingState : ElevatorState
    {
        public MovingState(Elevator e) : base(e) { }
        public override void Enter() => elevator.StartTimer();
        public override void MoveTo(int floor) => elevator.EnqueueRequest(floor);
    }
}