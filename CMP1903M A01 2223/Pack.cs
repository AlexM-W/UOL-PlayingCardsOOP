using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        public static List<Card> pack {get; set;} // Static so that there is only one card pack.
        public static int cardCounter = 0; // Initialise card counter to be used in deal methods.

        public Pack()
        {
            //Initialise the card pack here

            List<Card> temp = new List<Card>(); //Temporary list to add the cards to.

            for (int count = 0; count <= 3; count++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    temp.Add(new Card(value, count));
                }
            }

            // Loop that will make 13 cards for each suit and add it to the temporary list.

            pack = temp; // Set the single pack to the same as the temporary list.

        }  

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle

            var shufflePack = Pack.pack;
            Random random = new Random();
            List<int> struckNum = new List<int>();
            List<Card> struckCards = new List<Card>();
            List<int> randomNumList = new List<int>(); 

            switch (typeOfShuffle)
            {
                case 1:

                    for (int initialList = 0; initialList <= 51; initialList++) {
                        randomNumList.Add(initialList);
                    }
                    // Fill the reference list with 52 elements, one for each card.

                    for (int count = 0; count <= 51; count++) {
                        int randomIndex = random.Next(randomNumList.Count());
                        int randomCard = randomNumList[randomIndex];
                        randomNumList.Remove(randomCard);

                        // Select a random element from the reference list, and then remove this element. Removing this element stops cards repeating in the shuffled list.

                        if (struckNum.Contains(randomCard))
                        {
                            count--;
                            continue;

                            // If the randomly selected card is already stricken, go again and reduce the count number as this repeat does not count.

                        }
                        else {
                            struckCards.Add(shufflePack[randomCard]);
                            struckNum.Add(randomCard);

                            // If the randomly selected card is not stricken, strike it and add the corresponding card from the pack to a new list.

                        }
                    }

                    pack = struckCards; // Set the pack to the new shuffled list of cards.

                    return true;

                case 2:

                    List<Card> firstHalf = new List<Card>();
                    List<Card> secondHalf = new List<Card>();
                    List<Card> combinedRiffle = new List<Card>();

                    for (int count = 0; count <= 51; count++) {
                        if (count <= 25)
                        {
                            firstHalf.Add(pack[count]);
                        }
                        else if (count >= 26)
                        {
                            secondHalf.Add(pack[count]);
                        }
                    }

                    // Split the current pack of cards in two halves, add the first half to one list and the second half to another.

                    for (int count = 25; count >= 0; count--) {
                        combinedRiffle.Add(firstHalf[count]);
                        combinedRiffle.Add(secondHalf[count]);
                    }

                    // Fill a new list with the riffle shuffle of the previous two halves. Add the corresponding index from each half until the new list has all the cards.

                    pack = combinedRiffle; // Set the single pack of cards to the riffle shuffled version.

                    return true;
                    
                case 3:

                    Pack noShuffle = new Pack(); // Create a new pack of cards that is not shuffled.

                    return false;
            }
            return false;
        }
        public static Card deal()
        {
            //Deals one card

            try
            {
                var dealMethod = Pack.pack[cardCounter];

                // The card at the position of the card counter is dealt.

                cardCounter++;

                // Card counter is increased so the next card in the pack is dealt instead of the same one at the top.

                return dealMethod;
            }
            catch (Exception)
            {
                Console.WriteLine("No more cards to deal.");
                return null;

                // If the card counter is higher than the number of cards then no more cards can be dealt, as all cards have already been dealt.

            }
        }
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'

            try
            {
                List<Card> manyDealtCards = new List<Card>();

                // Initialise list to be returned containing the amount of cards to be dealt.

                for (int count = 0; count <= amount; count++)
                {
                    manyDealtCards.Add(Pack.pack[cardCounter]);
                    cardCounter++;

                    // Add card at position card counter to the new list and increment card counter, this is so the same card isn't dealt over and over.

                }
                return manyDealtCards;
            }
            catch(Exception)
            {
                Console.WriteLine("No more cards to deal.");
                return null;

                // If card counter is higher than the number of cards, then no more cards can be dealt.

            }
        }
    }
}
