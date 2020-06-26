using System.Collections.Generic;

namespace hw_art_of_war
{
    class Player
    {
        public string Name { get; set; }
        public PlayerDeck Deck { get; set; }
        public List<Card> Played { get; set; }
        public Card ActiveCard { get; set; }

        public Player()
        {
            Name = "";
            Deck = new PlayerDeck();
            Played = new List<Card>();
            ActiveCard = new Card();
        }

        public void Play(int i)
        {
            for(var j=0;j < i; j++)
            {
                if (Deck.Cards.Count > 0)
                {
                    Played.Add(Deck.Remove());
                    ActiveCard = Played[Played.Count - 1];
                }
            }
        }

        public void Collect(List<Player> players)
        {
            foreach(Player player in players)
            {
                Deck.Add(player.Played);
                player.Played = new List<Card>();
                player.ActiveCard = new Card();
            }
        }
    }
}
