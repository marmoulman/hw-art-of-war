using System;
using System.Collections.Generic;
using System.Text;

namespace hw_art_of_war
{
    class PlayerDeck : IDeck
    {
        public List<Card> Cards { get; set; }

        public PlayerDeck()
        {
            Cards = new List<Card>();
        }

        public void Add(List<Card> newCards)
        {
            foreach (var card in newCards)
            {
                Cards.Add(card);
            }
            // Add a list of cards to your main deck
        }

        public Card Remove()
        {
            var results = Cards[0];
            Cards.RemoveAt(0);                              //Trying to mimic 'pop', but it looks like RemoveAt returns void. Two lines it is...
            return results;
        }


    }
}
