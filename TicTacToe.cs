namespace TicTacToe
{
    public partial class TicTacToe : Form
    {
        Piece[,] board = new Piece[3, 3];
        int role=0,xScore=0,oScore=0;
        Label lblScore = new Label();
        public TicTacToe()
        {
            InitializeComponent();
            intial();
        }

        private void intial()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    board[i,j]=new Piece(j*100,i*100);
                    board[i, j].Click += play ;
                    board[i, j].Cursor = Cursor.Current;
                    Controls.Add(board[i,j]);
                }
            labelScore();
        }

        private void labelScore()
        {
            lblScore.Location = new Point(0, 320);
            lblScore.Width = 350;
            lblScore.Text = "PIX:0-PIO:0";
            Controls.Add(lblScore);
        }

        private void play(object sender, EventArgs e)
        {
            int i=((Button)sender).Top/100,j=((Button)sender).Left/100;
            if (board[i, j].state == States.F)
            {
                if (role % 2 == 0)
                {
                    board[i,j].state = States.X;
                    board[i, j].Image = Properties.Resources.d_heart;

                }
                else
                {
                    board[i, j].state = States.O;
                    board[i, j].Image= Properties.Resources.heart;
                }
                role += 1;
                checkWinner();
                if (role == 9) resetBoard();
            }
            else
            {
                MessageBox.Show("InValid Place");
            }
        }

        private void checkWinner()
        {
            //rows
            for(int i = 0; i < 3; i++)
            
                if (board[i, 1].state == board[i, 0].state && board[i,1].state == board[i,2].state && board[i, 1].state != States.F)
                {
                    done(i, 1);
                    return;
                }
            //columns
            for(int j = 0; j < 3; j++)
            {
                if(board[1, j].state == board[0, j].state && board[1, j].state == board[2, j].state && board[1, j].state != States.F)
                {
                    done(1,j);
                    return;
                }
                //dioganala
                if (board[0, 0].state == board[1, 1].state&& board[1, 1].state == board[2, 2].state && board[1, 1].state == board[3, 3].state)
                {
                    done(1, 1);
                }
                else if(board[0, 2].state == board[1, 1].state && board[1, 1].state == board[2, 0].state && board[1, 1].state != States.F)
                {
                    done(1, 1);
                }
            }
        }
        

        private void done(int i, int j)
        {
            if (board[i, j].state == States.X) xScore += 1;
            else oScore+=1;
            resetBoard();
            lblScore.Text = "PIX:" + xScore.ToString() + "-PIO: " + oScore.ToString();
        }

        private void resetBoard()
        {
          for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                {
                    board[i, j].Image= null;
                    board[i,j].state= States.F;
                }
        }
    }
}