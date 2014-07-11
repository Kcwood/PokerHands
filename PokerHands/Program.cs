using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    class Program
    {
        static void Main(string[] args)
        {
           Hand myCard = new Hand("4D 5D 6D 7D 8D");
           myCard.pokerHand();
           Console.ReadKey();
        }
    }
}
