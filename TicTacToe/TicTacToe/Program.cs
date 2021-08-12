using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Controller;
using TicTacToe.Services;
using TicTacToe.DTO;

namespace TicTacToe {
    class Program {
        static void Main(string[] args) {



            GameController gc = new GameController(new GameLogic());
            List<Player> players = new List<Player>();
            HashSet<char> symbollist = new HashSet<char> {'-'};

            int i = 0;

            while (i < 2) {

                Console.WriteLine($"Enter the player {i + 1} Name:");
                var name = Console.ReadLine();

                Console.WriteLine($"Enter the player {i + 1} symbol:");
                var symbol = Convert.ToChar(Console.ReadLine());

                while(symbollist.Contains(symbol)) {

                    Console.WriteLine("symbol alredy present, enter different symbol");
                    symbol = Convert.ToChar(Console.ReadLine());

                }


                symbollist.Add(symbol);
                players.Add(new Player(name, symbol));
                i++;
            }


            gc.addPlayers(players);
            gc.startGame();


        }
    }

    

    


    



    





    





}
