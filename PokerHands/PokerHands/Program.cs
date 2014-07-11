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

        //set a place to collect the cards that are made
        static List<Card> dealt = new List<Card> { };

        //each of these instantiates a new card object
       static Card randCard = new Card(null, null);
       static Card randCard1 = new Card(null, null);
       static Card randCard2 = new Card(null, null);
       static Card randCard3 = new Card(null, null);
       static Card randCard4 = new Card(null, null);

       

        

        static void Main(string[] args)
        {
          
           RankHand("8H 8D 7S 7H 7D");
          // RankHand(CreateHand());

            Console.ReadKey();
        }

        


        //function for correct input format and using Card.RandCard() for dealing the user a hand if they wish
        //the randomizer is BROKEN!!!! stupid "meets statistically valid standards for being 'random'"...its not random!
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

                    
                                     
                   

                    bool looping = true;

                    
                        while (looping == true)
                        {
                            dealt.Clear();
                            randCard.RandCard();
                            dealt.Add(randCard);



                            randCard1.RandCard();
                            dealt.Add(randCard1);



                            randCard2.RandCard();
                            dealt.Add(randCard2);


                            randCard3.RandCard();
                            dealt.Add(randCard3);


                            randCard4.RandCard();
                            dealt.Add(randCard4);

                           // if (dealt.Any((x => (x.Equals(x)))) == true)
                                if(dealt.Select(x => x).Distinct().Count() == 5)
                                {
                                    looping = false;
                                }                           
                    }


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
            List<string> cardList = hand.Split(' ').ToList();
            string stringNum = string.Empty;
            string stringSuit = string.Empty;
            string stringFace = string.Empty;
            hand.ToUpper();



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

                    //these are all doing the same for each of the 2 properties of each of the 5 cards: set values to a Card object; 
                    //thus they are all inside the second for loop
                    if (i == 0)
                    {
                        if (stringNum.Length > 0)
                        {
                            randCard.Rank += stringNum;

                        }
                        else if (stringFace.Length > 0)
                        {
                            randCard.Rank = stringFace;
                        }
                        randCard.Suit = stringSuit;
                    }

                    if (i == 1)
                    {
                        if (stringNum.Length > 0)
                        {
                            randCard1.Rank = stringNum;

                        }
                        else if (stringFace.Length > 0)
                        {
                            randCard1.Rank = stringFace;
                        }
                        randCard1.Suit = stringSuit;
                    }
                    if (i == 2)
                    {
                        if (stringNum.Length > 0)
                        {
                            randCard2.Rank = stringNum;

                        }
                        else if (stringFace.Length > 0)
                        {
                            randCard2.Rank = stringFace;
                        }
                        randCard2.Suit = stringSuit;
                    }
                    if (i == 3)
                    {
                        if (stringNum.Length > 0)
                        {
                            randCard3.Rank = stringNum;

                        }
                        else if (stringFace.Length > 0)
                        {
                            randCard3.Rank = stringFace;
                        }
                        randCard3.Suit = stringSuit;
                    }
                    if (i == 4)
                    {
                        if (stringNum.Length > 0)
                        {
                            randCard4.Rank = stringNum;

                        }
                        else if (stringFace.Length > 0)
                        {
                            randCard4.Rank = stringFace;
                        }
                        randCard4.Suit = stringSuit;
                    }

                    //please reset the looping variables!
                    stringNum = string.Empty;
                    stringFace = string.Empty;
                    stringSuit = string.Empty;
                }
            }

            //after each card is created from the string 'hand' then add each card to a list
            dealt.Add(randCard);
            dealt.Add(randCard1);
            dealt.Add(randCard2);
            dealt.Add(randCard3);
            dealt.Add(randCard4);

            //instantiate a new hand and put in the list of cards
            Hand Hand = new Hand(dealt);
            

            //now a heirarchy of conditions must be created to differentiate the actual rank of the hand using the object "Hand"'s properties

            //there needs to be all of these differentiated:

            //*High Card: Highest value card.
            //*One Pair: Two cards of the same value.
            //*Two Pairs: Two different pairs.
            //*Three of a Kind: Three cards of the same value.
            //*Straight: All cards are consecutive values.
            //*Flush: All cards of the same suit.
            //*Full House: Three of a kind and a pair.
            //*Four of a Kind: Four cards of the same value.
            //*Straight Flush: All cards are consecutive values of same suit.
            //*Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.

            string rank = string.Empty;
            string value = string.Empty;

            List<string> orderedHand = new List<string> { };
            for (int i = 0; i < Hand.Ranks.Count; i++)
            {


                //this hopefully converts the face cards to a number for my next condition
                if (Hand.Ranks[i] == "J")
                {
                    Hand.Ranks[i] = "11";
                }
                if (Hand.Ranks[i] == "Q")
                {
                    Hand.Ranks[i] = "12";
                }
                if (Hand.Ranks[i] == "K")
                {
                    Hand.Ranks[i] = "13";
                }
                if (Hand.Ranks[i] == "A")
                {
                    Hand.Ranks[i] = "14";
                }

                orderedHand.Add(Hand.Ranks[i]);
            }
            orderedHand.OrderBy(x => x);
            

            //royal condition

            if (string.Join("", orderedHand).Equals("1011121314") == true)
            {
                rank = "Royal";
                //this one clears "royal" out if its true and yet they are not of the same suit
            }
             if (Hand.Suits[0] != Hand.Suits[1] || Hand.Suits[0] != Hand.Suits[2] || Hand.Suits[0] != Hand.Suits[3] || Hand.Suits[0] != Hand.Suits[4])
            {
                rank = string.Empty;
            }

            //consecutive value condition
             if(rank == string.Empty)
             {
                //this manages how many consecutive values there are
                int checker = 0;


                for (int i = 0; i < Hand.Ranks.Count; i++)
                {
                   

                    //this little guy keeps me from going outside of the index's range
                    if (i + 1 == Hand.Ranks.Count && checker == 4)
                    {
                        rank = "Straight " + value;

                    }//this keeps me from going outside of the range and stops this whole thing
                    else if (i + 1 == Hand.Ranks.Count && checker != 4)
                    {
                        break;
                    }   //this one indicates whether we have a consecutive value
                    else if ((int.Parse(orderedHand[i]) + 1) == int.Parse(orderedHand[i + 1]))
                    {
                        checker++;
                        for (int j = 0; j < Hand.Ranks.Count; j++)
                        {


                            //this hopefully converts the face cards to a number for my next condition
                            if (Hand.Ranks[j] == "11")
                            {
                                Hand.Ranks[j] = "Jack";
                            }
                            if (Hand.Ranks[j] == "12")
                            {
                                Hand.Ranks[j] = "Queen";
                            }
                            if (Hand.Ranks[j] == "13")
                            {
                                Hand.Ranks[j] = "King";
                            }
                            if (Hand.Ranks[j] == "14")
                            {
                                Hand.Ranks[j] = "Ace";
                            }
                            value = Hand.Ranks[j];
                        }
                    }

                }
            }


            //same suit condition
            if (Hand.Suits[0] == Hand.Suits[1] && Hand.Suits[0] == Hand.Suits[2] && Hand.Suits[0] == Hand.Suits[3] && Hand.Suits[0] == Hand.Suits[4])
            {
                rank += " Flush";
            }

            //four of a kind condition
            if(rank == string.Empty)
            {
                //this manages how many similar values there are
                int checker = 0;
                
                for (int i = 0; i < orderedHand.Count; i++)
                {
                    //this little guy keeps me from going outside of the index's range
                    if (i + 1 == orderedHand.Count && checker == 3)
                    {
                        rank = "Four of a Kind: " + value;

                    }
                    //this keeps me from going outside of the range and stops this whole thing
                    else if (i + 1 == orderedHand.Count && checker != 3)
                    {
                        break;
                    }   //this one indicates whether we have a similar value
                    else if (int.Parse(orderedHand[i]) == int.Parse(orderedHand[i + 1]))
                    {
                        checker++;
                        value = orderedHand[i] + "'s";
                    }
                    else
                    if(int.Parse(orderedHand[i]) != int.Parse(orderedHand[i + 1]))

                    {
                        checker = 0;
                    }
                }
            }


            //three of a kind condition
            //need to make sure there isn't four of a kind
            if (rank == string.Empty)
            {
                //this manages how many similar values there are
                int checker = 0;
                

                for (int i = 0; i < orderedHand.Count; i++)
                {
                    //this little guy keeps me from going outside of the index's range
                    if (i + 1 == orderedHand.Count && checker == 2)
                    {
                        rank = "Three of a Kind: " + value;

                    }
                    //this keeps me from going outside of the range and stops this whole thing
                    else if (i + 1 == orderedHand.Count && checker != 2)
                    {
                        break;
                    }   //this one indicates whether we have a similar value
                    else if (int.Parse(orderedHand[i]) == int.Parse(orderedHand[i + 1]))
                    {
                        checker++;
                        value = orderedHand[i] + "'s";
                    }
                    else
                    if (int.Parse(orderedHand[i]) != int.Parse(orderedHand[i + 1]))
                    {
                        checker = 0;
                    }
                }
            }

            //two pair condition

            //need to make sure there isn't four of a kind or three of a kind
            if (rank == string.Empty)
            {

                //this manages how many similar values there are
                int checker = 0;
                int checker1 = 0;


                for (int i = 0; i < orderedHand.Count; i++)
                {
                    //this little guy keeps me from going outside of the index's range
                    if (i + 1 == orderedHand.Count && checker1 == 2)
                    {
                        rank = "Two Pair: " + value;

                    }
                    //this keeps me from going outside of the range and stops this whole thing
                    else if (i + 1 == orderedHand.Count && checker1 != 2)
                    {
                        break;
                    }   //this one indicates whether we have a similar value
                    else if (int.Parse(orderedHand[i]) == int.Parse(orderedHand[i + 1]))
                    {
                        checker++;
                        value += orderedHand[i] + "'s ";

                    } if (checker == 2)
                    {
                        checker1++;
                    }

                }
            }

            //one pair condition

            //need to make sure there isn't four of a kind or three of a kind
            if (rank == string.Empty)
            {
                //this manages how many similar values there are
                int checker = 0;



                for (int i = 0; i < orderedHand.Count; i++)
                {
                    //this little guy keeps me from going outside of the index's range
                    if (i + 1 == orderedHand.Count && checker == 1)
                    {
                        rank = "One Pair: " + value;

                    }
                    //this keeps me from going outside of the range and stops this whole thing
                    else if (i + 1 == orderedHand.Count && checker != 1)
                    {
                        break;
                    }   //this one indicates whether we have a similar value
                    else if (int.Parse(orderedHand[i]) == int.Parse(orderedHand[i + 1]))
                    {
                        checker++;
                        value = orderedHand[i] + "'s";


                    }

                }
            }

            //now i need to check for full house using the single pair condition
            if (rank.Contains("Three of a Kind"))
            {
                var groupList = orderedHand.Distinct().OrderBy(x => x).ToList();
                if (groupList.Count() == 2) { rank = "Full House " + groupList[0] + "'s and " + groupList[1] + "'s"; }
                //this manages how many similar values there are
                int checker = 0;

                for (int i = 0; i < orderedHand.Count; i++)
                {
                    //this little guy keeps me from going outside of the index's range
                    if (i + 1 == orderedHand.Count && checker == 1)
                    {
                        rank = "Full House";

                    }
                    //this keeps me from going outside of the range and stops this whole thing
                    else if (i + 1 == orderedHand.Count && checker != 1)
                    {
                        break;
                    }   //this one indicates whether we have a similar value
                    else if (int.Parse(orderedHand[i]) == int.Parse(orderedHand[i + 1]))
                    {
                        checker++;

                    }

                }
            }

            //high card condition
            if (rank == string.Empty)
            {
                rank = "High Card " + orderedHand.Last();
            }



            //print output to the console
            Console.WriteLine("Hand: " + hand);
            Console.WriteLine("Rank: " + rank);
        }
    }
}
