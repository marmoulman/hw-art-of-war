using System;

namespace hw_art_of_war
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            int playerCount = 0;
            Console.Write("Choose a new name for your player (default 'Human'):   ");
            string name = Console.ReadLine();
            if (name.Length == 0){ name = "Human"; }
            game.Players.Add(new Player() { Name = name });
            while (playerCount < 1)
            {
                Console.Write("How many AI will there be? Give a number between 1 and 5...");
                var input = Console.ReadLine();
                if( int.TryParse(input, out int j) && j >=1 && j <=5)
                {
                    playerCount = j;
                    for(int i=0;i<j;i++)
                    {
                        game.Players.Add(new Player() { Name = "AI-" + (i+1) });
                    }
                }
                else
                {
                    Console.WriteLine("Player number is invalid. Try again!\n");
                }
            }

            game.Deal();
            Console.WriteLine("The game has now started! Press 'Enter' to play out a turn. Good luck!\n");
            game.CardsRemaining();

            while(game.IsActive())
            {
                game.Turn();
                game.CardsRemaining();
                Console.ReadLine();                                     //This allows the user to step through the game. You can remove this to instantly jump to the end (if there is an end)
            }
            Console.WriteLine("And the winner is..." + game.Winner() + "!!!!!!!!!!!!");
            Console.ReadLine();
        }
    }
}
