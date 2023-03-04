using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{

    class Testing
    {
        public static void Test() {

            Pack pack = new Pack(); // Pack object is created.


            Pack.ShuffleCardPack(3);
            Console.WriteLine("The unshuffled pack: ");
            Console.WriteLine(" ");     // The unshuffled pack is written to the console.
            foreach (Card card in Pack.pack) { 
                Console.WriteLine(AccessValueAndSuit(card));
            }
            Console.WriteLine(" ");

            Pack.ShuffleCardPack(2);
            Console.WriteLine("The riffle shuffled pack: ");
            Console.WriteLine(" ");
            foreach (Card card in Pack.pack)    // The riffle shuffled pack is written to the console.
            {
                Console.WriteLine(AccessValueAndSuit(card));
            }
            Console.WriteLine(" ");

            Pack.ShuffleCardPack(3);    // A new unshuffle pack is created so that the next shuffle can be performed from the same order of cards.

            Pack.ShuffleCardPack(1);
            Console.WriteLine("The Fisher-Yates shuffled pack: ");
            Console.WriteLine(" ");
            foreach (Card card in Pack.pack)    // The fisher-yates shuffle is written to the console.
            {
                Console.WriteLine(AccessValueAndSuit(card));
            }
            Console.WriteLine(" ");

            // Each shuffle method is called and written to the console so the output can be checked.

            Console.WriteLine("Single dealt card: ");
            Console.WriteLine(" ");
            Card output = Pack.Deal();
            string display = AccessValueAndSuit(output);    // A single card is dealt and written to the console.
            Console.WriteLine(display);
            Console.WriteLine(" ");

            Console.WriteLine("5 cards dealt: ");
            Console.WriteLine(" ");
            List<Card> outputMany = Pack.DealCard(4);
            if (outputMany != null)
            {
                foreach (Card card in outputMany)       // Multiple cards are dealt and written to the console.
                {
                    string manyOutput = AccessValueAndSuit(card);
                    Console.WriteLine(manyOutput);
                }
            }
            Console.WriteLine(" "); // Formatting the output with these statements.
        }
        public static string AccessValueAndSuit(Card displayCard)
        {

            if (displayCard == null)
            {
                Console.WriteLine("No more cards."); // If no card is entered then the function ends.
                return null;
            }

            int cardValue = displayCard.GSValue;
            int cardSuit = displayCard.GSSuit;      // Get the value and suit of a card.

            string Value = " ";
            string Suit = " "; // Initialised for the more readable output.

            if (cardValue > 1 && cardValue < 11)
            {
                Value = Convert.ToString(cardValue); // If the card value is not an Ace, Jack, Queen or King then set the value to the number.
            }
            else
            {
                switch (cardValue)
                {
                    case 1:
                        Value = "Ace";
                        break;
                    case 11:
                        Value = "Jack";
                        break;
                    case 12:                // If the value is any of these then the Value is set to the corresponding word.
                        Value = "Queen";
                        break;
                    case 13:
                        Value = "King";
                        break;
                }
            }

            switch (cardSuit)
            {
                case 0:
                    Suit = " of Hearts";
                    break;
                case 1:
                    Suit = " of Diamonds";
                    break;
                case 2:                     // The suit that is written to the console is readable so each case corresponds to a suit.
                    Suit = " of Clubs";
                    break;
                case 3:
                    Suit = " of Spades";
                    break;
            }

            string yourCard = Value + Suit; // The string yourcard is a combination of "Value of Suit" and is returned so it can be written to the console.
            return yourCard;
        }
    }
}








