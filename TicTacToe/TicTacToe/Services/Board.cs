using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.DTO;

namespace TicTacToe.Services {
    public class Board {

        //dequeue
        LinkedList<Player> players;
        int boardSize;
        char[,] grid;

        public Board(int size) {

            this.players = new LinkedList<Player>();
            this.boardSize = size;
            this.grid = new char[size, size];

            this.initialize();
        }


        private void initialize() {

            for (int i = 0; i < this.boardSize; i++)
                for (int j = 0; j < this.boardSize; j++)
                    this.grid[i, j] = '-';

        }

        public int getBoardSize() {

            return this.boardSize;
        }


        public char[,] getGrid() {

            return this.grid;
        }

        public Player getCurrentPlayer() {

            var currentPlayer = this.players.First.Value;
            return currentPlayer;

        }
        public Player getRecentlyPlayedPlayer() {

            var currentPlayer = this.players.Last.Value;
            return currentPlayer;

        }

        public Player ChangePlayer() {

            var currentPlayer = this.players.First.Value;
            this.players.RemoveFirst();
            this.players.AddLast(currentPlayer);
            return currentPlayer;

        }

        public LinkedList<Player> getPlayers() {

            return this.players;
        }





    }
}
