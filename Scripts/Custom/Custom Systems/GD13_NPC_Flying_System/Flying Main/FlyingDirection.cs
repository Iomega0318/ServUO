//Simple not using anything

namespace Server.Flying
{
    public static class FlyingDirection
    {
        public static int GetDirection(string direction, out int getY)
        {
            if (direction == "Mask" || direction == "ValueMask")
            {
                getY = -1;
                return -1;
            }
            else if (direction == "Down" || direction == "131")
            {
                getY = 1;
                return 1;
            }
            else if (direction == "Left" || direction == "133")
            {
                getY = 1;
                return -1;
            }
            else if (direction == "Right" || direction == "129")
            {
                getY = -1;
                return 1;
            }
            else if (direction == "North" || direction == "Running")
            {
                getY = -1;
                return 0;
            }
            else if (direction == "South" || direction == "132")
            {
                getY = 1;
                return 0;
            }
            else if (direction == "East" || direction == "130")
            {
                getY = 0;
                return 1;
            }
            else if (direction == "West" || direction == "134")
            {
                getY = 0;
                return -1;
            }
            else
            {
                getY = 0;
                return 0;
            }
        }

        public static Direction ChangeDirection(string direction)
        {
            if (direction == "Mask" || direction == "ValueMask")
            {
                return Direction.Down;
            }
            else if (direction == "Down" || direction == "131")
            {
                return Direction.Mask;
            }
            else if (direction == "Left" || direction == "133")
            {
                return Direction.Right;
            }
            else if (direction == "Right" || direction == "129")
            {
                return Direction.Left;
            }
            else if (direction == "North" || direction == "Running")
            {
                return Direction.South;
            }
            else if (direction == "South" || direction == "132")
            {
                return Direction.North;
            }
            else if (direction == "East" || direction == "130")
            {
                return Direction.West;
            }
            else if (direction == "West" || direction == "134")
            {
                return Direction.East;
            }
            else
            {
                return Direction.Mask;
            }
        }

        public static Direction ChangeAltitudeDown(string direction)
        {
            if (direction == $"{Direction.ValueMask}")
            {
                return Direction.Mask;
            }
            else if (direction == "131")
            {
                return Direction.Down;
            }
            else if (direction == "133")
            {
                return Direction.Left;
            }
            else if (direction == "129")
            {
                return Direction.Right;
            }
            else if (direction == $"{Direction.Running}")
            {
                return Direction.North;
            }
            else if (direction == "132")
            {
                return Direction.South;
            }
            else if (direction == "130")
            {
                return Direction.East;
            }
            else if (direction == "134")
            {
                return Direction.West;
            }
            else
            {
                return Direction.Mask;
            }
        }
    }
}
