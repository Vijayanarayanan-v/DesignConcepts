using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.DTO;

namespace TicTacToe.Services {
    public interface IGameLogic {

        bool isGameOver();
        int isAnyOneWon(int cellNumber);

        void undoLastMove();

        void movePosition(int cellNumber);

        Player getCurrentPlayer();

        Player getRecentlyPlayedPlayer();

        void addPlayer(Player player);

        bool isValidMove(int cellnumber);

    }
}
