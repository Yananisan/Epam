using System;

namespace Roullete
{
    class Player
    {
        private string Name;
        private int Number;

        public Player(string name)
        {
            this.Name = name ?? throw new ArgumentNullException();
        }

        public void Check(Roullete roullete)
        {
            if (roullete == null)
            {
                throw new ArgumentNullException();
            }
        }
        public void OnOdd(Roullete roullete)
        {
            Check(roullete);
            roullete.OddNumber += ShowMessage;
            roullete.EvenNumber -= ShowMessage;
        }

        public void OnEven(Roullete roullete)
        {
            Check(roullete);
            roullete.EvenNumber += ShowMessage;
            roullete.OddNumber -= ShowMessage;
        }

        public void OnRed(Roullete roullete)
        {
            Check(roullete);
            roullete.RedNumber += ShowMessage;
            roullete.BlackNumber -= ShowMessage;
        }

        public void OnBlack(Roullete roullete)
        {
            Check(roullete);
            roullete.BlackNumber += ShowMessage;
            roullete.RedNumber -= ShowMessage;
        }

        public void Winner(Roullete roullete, int value)
        {
            Check(roullete);

            if (value < 0 || value > 36) throw new ArgumentException();

            this.Number = value;
            roullete.Event += ShowMessageOnNumber;
        }

        public void ShowMessage(object sender, EventArgs e)
        {
            Console.WriteLine("You won:" + Name);
        }

        public void ShowMessageOnNumber(object sender, RoulleteEventArgs e)
        {
            if (Number == e.Number)
            {
                Console.WriteLine("You won:" + Name);
            }
        }
    }
}
