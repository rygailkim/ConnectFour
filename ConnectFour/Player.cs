using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    internal class Player
    {
        /// <summary>
        /// This returns a new <see cref="HumanPlayer"/>.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Player CreateHumanPlayer(ActivePlayer color)
        {
            return new HumanPlayer(color);
        }

        /// <summary>
        /// This returns a new <see cref="ComputerPlayer"/>.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="difficultyLevel"></param>
        /// <returns></returns>
        public static Player CreateComputerPlayer(ActivePlayer color, DifficultyLevel difficultyLevel)
        {
            return new ComputerPlayer(color, difficultyLevel);
        }

        private readonly ActivePlayer playerColor;

        private Player(ActivePlayer color)
        {
            if (color != ActivePlayer.RED && color != ActivePlayer.YELLOW)
                throw new ArgumentOutOfRangeException("player color");

            this.playerColor = color;
        }

        public ActivePlayer Color { get { return playerColor; } }

        /// <summary>
        /// If <see cref="Game.currentPlayer"/> is <see cref="ComputerPlayer"/> then it calls
        /// <see cref="AIEngine.AIEngine(DifficultyLevel)"/>.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public virtual int RequestMove(Board board)
        {
            return -1;
        }

        private class HumanPlayer : Player
        {
            public HumanPlayer(ActivePlayer color) : base(color) { }
        }

        private class ComputerPlayer : Player
        {
            private readonly AIEngine engine;

            public ComputerPlayer(ActivePlayer color, DifficultyLevel difficultyLevel) : base(color)
            {
                engine = new AIEngine(difficultyLevel);
            }

            public override int RequestMove(Board board)
            {
                var move = engine.GetBestMove(board, playerColor);
                return move;
            }
        }
    }
}
