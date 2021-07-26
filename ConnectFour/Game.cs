using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Game
    {
        private Board board;
        private Player redPlayer, yellowPlayer, currentPlayer;

        /// <summary>
        /// This returns either <see cref="OnePlayerGame"/> or <see cref="TwoPlayerGame"/>.
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="difficultyLevel"></param>
        /// <returns></returns>
        public static Game CreateGame(GameMode mode, DifficultyLevel difficultyLevel)
        {
            if (mode == GameMode.OnePlayer)
            {
                return new OnePlayerGame(difficultyLevel);
            }
            else if (mode == GameMode.TwoPlayer)
            {
                return new TwoPlayerGame();
            }
            else
            {
                throw new Exception("create game mode failed");
            }
        }

        /// <summary>
        /// This constructor initializes an empty <see cref="board"/>.
        /// </summary>
        private Game()
        {
            board = Board.EmptyBoard;
        }

        public ActivePlayer ActivePlayerColor { get { return this.currentPlayer.Color; } }
        public Board Board { get { return board; } }        
        public int GetColIndex() { return board.GetColIndex(); }
        public int GetRowIndex() { return board.GetRowIndex(); }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="player"></param>
        /// <param name="board"></param>
        /// <returns>True if <see cref="currentPlayer"/> completes four-in-a-row.</returns>
        public static bool CheckForVictory(ActivePlayer player, Board board)
        {
            if (board == null)
                throw new ArgumentNullException("board null");

            for (int i = 0; i < BoardUtils.ROWS; i++)
            {
                for (int j = 0; j < BoardUtils.COLS; j++)
                {
                    if (board.GetCellState(i, j) == (CellStates)player)
                    {
                        if (SearchVictory(board, i, j))
                            return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="board"></param>
        /// <returns>True if there's no more empty cells.</returns>
        public bool CheckDraw(Board board)
        {
            if (board.NumberOfEmptyCells == 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// This method modifies <see cref="currentPlayer"/>.
        /// </summary>
        /// <param name="currentPlayer"></param>
        /// <returns>Returns color of <see cref="currentPlayer"/></returns>
        private ActivePlayer ChangeActivePlayer(ActivePlayer currentPlayer)
        {
            if (currentPlayer == ActivePlayer.RED)
            {
                this.currentPlayer = yellowPlayer;
                return yellowPlayer.Color;
            }
            else if (currentPlayer == ActivePlayer.YELLOW)
            {
                this.currentPlayer = redPlayer;
                return redPlayer.Color;
            }
            else
            {
                throw new Exception("change active player failed");
            }
        }

        /// <summary>
        /// This will vary depending on <see cref="GameMode"/>. It may take in <see cref="Form1.ClickColumn(System.Drawing.Point)"/>
        /// or generates AI move from <see cref="Player.ComputerPlayer.RequestMove(Board)"/> as move. This will call
        /// <see cref="Board.MakeMove(ActivePlayer, int, out Board)"/>, modifying the <see cref="board"/>
        /// </summary>
        /// <param name="move"></param>
        /// <param name="player"></param>
        /// <returns>False if invalid move (column is full)</returns>
        public virtual bool PlayTurn(int move, ActivePlayer player)
        {
            if (this.currentPlayer.Color == player)
            {
                currentPlayer.RequestMove(board);
            }
            return false;
        }
        
        private class OnePlayerGame : Game
        {
            /// <summary>
            /// This generates a game with <see cref="redPlayer"/> as <see cref="Player.HumanPlayer"/> and
            /// <see cref="yellowPlayer"/> as <see cref="Player.ComputerPlayer"/>.
            /// </summary>
            /// <param name="difficultyLevel"></param>
            public OnePlayerGame(DifficultyLevel difficultyLevel) : base()
            {
                redPlayer = Player.CreateHumanPlayer(ActivePlayer.RED);
                yellowPlayer = Player.CreateComputerPlayer(ActivePlayer.YELLOW, difficultyLevel);
                currentPlayer = redPlayer;         
            }

            /// <summary>
            /// This method is able to evaluate move from player or computer.
            /// </summary>
            /// <param name="move"></param>
            /// <param name="player"></param>
            /// <returns></returns>
            public override bool PlayTurn(int move, ActivePlayer player)
            {
                // Modify move if it's computer's turn
                if (this.currentPlayer == yellowPlayer)
                {
                    move = currentPlayer.RequestMove(board);
                }

                if (this.currentPlayer.Color == player)
                {
                    if (board.MakeMove(player, move, out board))
                    {
                        ChangeActivePlayer(currentPlayer.Color);
                        return true;
                    }
                    return false;
                }
                throw new Exception("play turn failed");
            }
        }

        private class TwoPlayerGame : Game
        {
            /// <summary>
            /// This generates a game with both <see cref="redPlayer"/> and <see cref="yellowPlayer"/> as
            /// <see cref="Player.HumanPlayer"/>.
            /// </summary>
            public TwoPlayerGame() : base()
            {
                redPlayer = Player.CreateHumanPlayer(ActivePlayer.RED);
                yellowPlayer = Player.CreateHumanPlayer(ActivePlayer.YELLOW);
                currentPlayer = redPlayer;
            }

            /// <summary>
            /// This method takes in move from <see cref="Form1.ClickColumn(System.Drawing.Point)"/> and <see cref="currentPlayer"/>. This will also modify the <see cref="board"/>.
            /// </summary>
            /// <param name="move"></param>
            /// <param name="player"></param>
            /// <returns></returns>
            public override bool PlayTurn(int move, ActivePlayer player)
            {
                if (this.currentPlayer.Color == player)
                {
                    if (board.MakeMove(player, move, out board))
                    {
                        ChangeActivePlayer(currentPlayer.Color);
                        return true;
                    }
                    return false;
                }
                throw new Exception("play turn failed");
            }
        }

        #region Private Helper Methods
        private static bool SearchVictory(Board board, int row, int column)
        {
            bool searchRight, searchLeft, searchUp, searchDown;

            searchRight = column <= BoardUtils.COLS - BoardUtils.WIN_NUM;
            searchLeft = column >= BoardUtils.WIN_NUM - 1;
            searchUp = row > BoardUtils.ROWS - BoardUtils.WIN_NUM;
            searchDown = row <= BoardUtils.ROWS - BoardUtils.WIN_NUM;

            if (searchRight)
            {
                if (CheckCells(board.GetCellState(row, column),
                                    board.GetCellState(row, column + 1),
                                    board.GetCellState(row, column + 2),
                                    board.GetCellState(row, column + 3)))
                    return true;
            }

            if (searchLeft)
            {
                if (CheckCells(board.GetCellState(row, column),
                                    board.GetCellState(row, column - 1),
                                    board.GetCellState(row, column - 2),
                                    board.GetCellState(row, column - 3)))
                    return true;
            }

            if (searchUp)
            {
                if (CheckCells(board.GetCellState(row, column),
                                    board.GetCellState(row - 1, column),
                                    board.GetCellState(row - 2, column),
                                    board.GetCellState(row - 3, column)))
                    return true;
            }

            if (searchDown)
            {
                if (CheckCells(board.GetCellState(row, column),
                                    board.GetCellState(row + 1, column),
                                    board.GetCellState(row + 2, column),
                                    board.GetCellState(row + 3, column)))
                    return true;
            }

            if (searchLeft && searchUp)
            {
                if (CheckCells(board.GetCellState(row, column),
                                    board.GetCellState(row - 1, column - 1),
                                    board.GetCellState(row - 2, column - 2),
                                    board.GetCellState(row - 3, column - 3)))
                    return true;
            }

            if (searchLeft && searchDown)
            {
                if (CheckCells(board.GetCellState(row, column),
                                    board.GetCellState(row + 1, column - 1),
                                    board.GetCellState(row + 2, column - 2),
                                    board.GetCellState(row + 3, column - 3)))
                    return true;
            }

            if (searchRight && searchUp)
            {
                if (CheckCells(board.GetCellState(row, column),
                                    board.GetCellState(row - 1, column + 1),
                                    board.GetCellState(row - 2, column + 2),
                                    board.GetCellState(row - 3, column + 3)))
                    return true;
            }

            if (searchRight && searchDown)
            {
                if (CheckCells(board.GetCellState(row, column),
                                    board.GetCellState(row + 1, column + 1),
                                    board.GetCellState(row + 2, column + 2),
                                    board.GetCellState(row + 3, column + 3)))

                    return true;
            }

            return false;
        }

        private static bool CheckCells(params CellStates[] cells)
        {

            for (int i = 1; i < BoardUtils.WIN_NUM; i++)
            {
                if (cells[i] != cells[0])
                    return false;
            }

            return true;
        }
        #endregion
    }

}
