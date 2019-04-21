using System;

namespace Roullete
{
    public class Roullete
    {
        public event EventHandler OddNumber;
        public event EventHandler EvenNumber;
        public event EventHandler RedNumber;
        public event EventHandler BlackNumber;
        public event EventHandler<RoulleteEventArgs> Event;

        private enum Color
        {
            Red,
            Black
        }

        public void Spin()
        {
            Random rnd = new Random();
            int result = 9;
            Color color = (Color)rnd.Next(0, 1);

            if (color == Color.Red)
            {
                RedWins();
            }
            else
            {
                BlackWins();
            }

            if (result % 2 == 1)
            {
                OddWins();
            }
            else
            {
                EvenWins();
            }

            Winner(new RoulleteEventArgs(result));
        }

        private void RedWins()
        {
            RedNumber?.Invoke(this, new EventArgs());
        }

        private void BlackWins()
        {
            BlackNumber?.Invoke(this, new EventArgs());
        }

        private void OddWins()
        {
            OddNumber?.Invoke(this, new EventArgs());
        }

        private void EvenWins()
        {
            EvenNumber?.Invoke(this, new EventArgs());
        }

        private void Winner(RoulleteEventArgs e)
        {
            Event?.Invoke(this, e);
        }
    }
}
