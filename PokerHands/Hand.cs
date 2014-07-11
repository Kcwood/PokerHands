using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    class Hand
    {
        //Define properties
        public List<Card> Cards { get; set; } 

        //Define constructors
        // Ex: 3H 4H 5H 3C 7S
        public Hand(string handString)
        {
            //initialize the card list 
            this.Cards = new List<Card>();
            //split the handString into cardStrings
            var tempList = handString.Split(' ').ToList();
            for (int i = 0; i <= 4; i++) 
            {
                //adding new cards to our card list
                this.Cards.Add(new Card(tempList[i]));
            }

        }
        // new function goes here 
        public bool IsFlush()
        {
            //how to select just one property of an object 
            // and get only unique (distinct) values

            //selects only the suits of our cards, takes only the 
            // distinct values, and counts them. If there is only one
            // suit, it must be a flush.
            return this.Cards.Select(x => x.Suit).Distinct().Count() == 1;
           
        }

        public bool HasPair()
        {
            // selects only the values of the cards, takes only 
            // distinct values, and counts them. If there are only 
            // 4 values, two of them must be the same. 
            return this.Cards.Select(x => x.Rank).Distinct().Count() == 4;
        }

        public bool TwoPair()
        {
            //Select only the values of the cards, takes only
            // distinct values, and counts them. If there are only
            // 3 values, there must be two pairs.
            return this.Cards.Select(x => x.Rank).Distinct().Count() == 3;
        }

        public bool FullHouse()
        {
            //If within the cards dealt there is three 
            // of a kind and a pair, then it will be recognized 
            // as a full house. 
            if (ThreeOfaKind() && HasPair())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Straight()
        {
            //Selects the rank and puts them in order regardless 
            // of suit. If the dealt hand are in order consecutively
            // then it will be recognized as a straight.
            string temp = string.Join("", this.Cards.OrderBy(x => x.Rank).Select(x => x.Rank));
            string temp1 = "234567891011121314";
            return temp1.Contains(temp);
        }

        public bool ThreeOfaKind()
        {
            //Grouping the same ranked cards together from the dealt hand
            var tmp = this.Cards.GroupBy(x => x.Rank);
            //If the first of the ranked cards has three in it, then it
            // will be returned as being a three of a kind. 
            return tmp.Where(x => x.Count() == 3).Any();
        }

        public bool StraightFlush()
        {
            //If both IsFlush and Straight are both true, then 
            // the dealt hand will be recognized as a straight flush.
            if (IsFlush() && Straight())
            {
                return true;
                
            }
            else
            {
                return false;
            }
             
        }
       
        public bool FourOfaKind()
        {
            //Select only the values of the cards, takes only
            // distinct values, and counts them. If there are only
            // 2 values, there must be 4 of the same rank.
            return this.Cards.Select(x => x.Rank).Distinct().Count() == 2;
        }

        public bool RoyalFlush()
        {
            //Selects the rank and puts them in order
            // regardless of suit. 
            string temp = string.Join("", this.Cards.OrderBy(x => x.Rank).Select(x => x.Rank));
            string temp1 = "1011121314";
            //If both IsFlush and the temp1 string are both true, 
            // then the dealt hand will be recognized 
            // as a royal flush.
            if (IsFlush() && temp.Contains(temp1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HighCard()
        {
            //If the hand is none of the about things, then 
            // it has to be high card.
            if (!IsFlush() && !HasPair() && !TwoPair() && !FullHouse() && !Straight() && !StraightFlush() && !ThreeOfaKind() && !FourOfaKind() && !RoyalFlush())
            {
                return true;
            }
            else
            {
                return true;
            }

        }

        public void pokerHand()
        {
            //Creating a function to print to the console if 
            // the hand meets certain requirements. 
            if (RoyalFlush())
            {
                Console.WriteLine("You have a royal flush!");
            }
            else if (FourOfaKind())
            {
                Console.WriteLine("You have four of a kind!");
            }
            else if (FullHouse())
            {
                Console.WriteLine("You have have a full house!");
            }
            else if (ThreeOfaKind())
            {
                Console.WriteLine("You have three of a kind!");
            }
            else if (StraightFlush())
            {
                Console.WriteLine("You have a straight flush!");
            }
            else if (Straight())
            {
                Console.WriteLine("You have a straight!");
            }
            else if (IsFlush())
            {
                Console.WriteLine("You have a flush!");
            }
            else if (TwoPair())
            {
                Console.WriteLine("You have two of a kind!");
            }
            else if (HasPair()) 
            {
                Console.WriteLine("You have a pair!");
            }
            else if (HighCard())
            {
                Console.WriteLine("You don't have much!");
            }
        }

    }
}
