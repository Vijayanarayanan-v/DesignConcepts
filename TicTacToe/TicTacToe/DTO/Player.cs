using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.DTO {
    public class Player {

        string Id;
        string Name;
        char symbol;


        public Player(string Name, char symbol) {

            this.Name = Name;
            this.symbol = symbol;
            this.Id = new Guid().ToString();
        }

        public char getSymbol() {

            return symbol;
        }

        public string getPlayerName() {

            return this.Name;
        }
    }
}
