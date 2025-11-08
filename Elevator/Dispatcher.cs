using System.Collections.Generic;

namespace ElevatorControl
{
    public class Dispatcher
    {
        private readonly List<Elevator> elevators = new();

        public void Register(Elevator e)
        {
            if (!elevators.Contains(e)) elevators.Add(e);
        }

        public Elevator AssignElevator(int requestedFloor)
        {
            Elevator best = elevators[0];
            int bestEta = best.EstimateResponseTime(requestedFloor);
            foreach (var e in elevators)
            {
                int eta = e.EstimateResponseTime(requestedFloor);
                if (eta < bestEta) { best = e; bestEta = eta; }
            }
            return best;
        }
    }
}