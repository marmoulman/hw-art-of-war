using System;
using System.Collections.Generic;
using System.Text;

namespace hw_art_of_war
{
    public class InitialDeck : IDeck, IShufflable, IFullDeck
    {
        public List<Card> Cards { get; set;}

        public InitialDeck()
        {
            Cards = Initialize();
            Shuffle();
        }

        public void Add(List<Card> newCards)                  //Add cards to Cards. I technically don't think I need the add/remove options since I have the list as public, maybe I'll change that to private.
        {
            foreach (var card in newCards)
            {
                Cards.Add(card);
            }
        }

        public Card Remove()           //Remove cards from Cards. Return the values. Should it check if Cards has content now or on the other side? Probably now.
        {
            var results = Cards[0];
            Cards.RemoveAt(0);                              //Trying to mimic 'pop', but it looks like RemoveAt returns void. Two lines it is...
            return results;
        }

        public List<Card> Shuffle()                           //Shuffle deck
        {
            return Common.Shuffle(Cards);
        }

        public List<Card> Initialize()                          //Initialize as a full deck of cards
        {
            var result = new List<Card>();
            var suits = new List<string>() { "Hearts", "Clubs", "Spades", "Diamonds" };
            var cards = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            for (var i = 0; i < 13; i++)
            {
                foreach (var suit in suits)
                {
                    result.Add(new Card() { Value = i, Name = cards[i] + " of " + suit });
                }
            }
            return result;
        }
    }
}
