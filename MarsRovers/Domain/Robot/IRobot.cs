using MarsRovers.Domain.Enums;
using System.Collections.Generic;

namespace MarsRovers.Domain.Robot
{
    public interface IRobot
    {
        void ProcessData(List<Direction> directions);
        void Left();
        void Right();
        void Move();
    }
}
