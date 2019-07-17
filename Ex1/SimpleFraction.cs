using System;

namespace Ex1
{
    public struct SimpleFraction : IComparable
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public SimpleFraction(int x, int y)
        {
            X = x;
            Y = y;
            MakeSimple();
        }

        private void MakeSimple()
        {
            var min = Math.Min(X, Y);
            if (Y == 0)
            {
               throw new DivideByZeroException("Знаменатель дроби не должен быть равен нулю");
            }

            if (X < 0 && Y < 0)
            {
                X -= X * 2;
                Y -= Y * 2;
            }

            if (X > 0 && Y < 0)
            {
                X -= X * 2;
                Y -= Y * 2;
            }

            for (int i = min; i > 1; i--)
            {
                if (X % i == 0 && Y % i == 0)
                {
                    X /= i;
                    Y /= i;
                    break;
                }
            }
        }

        public static SimpleFraction operator +(SimpleFraction a, SimpleFraction b)
        {
            var x = a.X * b.Y + b.X * a.Y;
            var y = a.Y * b.Y;
            return new SimpleFraction(x, y);
        }

        public static SimpleFraction operator -(SimpleFraction a, SimpleFraction b)
        {
            var x = a.X * b.Y - b.X * a.Y;
            var y = a.Y * b.Y;
            return new SimpleFraction(x, y);
        }

        public static SimpleFraction operator *(SimpleFraction a, SimpleFraction b)
        {
            var x = a.X * b.X;
            var y = a.Y * b.Y;
            return new SimpleFraction(x, y);
        }

        public static SimpleFraction operator /(SimpleFraction a, SimpleFraction b)
        {
            var x = a.X * b.Y;
            var y = a.Y * b.X;
            return new SimpleFraction(x, y);
        }


        public override string ToString()
        {
            return X == 0 ? $"{X}" : $"{X}/{Y}";
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            try
            {
                var fraction = (SimpleFraction) obj;
                if (X * fraction.Y > fraction.X * Y)
                    return 1;
                if (X * fraction.Y < fraction.X * Y)
                    return -1;

                return 0;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine($"Ошибка приведения типов {ex.Message}");
                throw;
            }
        }
    }
}
