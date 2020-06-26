using System;
using System.Collections.Generic;

namespace hw_art_of_war
{
    class Game
    {
        public List<Player> Players { get; set; }
        public InitialDeck Deck { get; set; }

        public Game()
        {
            Players = new List<Player>();
            Deck = new InitialDeck();
        }

        public void PlayCards(int plays)
        {
            for(int i=0;i<plays;i++)
            {
                foreach (var player in Players)
                {
                    player.Play(1);
                }
                Common.AnnounceCardPlays(Players);
            }
        }

        public void Deal()
        {
            while(Deck.Cards.Count > 0)
            {
                var removed = Deck.Remove();
                Players[Deck.Cards.Count % Players.Count].Deck.Add(new List<Card>() { removed });       //This should divvy up the cards equally between each player
            }
        }

        public bool IsActive()
        {
            foreach(Player player in Players)
            {
                if(player.Deck.Cards.Count == 52)
                {
                    return false;
                }
            }
            return true;
        }
        public string Winner()
        {
            foreach(Player player in Players)
            {
                if(player.Deck.Cards.Count == 52)
                {
                    return player.Name;
                }
            }
            return "No winner found!";
        }

        public void CardsRemaining()
        {
            string str = "";
            foreach (Player player in Players)
            {
                str += player.Name + " deck:  " + player.Deck.Cards.Count + ", ";
            }
            Console.WriteLine(str.Remove(str.Length - 2, 2));
        }



        public void Turn()
        {
            PlayCards(1);

            List<Player> winners = new List<Player>();
            int max = 0;
            foreach(Player player in Players)
            {
                if (player.ActiveCard.Value > max)
                {
                    max = player.ActiveCard.Value;
                    winners = new List<Player> { player };
                }
                else if (player.ActiveCard.Value == max)
                {
                    winners.Add(player);
                }
            }
            if(winners.Count == 1)
            {
                winners[0].Collect(Players);
                Console.WriteLine(winners[0].Name + " wins!");
            }
            else
            {
                Console.WriteLine("WAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAR");
                PlayCards(3);
                Turn();
            }
        }
    }
}
