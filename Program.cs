using System;
using System.Collections.Generic;
namespace Blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Title = "ASCII Art";
            string title = @"
            ,   .     .                    .        ,-.  .         ,              ,   
            | . |     |                    |        |  ) |         |    o         |   
            | ) ) ,-. | ,-. ,-. ;-.-. ,-.  |-  ,-.  |-<  | ,-: ,-. | ,  , ,-: ,-. | , 
            |/|/  |-' | |   | | | | | |-'  |   | |  |  ) | | | |   |<   | | | |   |<  
            ' '   `-' ' `-' `-' ' ' ' `-'  `-' `-'  `-'  ' `-` `-' ' `  | `-` `-' ' ` 
                                                                    -'             
            ";
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Press any key to start the game!");
            Console.ReadLine();
            Console.Clear();

            bool continuePlaying = true;
            //Main game loop
            while (continuePlaying)
            {
                //creating the starting deck
                List<Card> deck = generateListDeck();

                //shuffle deck and create a stack of cards for playing
                Stack<Card> playingDeck = shuffleDeck(deck);

                //deal hands for player and dealer
                List<Card> playerHand = new List<Card>() { };
                List<Card> dealerHand = new List<Card>() { };
                int playerHandValue = 0;
                int dealerHandValue = 0;
                playerHand.Insert(0, playingDeck.Pop());
                dealerHand.Insert(0, playingDeck.Pop());
                playerHand.Insert(0, playingDeck.Pop());
                dealerHand.Insert(0, playingDeck.Pop());

                //Show player their cards
                Console.Write("You, the player has a hand with: ");
                foreach (Card card in playerHand)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"{card.Name}, with a value of {card.Value}.");
                    playerHandValue += card.Value;
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write($"The value of your hand is = ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{playerHandValue}");
                Console.WriteLine();

                //Show dealer's cards
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Dealer cards are a(n):");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"{dealerHand[0].Name} with value {dealerHand[0].Value}");
                Console.WriteLine($"{dealerHand[1].Name} with value {dealerHand[1].Value}");
                dealerHandValue += dealerHand[0].Value;
                Console.WriteLine();
                //Loop
                string playerResponse = "";
                while (!(playerHandValue > 21 || playerResponse == "s"))
                {
                    //Ask the player to hit or stand until stand or bust (total handValue is > 21)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Would you like to (h)it or (s)tand: ");
                    playerResponse = Console.ReadLine();
                    if (playerResponse == "h")
                    {
                        Card dealtCard = playingDeck.Pop();
                        playerHand.Insert(playerHand.Count, dealtCard);
                        playerHandValue += dealtCard.Value;
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine($"You were dealt a: {dealtCard.Name} and your new total hand value is: {playerHandValue}.");
                    }
                }

                //we calculate if the player busted
                if (playerHandValue > 21)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Uh Oh! You busted and lost. You went over 21. ");
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine();
                    Console.WriteLine("Would you like to play again?: y/n?");
                    continuePlaying = (Console.ReadLine() == "y") ? true : false;
                    continue;
                }

                //dealer reveals hand and keeps hitting until handValue >=17
                while (!(dealerHandValue > 17))
                {
                    Card dealtCard = playingDeck.Pop();
                    dealerHand.Insert(dealerHand.Count, dealtCard);
                    dealerHandValue += dealtCard.Value;
                    Console.WriteLine($"The dealer dealt a {dealtCard.Name}, dealer total hand value is now: {dealerHandValue}.");
                }

                //calculate if dealer bust
                if (dealerHandValue > 21)
                {
                    Console.WriteLine("The dealer hand value is over 21. Player wins!");
                    Console.WriteLine("Would you like to play again? y/n ");
                    //checking if the response is "y". If no, the program continues running.
                    continuePlaying = (Console.ReadLine() == "y") ? true : false;
                    continue;
                }

                //calculate the winner
                //if player hand value is greater than dealer hand value, player wins
                if (playerHandValue > dealerHandValue)
                {
                    Console.WriteLine("Congratulations. You won!.");
                }
                //if player hand value is less than dealer's player looses.
                else
                {
                    Console.WriteLine("Oh No! You lost 🙁.");
                }

                //We ask the player if they want to play again
                Console.WriteLine("Would you like to play again? y/n ");
                continuePlaying = (Console.ReadLine() == "y") ? true : false;
            }
        }
        //Card Shuffler method
        //LIFO Collection, last-in-first-out
        public static Stack<Card> shuffleDeck(List<Card> deck)
        {
            var randomNumberGenerator = new Random();
            int leftIndex;
            Card leftCard;
            Card rightCard;

            for (int rightIndex = deck.Count - 1; rightIndex > 0; rightIndex--)
            {
                leftIndex = randomNumberGenerator.Next(rightIndex + 1);

                //Save cards in variables so we don't lose them!
                leftCard = deck[leftIndex];
                rightCard = deck[rightIndex];

                //Swap
                deck[leftIndex] = rightCard;
                deck[rightIndex] = leftCard;
            }

            return new Stack<Card>(deck);
        }

        public static List<Card> generateListDeck()
        {
            List<Card> deck = new List<Card>() { };
            var suits = new List<string>() { "Clubs", "Diamonds", "Hearts", "Spades" };
            var ranks = new List<string>() { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            var values = new List<int>() { 11, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };

            for (int rank = 0; rank < ranks.Count; rank++)
            {
                foreach (string suit in suits)
                {
                    deck.Insert(0, new Card(ranks[rank] + " of " + suit, values[rank]));
                }
            }
            return deck;
        }
    }
    class Card
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public Card(string newName, int newValue)
        {
            Name = newName;
            Value = newValue;
        }
    }//end of class Card
}