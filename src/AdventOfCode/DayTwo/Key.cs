using AdventOfCode.Utils;

namespace AdventOfCode.DayTwo
{
    public enum Key
    {
        One = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine
    }

    public static class KeyUtils
    {
        public static Key Move(Key key, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return MoveUp(key);
                case Direction.Down:
                    return MoveDown(key);
                case Direction.Left:
                    return MoveLeft(key);
                case Direction.Right:
                    return MoveRight(key);
                default:
                    return key;
            }
        }

        private static Key MoveUp(Key key)
        {
            switch (key)
            {
                case Key.One:
                    return Key.One;
                case Key.Two:
                    return Key.Two;
                case Key.Three:
                    return Key.Three;
                case Key.Four:
                    return Key.One;
                case Key.Five:
                    return Key.Two;
                case Key.Six:
                    return Key.Three;
                case Key.Seven:
                    return Key.Four;
                case Key.Eight:
                    return Key.Five;
                case Key.Nine:
                    return Key.Six;
                default:
                    return key;
            }
        }

        private static Key MoveDown(Key key)
        {
            switch (key)
            {
                case Key.One:
                    return Key.Four;
                case Key.Two:
                    return Key.Five;
                case Key.Three:
                    return Key.Six;
                case Key.Four:
                    return Key.Seven;
                case Key.Five:
                    return Key.Eight;
                case Key.Six:
                    return Key.Nine;
                case Key.Seven:
                    return Key.Seven;
                case Key.Eight:
                    return Key.Eight;
                case Key.Nine:
                    return Key.Nine;
                default:
                    return key;
            }
        }

        private static Key MoveLeft(Key key)
        {
            switch (key)
            {
                case Key.One:
                    return Key.One;
                case Key.Two:
                    return Key.One;
                case Key.Three:
                    return Key.Two;
                case Key.Four:
                    return Key.Four;
                case Key.Five:
                    return Key.Four;
                case Key.Six:
                    return Key.Five;
                case Key.Seven:
                    return Key.Seven;
                case Key.Eight:
                    return Key.Seven;
                case Key.Nine:
                    return Key.Eight;
                default:
                    return key;
            }
        }

        private static Key MoveRight(Key key)
        {
            switch (key)
            {
                case Key.One:
                    return Key.Two;
                case Key.Two:
                    return Key.Three;
                case Key.Three:
                    return Key.Three;
                case Key.Four:
                    return Key.Five;
                case Key.Five:
                    return Key.Six;
                case Key.Six:
                    return Key.Six;
                case Key.Seven:
                    return Key.Eight;
                case Key.Eight:
                    return Key.Nine;
                case Key.Nine:
                    return Key.Nine;
                default:
                    return key;
            }
        }
    }
}
