using System.Collections.Generic;

namespace hw_art_of_war
{
    interface IDeck
    {
        List<Card> Cards { get; set; }

        void Add(List<Card> newCards);
        Card Remove();
    }
}