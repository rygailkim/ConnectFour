using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    /// <summary>
    /// This represents player color.
    /// </summary>
    public enum ActivePlayer
    {
        RED = 1,
        YELLOW = 2
    }

    /// <summary>
    /// This represents a cell that can be unoccupied or occupid by <see cref="ActivePlayer.RED"/>
    /// or <see cref="ActivePlayer.YELLOW"/>
    /// </summary>
    public enum CellStates
    {
        Empty = 0,
        Red = ActivePlayer.RED,
        Yellow = ActivePlayer.YELLOW
        
    }

    /// <summary>
    /// This represents a game mode (can be one-player or two-player).
    /// </summary>
    public enum GameMode
    {
        OnePlayer,
        TwoPlayer
    }

    /// <summary>
    /// This represents difficulty level for the <see cref="Player.ComputerPlayer"/>.
    /// </summary>
    public enum DifficultyLevel
    {
        Easy = 1,
        Normal = 3,
        Hard = 5,
        None = 0
    }

    public static class BoardUtils
    {
        /// <summary>
        /// This represents number of columns of board grid.
        /// </summary>
        public static int COLS = 7;
        /// <summary>
        /// This represents number of rows of board grid.
        /// </summary>
        public static int ROWS = 6;
        /// <summary>
        /// This represents number of consecutive cells to win.
        /// </summary>
        public static int WIN_NUM = 4;
    }
}
