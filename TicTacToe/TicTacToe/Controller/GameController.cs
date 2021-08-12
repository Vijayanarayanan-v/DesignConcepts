using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Services;
using TicTacToe.DTO;

namespace TicTacToe.Controller {
    public class GameController {

        private readonly IGameLogic gameLogic;
        public GameController(IGameLogic gameLogic) {

            this.gameLogic = gameLogic;
        }


        public void startGame() {

            var anyOneWon = -1;
            while (!this.gameLogic.isGameOver()) {


                Console.WriteLine($"Currently playing: {this.gameLogic.getCurrentPlayer().getPlayerName()}");
                Console.WriteLine($"Enter the Cell position to place Symbol");
                var position = Convert.ToInt32(Console.ReadLine());

                if (!this.gameLogic.isValidMove(position)) {

                    Console.WriteLine("Wrong position try again");
                    continue;
                }
                this.gameLogic.movePosition(position);

                anyOneWon = this.gameLogic.isAnyOneWon(position);

                if (anyOneWon == 1 || anyOneWon == 0) break;
            }


            if (anyOneWon == 0) Console.WriteLine("Match Draw");

            else Console.WriteLine($"{this.gameLogic.getRecentlyPlayedPlayer().getPlayerName()} won the game");

            return;

        }



        public void addPlayers(List<Player> players) {

            foreach (var player in players) {

                this.gameLogic.addPlayer(player);
            }
        }








    }
}
