using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    


    class Card
    {
        //the properties of a card
        public string Suit { get; set; }
        public string Rank { get; set; }

        //construct the card object
        public Card(string suit, string rank)
        {
            this.Suit = suit; this.Rank = rank;
        }

        //a method to randomly set the suit and rank
        public void RandCard()
        {
            
            System.Threading.Thread.Sleep(40);
            string suit = string.Empty;
            string rank = string.Empty;
            Random rNG = new Random();
            int randNum = rNG.Next(2, 14);
            if (randNum < 15 && randNum > 10)
            {
                if (randNum == 11)
                {
                    rank = "J";
                }
                else if (randNum == 12)
                {
                    rank = "Q";
                }
                else if (randNum == 13)
                {
                    rank = "K";
                }
                else
                {
                    rank = "A";
                }
            }
            else
            {
                rank = randNum.ToString();
            }
            Random rNG2 = new Random();
            int randNum2 = rNG2.Next(1, 5);
            if (randNum2 == 1)
            {
                suit = "H";
            }
            else if (randNum2 == 2)
            {
                suit = "C";
            }
            else if (randNum2 == 3)
            {
                suit = "D";
            }
            else
            {
                suit = "S";
            }
            this.Suit = suit;
            this.Rank = rank;

        }
    }
}
