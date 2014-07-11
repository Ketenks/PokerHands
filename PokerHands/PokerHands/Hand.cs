using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    class Hand
    {
        //properties of the hand of cards
        public List<Card> Drawn { get; set; }
        public List<string> Suits { get; set; }
        public List<string> Ranks { get; set; }
        public string Cards { get; set; }

        
        public Hand(List<Card> Drawn)
        {
            //set a place for the properties of each card
            List<string> suits = new List<string> { };
            List<string> ranks = new List<string> { };
            string cards = string.Empty;

            //set a limit to the hand size
            while (Drawn.Count > 5)
            {
                Drawn.RemoveAt(5);
            }
            //while (Drawn.Count < 5)
            //{
                
            //    Drawn.Add(new Card(rand
            //}

            //when the handsize is right
            //parse the properties of each card into a list
            if(Drawn.Count == 5)
            {
                //collect all the suits of each card
                suits.Add(Drawn[0].Suit);
                suits.Add(Drawn[1].Suit);
                suits.Add(Drawn[2].Suit);
                suits.Add(Drawn[3].Suit);
                suits.Add(Drawn[4].Suit);

                //collect all the ranks of each card
                ranks.Add(Drawn[0].Rank);
                ranks.Add(Drawn[1].Rank);
                ranks.Add(Drawn[2].Rank);
                ranks.Add(Drawn[3].Rank);
                ranks.Add(Drawn[4].Rank);

                //collect all the properties into a single string
                cards = Drawn[0].Rank.ToString() + Drawn[0].Suit.ToString() + " " + Drawn[1].Rank.ToString() + Drawn[1].Suit.ToString() + " " + Drawn[2].Rank.ToString() + Drawn[2].Suit.ToString() + " " + Drawn[3].Rank.ToString() + Drawn[3].Suit.ToString() + " " + Drawn[4].Rank.ToString() + Drawn[4].Suit.ToString();

                this.Suits = suits; this.Ranks = ranks; this.Cards = cards;

               
            }
            

        }
    }
}
