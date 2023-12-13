using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace KingChess.CustomOpp
{
    public struct chessPiece
    {
        public string chess;
        public int isWhite;
        public Image img;
    }
    public class MyButton : Button
    {
        public chessPiece CHESS;
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool CurrentOccupid { get; set; }
        public bool LegalNextMove { get; set; }
        public MyButton(int x, int y, chessPiece typeChess) 
        {   
            this.CHESS = new chessPiece();
            this.CHESS = typeChess;
            this.RowNumber = x;
            this.ColumnNumber = y;
            
            this.Width = Lib.sizeButton; this.Height = Lib.sizeButton;
            this.FlatAppearance.BorderSize = 0;
            this.Font = new Font("Arial", 12, FontStyle.Bold);
            this.BackgroundImage = this.CHESS.img;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Transparent;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
        }

        public void ReloadButton()
        {
            this.BackgroundImage = this.CHESS.img;
        }
    }
}
