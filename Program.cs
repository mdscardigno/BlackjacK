using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace BlackjacK
{
    public class Card
    {
        private string rank;
        private string suit;

        public Card(string cardFace, string cardSuit)//Constructor
        {
            var rank = cardFace;
            var suit = cardSuit;
            var value = 0;
        }
        public override string ToString()
        {
            // return rank.ToString();
            return rank + " of " + suit;
        }
    }
    class Deck
    {
        private Card[] deck;//deck of the Card class
        private int currentCard;//where we are at on our deck
        private const int NUMBER_OF_CARDS = 52;
        private Random ranNum;

        public Deck()
        {
            deck = new Card[NUMBER_OF_CARDS];
            currentCard = 0;
            ranNum = new Random();

            string[] rank = {
                "Ace", "2", "3", "4", "5", "6",
                "7", "8", "9", "10", "Jack", "Queen", "King" };

            string[] suits = {
                "Clubs", "Diamonds", "Hearts", "Spades"
            };

            for (int count = 0; count < deck.Length; count++)//populate the deck of cards
            {
                //deck location starting at 0
                deck[count] = new Card(rank[count % 11], suits[count / 13]);
            };
        }
        public Card DealCard()
        {
            //making sure we are within range or how the total number of cards
            if (currentCard < deck.Length)
            {
                Console.Write(deck[currentCard]);
                return deck[currentCard];//return the next card in the deck
            }
            else { return null; }
        }
        public void Shuffle()
        {
            currentCard = 0;
            for (int first = 0; first < deck.Length; first++)
            {
                //pulling one of the 52 cards from the deck
                int second = ranNum.Next(NUMBER_OF_CARDS);
                //storing value of the card temporarily 
                //swapping cards
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }
        // public class Hand
        // {
        //     public bool hasBusted
        //     {
        //         cardsValue =List<Card> Cards { get; set; }
        //         get
        //         {
        //             return Cards.Sum(card > 21;
        //         }
        //     }
        // }
        private static bool PlayHand()
        {
            Random rng = new Random();
            int playerHandValue = 0;
            int dealerHandValue = 0;
            bool busted = false;
            bool beatDealer = false;
            int cardValue;
            bool hasAce = false;
            do
            {
                cardValue = rng.Next(1, 11);
                // if (cardValue == 1 || cardValue == 11 || hasAce || cardValue + playerHandValue > 21)
                // {
                //     hasAce = true;
                // }
                // else
                // {

                // }
                playerHandValue += cardValue;
                playerHandValue += rng.Next(11, 11);
                playerHandValue = rng.Next(11, 11);
                Console.WriteLine($"You have a hand of: {playerHandValue}");

            } while (!busted || !beatDealer);
            return playerHandValue;
        }
        private static bool WantsToPlay()
        {
            Console.WriteLine("Would you like to play Blackjack?: \nY/N");
            bool isPlaying = Console.ReadLine().ToString().Trim().ToLower() == "Y";
            Console.Clear();
            return isPlaying;
        }

        class Program
        {
            static void DisplayGreeting()
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine(" 🂪🂺 ♦️ \u2660 \u2660 Hello and Welcome to Blackjack \u2665 \u2666 🂱🂷");
                Console.WriteLine("----------------------------------------------------");
            }

            //classess to use
            public static void Main(string[] args)
            {
                int playerScore = 0;
                int dealerScore = 0;
                bool isPlaying;
                bool playerWin;
                // bool isBusted;
                isPlaying = WantsToPlay();
                while (isPlaying)
                {
                    isPlaying = WantsToPlay();
                    playerWin = PlayHand();
                    if (playerWin)
                    {
                        playerScore++;

                    }
                    else
                    {
                        dealerScore++;
                    }

                }

                //Greeting the player
                DisplayGreeting();
                Deck newDeck = new Deck();//new deck
                newDeck.Shuffle();// shuffle of the deck one data structure
                for (int card = 0; card < 52; card++)
                {
                    Console.Write(newDeck.DealCard());//output card
                                                      // if ((card + 1) % 4 == 0) { Console.WriteLine(); }
                    Console.ReadLine();
                }
            }
        }
    }
}
