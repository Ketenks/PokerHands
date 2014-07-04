using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    class Program
    {
        //static int J = 11;
        //static int Q = 12;
        //static int K = 13;
        //static int A = 14;
        //static List<int> N = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A };
        //static List<int> C = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A };
        //static List<int> D = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A };
        //static List<int> S = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, J, Q, K, A };
        //static string suit1 = "H";
        //static string suit2 = "C";
        //static string suit3 = "D";
        //static string suit4 = "S";

        static void Main(string[] args)
        {
          
           RankHand(CreateHand());

            Console.ReadKey();
        }

        


        //function for correct input format and the rank
        static string CreateHand()
        {
            //receive input from the user
            Console.WriteLine("RANKHAND\n");
            Console.WriteLine("Would you like to be dealt a hand from the deck\nOr would you like to set your own?\n\nYes or No");          
            string input = Console.ReadLine().ToLower();
            Console.WriteLine();

            //here is the hand
            string hand = string.Empty;

            //these manage how many times the user can put in incorrect format before the computer deals them a hand
            int autoDealN = 1;
            bool autoDeal = false;

            //this loop will run again if the user exceeds the amount of times they can make a mistake on format
            //where after that, autoDeal will have been set to true
            while(autoDealN == 1)
            {               
                if (input == "y" || input == "yes" || autoDeal == true)
                {
                    // no need to do autodeal when it is autodealing
                    autoDealN++;

                    //set a place to collect the cards that are made
                    List<Card> dealt = new List<Card> { };

                    //each of these instantiates a new card object
                    //sets the properties of the card randomly
                    //adds the card into a list
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

                    //instantiate a new hand and put in the list of cards
                    Hand Hand = new Hand(dealt);

                    //set the parameter of the function equal to the list of cards as a string for final output
                    hand = Hand.Cards;
             
            }  
                else //if the user chose to set their own hand then do this
                {
                    //tell the user the correct format
                    Console.WriteLine("Please put 5 cards under this format:\n\nThe number value of the card, where:\n Jack is J, Queen is Q, King is K, and Ace is A;\n\nfollowed by the associated suit:\n Hearts is H, Daimonds is D, Clubs is C and Spades is S.\n\nPut only a space between each card; no special characters. Thank you.");

                    //these manage how many times the user can make a mistake in their format
                    int checker = 0;
                    int checker1 = 0;

                    //the loop to let the user try again
                    while (checker == 0)
                    {
                        hand = input = Console.ReadLine().ToUpper();
                        Console.WriteLine();

                        //these manage the correct format
                        List<string> cardList = hand.Split(' ').ToList();
                        string stringNum = string.Empty;
                        string stringSuit = string.Empty;
                        string stringFace = string.Empty;
                        int correct = 0;

                     //condition for correct format of each card
                    //this looks through the list to find each card
                    for (int i = 0; i < cardList.Count; i++)
                    {
                        //this looks through each card to find the correct format
                        for (int j = 0; j < cardList[i].Length; j++)
                        {
                            //a data type process
                            if ("0123456789".Contains(cardList[i][j]))
                            {
                                stringNum += cardList[i][j];

                            }
                            else if ("JQKA".Contains(cardList[i][j]))
                            {
                                stringFace += cardList[i][j];
                            }
                            else
                            {
                                stringSuit += cardList[i][j];
                            }
                        }
                        //this is the ultimate condition for format: it needs to fulfill all these things after having been processed for "data type" by the for loop above
                        if ("HCSD".Contains(stringSuit) && stringSuit.Length == 1  && stringNum.Length <= 2 && stringFace.Length <= 1)
                        {
                            //its the correct format so lets try to get 5 of these
                            correct++;

                            //took me forever to realize that i had to reset the values each time ---- WAY TO GO DEBUGGER!!! YEAH
                            stringNum = string.Empty;
                            stringFace = string.Empty;
                            stringSuit = string.Empty;

                        }
                    }
                        //if all 5 cards were correct then do this
                    if (correct == 5)
                    {
                        //its the correct format so stop the loops and let's get going
                        checker++;
                        autoDealN++;
                                
                    }      
       
                        else //if its not the correct format then do this
                        {
                            //keep track of how many incorrects they have made
                            checker1++;
                            
                            //condition to set the autoDeal to true and deal for them a hand because clearly they are incapable after 2 tries
                            if (checker1 == 2)
                            {
                                Console.WriteLine("Your hand will be dealt for you.");
                                autoDeal = true;
                                break;
                            }
                            //ask them nicely to do it right if they have another try
                            Console.WriteLine("Please set the cards you want following the correct format.\n");                           
                        }
                    }
                }
         }//this bracket is the first while loop
            return hand;   
        }

        //begin function to determine the rank of the hand
        static void RankHand(string hand)
        {
            





            //print output to the console
            Console.WriteLine("Hand: " + hand);
            Console.WriteLine("Rank: ");
        }
    }
}
