# BlackjacK

<!--
Objectives

*PROBLEM
Practice the skills and ideas you have learned so far.
Effectively use loops, conditionals, and other control structures to implement control flows
Demonstrate usage of data structures to model resources.
Requirements

Create a single-player blackjack game that plays against the house, i.e., a human player and computer dealer. You are free to create the user interface however you want, but keep it simple for Explorer Mode.

General Rules:

The game should be played with a standard deck of playing cards (52).
The house should be dealt two cards, hidden from the player until the house reveals its hand.
The player should be dealt two cards, visible to the player.
The player should have a chance to hit (i.e. be dealt another card) until they decide to stop or they bust (i.e. their total is over 21). At which point they lose regardless of the dealer's hand.
When the player stands, the house reveals its hand and hits (i.e. draw cards) until they have 17 or more.
If dealer goes over 21 the dealer loses.
The player should have two choices: "Hit" and "Stand."
Consider Aces to be worth 11, never 1.
The app should display the winner. For this mode, the winner is who is closer to a blackjack (21) without going over.
Ties go to the DEALER
There should be an option to play again. This should start a new game with a new full deck of 52 shuffled cards and new empty hands for the dealer and the player.
Explorer Mode

Generate a PEDA plan for your game. Don't worry about the "C"ode yet.
Redescribe the "P"roblem.
Demonstrate some "E"xamples of various player and dealer card situations. For example, if the player started with the 4 of clubs and the 5 of diamonds but then hit once to get the ten of spades before staying. Then the dealer revealed the 8 of clubs and the ten of diamonds. What happens, who wins. Do at least six of these types of examples
Figure out your "D"ata structure
This should list all of the classes you think you will create and their STATE (properties) and BEHAVIOR (methods). Here is a first hint. You will likely have a Card class that has two properties, a Face and a Suit and one method, Value that will compute how many points the card is worth.
Read the rest of the problem and figure out what other real world things you want to represent. They should have distinct properties and behaviors.
Figure out the "A"lgorithm for playing.
Can you write a step by step algorithm for playing the game?
You should be able to turn these instructions over to someone else and have them follow them step-by step like a recipe. -->

<!--
P E D A C
PEDAC stands for “[Understand the]
Problem,
Examples / Test Cases,
Data Structure,
Algorithm, and
Code.”

PEDAC has two primary objectives: process the problem (PEDA) and code with intent (C)
What is a behavior in OOP
The behavior of an object is defined by its methods, which are the functions and subroutines defined within the object class(type of). Without class methods, a class would simply be a structure. Methods determine what type of functionality a class has, how it modifies its data, and its overall behavior.

Subroutines are functions checking for conditions? Ask Gavin?

BLACKJACK GAME
Who is playing this game?
-With a single player 'player'
-Human vs Computer aren't these two players?
Building the object card deck with 52 cards
-standard deck "treat it as an object"
-with attributes of value or
-What does a card have or what does a card look like?
-Each card has a rank, a suit, an index "on the deck" maybe shapes and use icons?
-Cards must be either hidden or visible

Players
  Two players or // I do not know if I should treat the player as hands and hand x2?
    Computer
    Human

CARDSDECK made of 52 object
  -build
  -shuffle
  -deal
  -Card they is either visible or hidden is a class most surely
  -to dealer or player?
  visible or hidden as boolen? until one of the players reveals the hand of cards
    *Suit
      .icons hearts, clubs, hearts, spades
  *Rank
      .number

POSSIBILITIES OF THE GAME
Player or computer
Deal or stay
PLAYER
Give the player the Option: Play again: Y/NO? place this WriteLine on the OUTERMOST LOOP?

  DEALER WINS
  If the player beats the dealer:
    Display message: Dealer Wins :( "
    Dealer getting closer to 21 than the opponent or without going over 21
    Hands of cards
    Adding the value of the cards gotten
    Less than 21?
    More than 21?

  PLAYER WINS
    If the dealer beats player:
    Display message: "Player wins :) "
    One of the player getting closer to 21 than the opponent or dealer without going over 21
    Hands of cards
    Adding the value of the cards gotten
    Less than 21?
    More than 21?
    Deal or stay

  PLAYER AND DEALER TIDE [HOUSE WINS]
  *****How do they get on a tide? Watch Video
  If the player and dealer get on a tide: Display message: House Win WTF!!!.
    Else: Who wins? Player or Dealer

  PLAYER BUSTS OR BUSTED
  Cards going over 21


HAND

Grouping nouns together and (find out what all these nouns? could be a class or a list?)
-Hand
Total
Receives
Cards

-Deck
Deal
List of Cards

-Cards Class
Value
Rank
Suit

Algorithm
1- Application welcomes the player. Hello and Welcome to Blackjack.
2- Start the game with a shuffled full deck of 52 shuffled cards
each card will have a value <list>
Range 2-10 points value
Aces are worth 11 points value but never 1
J,Q,K = 10 points value
Player gets the first turn of the hand.
  Player checks cards "if cardsValueCount >= 17, be a count of the cards (which can be a property in common for both the player and the dealer.) per hand or round played."
  If cardsValueCount >=17 then playerOption Maybe a Loop?
  If player hits and cardsValueCount > 21;

This program ends with giving the option to the player to play again.
Use conditional If yes = play again else = quit.

RE-READ THE PROBLEM AND THE REQUIREMENTS
WATCH THE CLASS VIDEO
CONTINUE WORKING ON THE PEDAC PROCESS AS IT IS DUE TOMORROW


Begining state of dealer has zero cards
Begining state of player has zero cards
Each hand starts with the dealer dealing two cards for himself or the house and two cards for the player.
Dealer hides one card and shows the other.
Player gets the first turn of the hand

HAND or number of cards
A good hand or bad hand
Each hand will have a winner and a looser since is one player vs the dealer
Win
Closest to 21 or 21
Loose
Furthest and or over 21

FREE-WRITING
1- The game starts with a deck of shuffled cards.
2- The dealer deals two cards:
    firstCard (on the shuffled card example)
    secondCard (on the shuffled card example)
   two for him (one card is hidden and the other is shown)
   two for the player (both cards are hidden until the dealer shows his/her cards)
   creating two methods to showCards and set it to bool?
3-

Creating a class Hand and then having a class Blackjack
Method TwoShuffledCards returns two shuffled cards?

-->
