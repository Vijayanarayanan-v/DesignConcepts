using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.DTO;

namespace TicTacToe.Services {
    public class GameLogic : IGameLogic {

        Board board;

        Dictionary<int, HashSet<int>> filledColumncells;
        Dictionary<int, HashSet<int>> filledRowCells;
        List<int> leftDiagonalCells;
        List<int> rightDiagonalCells;
        HashSet<int> occupiedCell;

        char wonSymbol = '-';

        public GameLogic() {
            this.occupiedCell = new HashSet<int>();
            this.board = new Board(3);
            this.filledColumncells = new Dictionary<int, HashSet<int>>();
            this.filledRowCells = new Dictionary<int, HashSet<int>>();
            this.leftDiagonalCells = new List<int>();
            this.rightDiagonalCells = new List<int>();
        }



        public bool isValidMove(int cellnumber) {

            return (!this.occupiedCell.Contains(cellnumber) &&
                    cellnumber >= 0 &&
                    cellnumber <= (this.board.getBoardSize() * this.board.getBoardSize()));

        }

        public int isAnyOneWon(int cellNumber) {

            int row = (cellNumber - 1) / this.board.getBoardSize();
            int column = (cellNumber - 1) % this.board.getBoardSize();

            if (this.filledRowCells.ContainsKey(row) &&
                this.filledRowCells[row].Count == this.board.getBoardSize() &&
                checkRow(row)) return 1;

            else if (this.filledColumncells.ContainsKey(column) &&
                this.filledColumncells[column].Count == this.board.getBoardSize() &&
                checkColumn(row)) return 1;


            else if (this.leftDiagonalCells.Count == this.board.getBoardSize() && checkLeftDiagonal()) return 1;

            else if (this.rightDiagonalCells.Count == this.board.getBoardSize() && CheckRightDiagonal()) return 1;


            else if (this.isBoardOccupied()) return 0;

            return -1;

        }


        private bool isBoardOccupied() {

            return this.occupiedCell.Count == (this.board.getBoardSize() * this.board.getBoardSize());
        }

        bool checkColumn(int CompletedColumn) {

            var boradSize = board.getBoardSize();
            var grid = board.getGrid();
            for (int i = CompletedColumn; i < boradSize; i++)
                if (grid[0, i] != grid[0, i - 1]) return false;

            this.wonSymbol = grid[0, CompletedColumn];
            return true;
        }

        bool checkRow(int completedRow) {

            var boradSize = board.getBoardSize();
            var grid = board.getGrid();
            for (int i = completedRow; i < boradSize; i++)
                if (grid[i, 0] != grid[i - 1, 0]) return false;

            this.wonSymbol = grid[completedRow, 0];
            return true;
        }


        bool checkLeftDiagonal() {
            var boradSize = board.getBoardSize();
            var grid = board.getGrid();

            int row = 1;
            int column = 1;
            while (row < boradSize && column < boradSize) {

                if (grid[row, column] != grid[row - 1, column - 1]) return false;

                row++;
                column++;
            }

            this.wonSymbol = grid[0, 0];
            return true;
        }

        bool CheckRightDiagonal() {
            var boradSize = board.getBoardSize();
            var grid = board.getGrid();

            int row = boradSize - 2;
            int column = boradSize - 2;
            while (row >= 0 && column >= 0) {

                if (grid[row, column] != grid[row + 1, column + 1]) return false;

                row--;
                column--;
            }

            this.wonSymbol = grid[boradSize - 1, boradSize - 1];
            return true;
        }




        public bool isGameOver() {

            return this.isBoardOccupied();
        }



        public void movePosition(int cellnumber) {

            int row = (cellnumber - 1) / this.board.getBoardSize();
            int column = (cellnumber - 1) % this.board.getBoardSize();


            this.board.getGrid()[row, column] = this.board.ChangePlayer().getSymbol();

            this.occupiedCell.Add(cellnumber);

            if (this.filledRowCells.ContainsKey(row)) this.filledRowCells[row].Add(cellnumber);

            else this.filledRowCells.Add(row, new HashSet<int>(cellnumber));

            if (this.filledColumncells.ContainsKey(column)) this.filledColumncells[column].Add(cellnumber);

            else this.filledColumncells.Add(column, new HashSet<int>(cellnumber));


            if ((row + column) == this.board.getBoardSize() - 1) {

                this.rightDiagonalCells.Add(cellnumber);

            }
            if (row == column) {
                this.leftDiagonalCells.Add(cellnumber);
            }


        }




        public void addPlayer(Player player) {

            this.board.getPlayers().AddLast(player);

        }





        public Player getCurrentPlayer() {

            return this.board.getCurrentPlayer();
        }


        public Player getRecentlyPlayedPlayer() {

            return this.board.getRecentlyPlayedPlayer();
        }



        public void undoLastMove() {
            throw new NotImplementedException();
        }


    }
}
