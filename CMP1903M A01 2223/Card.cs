using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation

        public int CardValue;
        public int CardSuit;

        public Card(int ValueGiven, int SuitGiven) {

            CardValue = ValueGiven;
            CardSuit = SuitGiven;

            // Card constructor that will make a card with an inputted value of 1 - 13 and suit of 0 - 3.

        }

        public int GSValue {get{return CardValue;} set { CardValue = value;}}
        public int GSSuit {get{return CardSuit;} set {CardSuit = value;}}
    }
}
