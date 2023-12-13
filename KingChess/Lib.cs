using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingChess
{
    public class Lib
    {


        #region Size ban co
        public static int sizeButton = 94
            ;
        #endregion

        #region Chess Piece
        public static Image VuaDen = Image.FromFile(Application.StartupPath + "\\ChessPiece\\vuaden.png");
        public static Image XeDen = Image.FromFile(Application.StartupPath + "\\ChessPiece\\xeden.png");
        public static Image TuongDen = Image.FromFile(Application.StartupPath + "\\ChessPiece\\tuongden.png");
        public static Image HauDen = Image.FromFile(Application.StartupPath + "\\ChessPiece\\hauden.png");
        public static Image TotDen = Image.FromFile(Application.StartupPath + "\\ChessPiece\\totden.png");
        public static Image MaDen = Image.FromFile(Application.StartupPath + "\\ChessPiece\\maden.png");

        public static Image VuaTrang = Image.FromFile(Application.StartupPath + "\\ChessPiece\\vuatrang.png");
        public static Image XeTrang = Image.FromFile(Application.StartupPath + "\\ChessPiece\\xetrang.png");
        public static Image TuongTrang = Image.FromFile(Application.StartupPath + "\\ChessPiece\\tuongtrang.png");
        public static Image HauTrang = Image.FromFile(Application.StartupPath + "\\ChessPiece\\hautrang.png");
        public static Image TotTrang = Image.FromFile(Application.StartupPath + "\\ChessPiece\\tottrang.png");
        public static Image MaTrang = Image.FromFile(Application.StartupPath + "\\ChessPiece\\matrang.png");
        #endregion

        #region Mau ban co
        public static Color boardWhite = Color.White;
        public static Color boardBlack = Color.Gray;
        #endregion
    }
}
