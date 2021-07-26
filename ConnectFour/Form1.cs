using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour
{
    public partial class Form1 : Form
    {
        private Rectangle[] boardColumns;
        private int[,] graphicsBoard;
        private Game game;
        private DifficultyLevel difficultyLevel;
        private GameMode gameMode;
        private ActivePlayer currentPlayer;
        private bool gameFlag;

        #region GUI Constants
        int BOARD_WIDTH = 640;
        int BOARD_HEIGHT = 600;
        int BOARD_OFFSET = 17;
        int SQUARE_SIZE = 91;
        int CIRCLE_SIZE = 60;
        Color BLUE_COLOR = Color.FromArgb(255, 87, 173, 231);
        #endregion

        public Form1()
        {
            InitializeComponent();
            this.boardColumns = new Rectangle[BoardUtils.COLS];
            this.graphicsBoard = new int[BoardUtils.ROWS, BoardUtils.COLS];
            this.gameMode = GameMode.TwoPlayer;
            this.difficultyLevel = DifficultyLevel.None;
            this.game = Game.CreateGame(this.gameMode, this.difficultyLevel);
            this.gameFlag = false;
            this.currentPlayer = ActivePlayer.RED;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawEmptyBoard();
            cmbx_difficultyLevel.Enabled = false;
            rbtn_twoPlayers.Checked = true;
            lbl_currentTurn.ForeColor = Color.White;
            lbl_currentTurn.Text = "TURN: " + this.currentPlayer;
            lbl_gameMode.ForeColor = Color.White;
            lbl_gameMode.Text = "TWO PLAYERS";
            btn_Exit.BackColor = BLUE_COLOR;
            btn_Reset.BackColor = BLUE_COLOR;
            pnl_settings.BackColor = BLUE_COLOR;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {  
            Application.Restart();
        }

        /*
         * When user clicks the program, the game occurs. Each mouse click e is
         * equivalent to one turn.
         */
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Red Player
            while (!gameFlag && this.currentPlayer == ActivePlayer.RED)
            {     
                int move = this.ClickColumn(e.Location);
                if (game.PlayTurn(move, currentPlayer))
                {
                    int column = game.GetColIndex();
                    int row = game.GetRowIndex();
                    //MessageBox.Show("Red Turn: " + row + ", " + column);

                    Graphics g = this.CreateGraphics();
                    g.FillEllipse(Brushes.Red, BOARD_OFFSET + SQUARE_SIZE * column, BOARD_OFFSET + SQUARE_SIZE * row, CIRCLE_SIZE, CIRCLE_SIZE);
                    
                    gameFlag = CheckVictoryOrDraw(currentPlayer, game.Board);
                    
                    if (gameMode == GameMode.OnePlayer)
                    {
                        // Doing this will skip prompting the yellow player
                        this.currentPlayer = game.ActivePlayerColor;     
                    }

                    lbl_currentTurn.Text = "TURN: " + ActivePlayer.YELLOW;
                    break;
                }
                else if (!game.PlayTurn(move, currentPlayer))
                {
                    MessageBox.Show("Invalid move. Try again.");
                    return;
                }
                else
                {
                    throw new Exception("red player turn");
                }
            }

            // Yellow Player
            while (!gameFlag && this.currentPlayer == ActivePlayer.YELLOW)
            {
                int move = this.ClickColumn(e.Location);
                if (game.PlayTurn(move, currentPlayer))
                {
                    int column = game.GetColIndex();
                    int row = game.GetRowIndex();
                    //MessageBox.Show("Yellow Turn: " + row + ", " + column);
                    Graphics g = this.CreateGraphics();
                    g.FillEllipse(Brushes.Yellow, BOARD_OFFSET + SQUARE_SIZE * column, BOARD_OFFSET + SQUARE_SIZE * row, CIRCLE_SIZE, CIRCLE_SIZE);
                    gameFlag = CheckVictoryOrDraw(currentPlayer, game.Board);
                    lbl_currentTurn.Text = "TURN: " + ActivePlayer.RED;
                    break;
                }
                else if (!game.PlayTurn(move, currentPlayer))
                {
                    MessageBox.Show("Invalid move. Try again.");
                    return;
                }
                else
                {
                    throw new Exception("yellow player turn");
                }
            }

            
            this.currentPlayer = game.ActivePlayerColor;
        }

        private void rbtn_twoPlayers_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_twoPlayers.Checked)
            {
                cmbx_difficultyLevel.Text = "Select Difficulty Level";
                cmbx_difficultyLevel.Enabled = false;
                difficultyLevel = DifficultyLevel.None;
            }    
        }

        private void rbtn_onePlayer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_onePlayer.Checked)
            {
                cmbx_difficultyLevel.Enabled = true;
            }    
        }

        private void cmbx_difficultyLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Do you want to reset the game and apply settings?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ChangeSettings();
                DrawEmptyBoard();
                return;
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        /// <summary>
        /// This method shows a message box for victory or draw.
        /// </summary>
        /// <param name="player"></param>
        /// <param name="board"></param>
        /// <returns>Returns true if a player wins or game is draw.</returns>
        private bool CheckVictoryOrDraw(ActivePlayer player, Board board)
        {
            if (Game.CheckForVictory(player, board))
            {
                MessageBox.Show("Congratulations! " + currentPlayer + " PLAYER has won.");
                return true;
            }

            if (game.CheckDraw(board))
            {
                MessageBox.Show("Draw!");
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method returns the column index based on where the user clicks.
        /// </summary>
        /// <param name="mouse"></param>
        /// <returns></returns>
        private int ClickColumn(Point mouse)
        {
            for (int i = 0; i < BoardUtils.COLS; i++)
            {
                if ((mouse.X >= this.boardColumns[i].X) && (mouse.Y >= this.boardColumns[i].Y))
                {
                    if ((mouse.X <= this.boardColumns[i].X + this.boardColumns[i].Width) &&
                        (mouse.Y <= this.boardColumns[i].Y + this.boardColumns[i].Height))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// This method changes the settings and resets the game.
        /// </summary>
        private void ChangeSettings()
        {
            this.boardColumns = new Rectangle[BoardUtils.COLS];
            this.graphicsBoard = new int[BoardUtils.ROWS, BoardUtils.COLS];
            this.gameMode = (rbtn_onePlayer.Checked) ? GameMode.OnePlayer : GameMode.TwoPlayer;
            if (this.gameMode == GameMode.TwoPlayer)
            {
                this.difficultyLevel = DifficultyLevel.None;
                lbl_gameMode.Text = "TWO PLAYERS";
            }
            else if (this.gameMode == GameMode.OnePlayer)
            {
                switch (cmbx_difficultyLevel.SelectedItem)
                {
                    case "Easy":
                        this.difficultyLevel = DifficultyLevel.Easy; break;
                    case "Normal":
                        this.difficultyLevel = DifficultyLevel.Normal; break;
                    case "Hard":
                        this.difficultyLevel = DifficultyLevel.Hard; break;
                    default:
                        MessageBox.Show("Please select a difficulty level."); break;
                }
                lbl_gameMode.Text = "ONE PLAYER";
            }
            this.game = Game.CreateGame(this.gameMode, this.difficultyLevel);
            this.gameFlag = false;
            this.currentPlayer = ActivePlayer.RED;
            
        }

        private void DrawEmptyBoard()
        {
            Graphics g = this.CreateGraphics();
            Brush blueBrush = new SolidBrush(BLUE_COLOR);
            g.FillRectangle(blueBrush, 0, 0, BOARD_WIDTH, BOARD_HEIGHT);
            for (int i = 0; i < BoardUtils.ROWS; i++)
            {
                for (int j = 0; j < BoardUtils.COLS; j++)
                {
                    if (i == 0)
                    {
                        this.boardColumns[j] = new Rectangle(BOARD_OFFSET + SQUARE_SIZE * j, 0, SQUARE_SIZE, BOARD_HEIGHT);
                    }
                    g.FillEllipse(Brushes.White, BOARD_OFFSET + SQUARE_SIZE * j, BOARD_OFFSET + SQUARE_SIZE * i, CIRCLE_SIZE, CIRCLE_SIZE);
                }
            }
        }

    }
    }

