using System;
using System.Collections.Generic;

namespace hw_art_of_war
{
    class Common
    {
        // Did a bit of sleuthing for this one. All I know about randomizing in C# is that you shouldn't do it thru Linq for performance reasons, so I'm using an algorithm I found online to shuffle it in place using Random

        //https://stackoverflow.com/questions/273313/randomize-a-listt
        //https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle

        public static List<Card> Shuffle(List<Card> Cards)      //TODO: attach this to the initial deck? Do we want the ability to shuffle both decks? Not right now.
        {
            int n = Cards.Count;
            Random rng = new Random();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
            return Cards;
        }

        //public static InitialDeck Initialize()                  //TODO: attach this to the initial deck
        //{
        //    var deck = new InitialDeck();
        //    var result = new List<Card>();
        //    var suits = new List<string>() { "Hearts", "Clubs", "Spades", "Diamonds" };
        //    var cards = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
        //    for (var i = 0; i < 13; i++)
        //    {
        //        foreach(var suit in suits)
        //        {
        //            result.Add(new Card() { Value = i, Name = cards[i] + " of " + suit });
        //        }
        //    }
        //    deck.Add(result);
        //    deck.Shuffle();
        //    return deck;
        //}

        //public static void Turn(Player human, Player robot)
        //{
        //    human.Play(1);
        //    robot.Play(1);
        //    AnnounceCardPlays(human, human.ActiveCard, robot, robot.ActiveCard);
        //    if (human.ActiveCard.Value > robot.ActiveCard.Value)
        //    {
        //        Console.WriteLine(human.Name + " wins!");
        //        human.Deck.Add(human.Played);
        //        human.Deck.Add(robot.Played);
        //    }
        //    else if (human.ActiveCard.Value < robot.ActiveCard.Value)
        //    {
        //        Console.WriteLine("AI wins!");
        //        robot.Deck.Add(human.Played);
        //        robot.Deck.Add(robot.Played);
        //    }
        //    else
        //    {
        //        Console.WriteLine("TIE. WAR INCOMING!!!!!!");
        //        for (int i=0;i<3;i++)
        //        {
        //            human.Play(1);
        //            robot.Play(1);
        //            AnnounceCardPlays(human, human.ActiveCard, robot, robot.ActiveCard);
        //        }

        //        Turn(human, robot);
        //    }
        //    robot.Played = new List<Card>();
        //    human.Played = new List<Card>();
        //    human.ActiveCard = new Card();
        //    robot.ActiveCard = new Card();
        //}

        //public static void AnnounceCardPlays(Player human, Card humanCard, Player robot, Card robotCard)
        //{
        //    Console.WriteLine(human.Name + " played card:  " + humanCard.Name + " , AI played card:  " + robotCard.Name);
        //}

        public static void AnnounceCardPlays(List<Player> players)
        {
            var str = "";
            foreach (Player player in players)
            {
                if (player.ActiveCard != new Card())
                {
                    str += player.Name + " played card:  " + player.ActiveCard.Name + ", ";
                }
            }
            Console.WriteLine(str.Remove(str.Length-2,2));
        }

        public static void CardsRemaining(Game game)
        {
            string str = "";
            foreach (Player player in game.Players)
            {
                str +=  player.Name + " deck:  " + player.Deck.Cards.Count + ", ";
            }
            Console.WriteLine(str.Remove(str.Length-2,2));
        }
}
}