using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe
{


    class Program
     {
        public static void Board(Dictionary<string, List<int>> dictionary,Players player1, Players player2)
        {

            List<object> numbers = new List<object>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> trackedNumbers = dictionary[player1.Name];
            List<int> trackedNumbers2 = dictionary[player2.Name];

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] is int)
                {
                    if (trackedNumbers.Contains((int)numbers[i]))
                    {
                        numbers[i] = player1.Icon;
                    }
                }


            }

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] is int)
                {
                    if (trackedNumbers2.Contains((int)numbers[i]))
                    {
                        numbers[i] = player2.Icon;
                    }
                }


            }

            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {numbers[6]}  |  {numbers[7]}  |  {numbers[8]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {numbers[3]}  |  {numbers[4]}  |  {numbers[5]}");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {numbers[0]}  |  {numbers[1]}  |  {numbers[2]}");
            Console.WriteLine("     |     |      ");
        }

        static void Main(string[] args)
        {
            Dictionary<string, List<int>> GameRecord = new Dictionary<string, List<int>>();

            Players player1 = new Players('X',"player1");
            Players player2 = new Players('O',"player2");

            bool player1Turns = true;

            GameRecord["Checked"] = new List<int>();
            GameRecord[player1.Name] = new List<int>();
            GameRecord[player2.Name] = new List<int>();

            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<List<int>> winningFormula = new List<List<int>>();

            winningFormula.Add(new List<int> { 1, 2, 3 });
            winningFormula.Add(new List<int> { 4, 5, 6 });
            winningFormula.Add(new List<int> { 7, 8, 9 });
            winningFormula.Add(new List<int> { 7, 4, 1 });
            winningFormula.Add(new List<int> { 8, 5, 2 });
            winningFormula.Add(new List<int> { 9, 6, 3 });
            winningFormula.Add(new List<int> { 7, 5, 3 });
            winningFormula.Add(new List<int> { 1, 5, 9 });

            bool checkSquare(int num)
            {
                if (GameRecord["Checked"].Contains(num))
                {
                    return true;
                }

                return false;
            }

             bool CheckWin(Players player)
            {

                foreach (List<int> formula in winningFormula)
                {
                    if (GameRecord[player.Name].All(formula.Contains) && (formula.Count == GameRecord[player.Name].Count))
                    {
                        return true;
                    }
                }

                return false;
            }

            while (true)
            {

                if (player1Turns)
                {
                    Console.WriteLine($"It is {player1.Icon}'s turn.");
                    Board(GameRecord, player1, player2);
                    Console.WriteLine("What square do you want to play in?");

                    int square = int.Parse(Console.ReadKey().KeyChar.ToString());

                    Console.WriteLine("");

                    if (numbers.Contains(square) && !GameRecord[player1.Name].Contains(square) && !checkSquare(square) )
                    {
                        GameRecord[player1.Name].Add(square);
                        GameRecord["Checked"].Add(square);

                    }
                    else if (checkSquare(square))
                    {
                        Console.WriteLine("The square is already occupied, try other squares!");
                        player1Turns = !player1Turns;
                    }
                    else if (!numbers.Contains(square))
                    {
                        Console.WriteLine("Chosen character is not valid");
                        player1Turns = !player1Turns;
                    }
                    else
                    {
                        Console.WriteLine($"Player {player1.Icon} has already selected the square!");
                        player1Turns = !player1Turns;
                    }

                    if (CheckWin(player1))
                    {
                        Console.WriteLine($"Player {player1.Icon} won!");
                        break;
                    }

                }
                else
                {
                    Console.WriteLine($"It is {player2.Icon}'s turn.");
                    Board(GameRecord, player1, player2);
                    Console.WriteLine("What square do you want to play in?");

                    int square = int.Parse(Console.ReadKey().KeyChar.ToString());

                    Console.WriteLine("");

                    if (numbers.Contains(square) && !GameRecord[player2.Name].Contains(square) && !checkSquare(square))
                    {
                        GameRecord[player2.Name].Add(square);
                        GameRecord["Checked"].Add(square);


                    }
                    else if (checkSquare(square))
                    {
                        Console.WriteLine("The square is already occupied, try other squares!");
                        player1Turns = !player1Turns;
                    }
                    else if (!numbers.Contains(square))
                    {
                        Console.WriteLine("Chosen character is not valid");
                        player1Turns = !player1Turns;
                    }
                    else
                    {
                        Console.WriteLine($"Player {player2.Icon} has already selected the square!");
                        player1Turns = !player1Turns;
                    }


                    if (CheckWin(player2))
                    {
                        Console.WriteLine($"Player {player2.Icon} won!");
                        break;
                    }

                }

                if ((!numbers.Except(GameRecord["Checked"]).Any()) && (numbers.Count == GameRecord["Checked"].Count))
                {
                    Console.WriteLine($"This is a tie...");
                    break;
                }

                player1Turns = !player1Turns;

            }
        }
    }


}
