using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    class Program
    {
        static int J = 11;
        static int Q = 12;
        static int K = 13;
        static int A = 14;
        static List<int> N = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A };
        //static List<int> C = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A };
        //static List<int> D = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A };
        //static List<int> S = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A };
        static string suit1 = "H";
        static string suit2 = "C";
        static string suit3 = "D";
        static string suit4 = "S";

        static void Main(string[] args)
        {
          
           RankHand("5H 5C 6S 7S KD");

            Console.ReadKey();
        }

        


        //function for correct input format
        static void RankHand(string hand)
        {
            //receive input from the user
            Console.WriteLine("RANKHAND\n");
            Console.WriteLine("Would you like to be dealt a hand from the deck\nor would you like to set your own?\n\nYes or No");
            string input = Console.ReadLine().ToLower();
            if (input == "y" || input == "yes")
            {
                List<Card> dealt = new List<Card> { };

                Card randCard = new Card(null, null);
                randCard.RandCard();
                dealt.Add(randCard);

                Card randCard1 = new Card(null, null);
                randCard1.RandCard();
                dealt.Add(randCard1);

                Card randCard2 = new Card(null, null);
                randCard2.RandCard();
                dealt.Add(randCard2);

                Card randCard3 = new Card(null, null);
                randCard3.RandCard();
                dealt.Add(randCard3);

                Card randCard4 = new Card(null, null);
                randCard4.RandCard();
                dealt.Add(randCard4);

                Hand Hand = new Hand(dealt);

                hand = Hand.Cards;


            }
            else
            {
                Console.WriteLine("Please put 5 cards under this format:\n\nThe number value of the card, where:\n Jack is J, Queen is Q, King is K, and Ace is A;\n\nfollowed by the associated suit:\n Hearts is H, Daimonds is D, Clubs is C and Spades is S.\n\nPlease no spaces or special characters. Thank you.");










            }
            
            Console.WriteLine("Hand: " + hand);
            Console.WriteLine("Rank: ");
                
        }
    }
}
