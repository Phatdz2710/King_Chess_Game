namespace KingChess
{
    public partial class Form1 : Form
    {
        public Board ChessBoard;

        public Form1()
        {
            InitializeComponent();

            

        }


        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ChessBoard = new Board(pnlChessBoard);
        }
    }
}