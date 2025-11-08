using System;
using System.Collections.Generic;
using Timer = System.Timers.Timer;
using System.Timers;
namespace ElevatorControl
{
    public class Elevator
    {
        public int Id { get; }
        public int CurrentFloor { get; private set; } = 1;
        private int targetFloor;
        private Queue<int> queue = new();
        private ElevatorState state;
        private Timer timer;

        public event EventHandler<int>? FloorChanged;

        public Elevator(int id)
        {
            Id = id;
            state = new IdleState(this);
            timer = new Timer(1000);
            timer.Elapsed += OnTick;
        }

        public void Request(int floor) => state.MoveTo(floor);
        public void SetTarget(int floor) => targetFloor = floor;
        public void EnqueueRequest(int floor) => queue.Enqueue(floor);
        public void ChangeState(ElevatorState s) { state = s; s.Enter(); }
        public void StartTimer() => timer.Start();

        private void OnTick(object? s, ElapsedEventArgs e)
        {
            if (CurrentFloor < targetFloor) CurrentFloor++;
            else if (CurrentFloor > targetFloor) CurrentFloor--;
            FloorChanged?.Invoke(this, CurrentFloor);

            if (CurrentFloor == targetFloor)
            {
                timer.Stop();
                if (queue.Count > 0) targetFloor = queue.Dequeue();
                else ChangeState(new IdleState(this));
            }
        }

        public int EstimateResponseTime(int floor)
            => Math.Abs(CurrentFloor - floor) + queue.Count;
    }
}