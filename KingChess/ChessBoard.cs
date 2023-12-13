using KingChess.CustomOpp;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KingChess
{
    public class Board
    {
        private static Image board = Image.FromFile(Application.StartupPath + "\\ChessPiece\\banco.png");

        //Panel chua ban co
        private Panel chessBoard;
        public Panel ChessBoard { get { return chessBoard; } set { chessBoard = value; } }
        // Size Board
        public const int SIZE = 8;

        //Mang 2 chieu cac nut (ban co)
        public List<List<MyButton>> MyProperty;

        //Ve ban co
        public Board (Panel chessBoard)
        {
            
            MyProperty = new List<List<MyButton>>();
            //Ve ban co xen ke
            bool isWhite = true;
            MyButton temp;
            this.ChessBoard = chessBoard;
            chessPiece typeChess = new chessPiece();
            for(int i = 0; i < SIZE; i++)
            {
                MyProperty.Add(new List<MyButton>());
                for (int j = 0; j < SIZE; j++)
                {
                    typeChess = SetFlag(i, j);
                    temp = new MyButton(i, j, typeChess)
                    {
                        Location = new Point(j * Lib.sizeButton + 22, i * Lib.sizeButton + 22),
                    };

                    temp.Click += Btn_Click;
                    MyProperty[i].Add(temp);
                    isWhite = !isWhite;
                    ChessBoard.Controls.Add(MyProperty[i][j]);
                }
                isWhite =!isWhite;
            }
            ChessBoard.BackgroundImage = board;
            ChessBoard.Size = new Size(board.Width, board.Height);
        }

        //Thiet lap quan co
        private chessPiece SetFlag (int x, int y)
        {
            if (x == 0)
            {
                if (y == 0 || y == 7) return new chessPiece() { chess = "Xe", isWhite = 2, img = Lib.XeDen };
                else if (y == 1 || y == 6) return new chessPiece() { chess = "Ma", isWhite = 2, img = Lib.MaDen};
                else if (y == 2 || y == 5) return new chessPiece() { chess = "Tuong", isWhite = 2, img = Lib.TuongDen };
                else if (y == 3) return new chessPiece() { chess = "Vua", isWhite = 2, img = Lib.VuaDen };
                else return new chessPiece() { chess = "Hau", isWhite = 2, img = Lib.HauDen};
            }
            else if (x == 1) { return new chessPiece() { chess = "Tot", isWhite = 2, img = Lib.TotDen }; }
            else if (x == 7)
            {
                if (y == 0 || y == 7) return new chessPiece() { chess = "Xe", isWhite = 1, img = Lib.XeTrang};
                else if (y == 1 || y == 6) return new chessPiece() { chess = "Ma", isWhite = 1, img = Lib.MaTrang };
                else if (y == 2 || y == 5) return new chessPiece() { chess = "Tuong", isWhite = 1, img = Lib.TuongTrang};
                else if (y == 3) return new chessPiece() { chess = "Vua", isWhite = 1, img = Lib.VuaTrang };
                else return new chessPiece() { chess = "Hau", isWhite = 1, img = Lib.HauTrang };
            }else if (x == 6) return new chessPiece() { chess = "Tot", isWhite = 1, img = Lib.TotTrang };



            return new chessPiece() { chess = string.Empty, isWhite = 0, img = new Bitmap(1,1) };
        }

        //Kiem tra nuoc di hop le
        private bool isSafe(MyButton btn, int x, int y)
        {
            if (x < 0 || y < 0 || x >= SIZE || y >= SIZE 
                || MyProperty[x][y].CHESS.isWhite == btn.CHESS.isWhite)
            {
                return false;
            } 
            else if (MyProperty[x][y].CHESS.isWhite != 0 && MyProperty[x][y].CHESS.isWhite != btn.CHESS.isWhite)
            {
                MyProperty[x][y].LegalNextMove = true;
                return false;
            }
            return true;
        }

        //Kiem tra nuoc di quan Tot
        private void isSafeForTot(MyButton btn)
        {
            
            int y = btn.RowNumber; int x = btn.ColumnNumber;
            //MyProperty[x].LegalNextMove = true;
            if (btn.CHESS.isWhite == 1)
            {
                if (y == 6)
                {
                    if (y - 1 >= 0 && MyProperty[y - 1][x].CHESS.chess == string.Empty)
                        MyProperty[y - 1][x].LegalNextMove = true;
                    if (y - 2 >= 0 && MyProperty[y - 2][x].CHESS.chess == string.Empty)
                        MyProperty[y - 2][x].LegalNextMove = true;
                } 
                else
                {
                    if (y - 1 >= 0 && MyProperty[y - 1][ x].CHESS.chess == string.Empty)
                        MyProperty[y - 1][x].LegalNextMove = true;
                }

                if (y - 1 >= 0 && x + 1 < SIZE)
                {
                    if (MyProperty[y - 1][x+1].CHESS.isWhite == 2)
                        MyProperty[y - 1][x + 1].LegalNextMove = true;
                }

                if (y - 1 >= 0 && x - 1 >= 0)
                {
                    if (MyProperty[y - 1][x - 1].CHESS.isWhite == 2)
                        MyProperty[y - 1][x - 1].LegalNextMove = true;
                }
            }
            else if (btn.CHESS.isWhite == 2)
            {
                if (y == 1)
                {
                    if (y + 1 >= 0 && MyProperty[y + 1][x].CHESS.chess == string.Empty)
                        MyProperty[y + 1][ x].LegalNextMove = true;
                    if (y + 2 >= 0 && MyProperty[y + 2][x].CHESS.chess == string.Empty)
                        MyProperty[y + 2][x].LegalNextMove = true;
                }
                else
                {
                    if (y + 1 >= 0 && MyProperty[y + 1][x].CHESS.chess == string.Empty)
                        MyProperty[y + 1][x].LegalNextMove = true;
                }

                if (y + 1 >= 0 && x + 1 < SIZE)
                {
                    if (MyProperty[y + 1][x + 1].CHESS.isWhite == 1)
                        MyProperty[y + 1][x + 1].LegalNextMove = true;
                }

                if (y + 1 >= 0 && x - 1 >= 0)
                {
                    if (MyProperty[y + 1][x - 1].CHESS.isWhite == 1)
                        MyProperty[y + 1][x - 1].LegalNextMove = true;
                }
            }

        }

        //Đưa ra những nước đi hợp lệ 
        public void NextLegal (MyButton btn)
        {
            string chessPiece = btn.CHESS.chess;
            for (int i = 0; i < SIZE; ++i)
            {
                for (int j = 0; j < SIZE; ++j)
                {
                    MyProperty[i][j].LegalNextMove = false;
                    MyProperty[i][j].CurrentOccupid = false;
                }
            }

            switch (chessPiece)
            {
                case "Ma":
                    if (isSafe(btn, btn.RowNumber + 2,btn.ColumnNumber + 1))
                        MyProperty[btn.RowNumber + 2][btn.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(btn, btn.RowNumber + 2,btn.ColumnNumber - 1))
                        MyProperty[btn.RowNumber + 2][btn.ColumnNumber - 1].LegalNextMove = true;
                    if (isSafe(btn, btn.RowNumber - 2,btn.ColumnNumber - 1))
                        MyProperty[btn.RowNumber - 2][btn.ColumnNumber - 1].LegalNextMove = true;
                    if (isSafe(btn,btn.RowNumber - 2,btn.ColumnNumber + 1))
                        MyProperty[btn.RowNumber - 2][btn.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(btn,btn.RowNumber + 1,btn.ColumnNumber - 2))
                        MyProperty[btn.RowNumber + 1][btn.ColumnNumber - 2].LegalNextMove = true;
                    if (isSafe(btn,btn.RowNumber + 1,btn.ColumnNumber + 2))
                        MyProperty[btn.RowNumber + 1][btn.ColumnNumber + 2].LegalNextMove = true;
                    if (isSafe(btn,btn.RowNumber - 1, btn.ColumnNumber + 2))
                        MyProperty[btn.RowNumber - 1][btn.ColumnNumber + 2].LegalNextMove = true;
                    if (isSafe(btn,btn.RowNumber - 1, btn.ColumnNumber - 2))
                        MyProperty[btn.RowNumber - 1][btn.ColumnNumber - 2].LegalNextMove = true;
                    break;
                case "Xe":
                    int i = 0;
                    while (isSafe(btn, btn.RowNumber + i + 1, btn.ColumnNumber))
                    {
                        i++;
                        MyProperty[btn.RowNumber + i][btn.ColumnNumber].LegalNextMove = true;
                    }
                    i = 0;
                    while (isSafe(btn, btn.RowNumber - i - 1, btn.ColumnNumber))
                    {
                        i++;
                        MyProperty[btn.RowNumber - i][btn.ColumnNumber].LegalNextMove = true;
                    }
                    i = 0;
                    while (isSafe(btn, btn.RowNumber,btn.ColumnNumber - i - 1))
                    {
                        i++;
                        MyProperty[btn.RowNumber][btn.ColumnNumber - i].LegalNextMove = true;
                    }
                    i = 0;
                    while (isSafe(btn, btn.RowNumber, btn.ColumnNumber + i + 1))
                    {
                        i++;
                        MyProperty[btn.RowNumber][btn.ColumnNumber + i].LegalNextMove = true;
                    }
                    break;
                case "Hau":
                    {   i = 0;
                        while (isSafe(btn, btn.RowNumber + i + 1,  btn.ColumnNumber + i + 1))
                        {
                            i++;
                            MyProperty[btn.RowNumber + i][btn.ColumnNumber + i].LegalNextMove = true;
                        }
                        i = 0;
                        while (isSafe(btn, btn.RowNumber + i + 1, btn.ColumnNumber - i - 1))
                        {
                            i++;
                            MyProperty[btn.RowNumber + i][btn.ColumnNumber - i].LegalNextMove = true;
                        }
                        i = 0;
                        while (isSafe(btn, btn.RowNumber - i - 1, btn.ColumnNumber + i + 1))
                        {
                            i++;
                            MyProperty[btn.RowNumber - i][btn.ColumnNumber + i].LegalNextMove = true;
                        }
                        i = 0;
                        while (isSafe(btn, btn.RowNumber - i - 1, btn.ColumnNumber - i - 1))
                        {
                            i++;
                            MyProperty[btn.RowNumber - i][btn.ColumnNumber - i].LegalNextMove = true;
                        }
                        i = 0;
                        while (isSafe(btn, btn.RowNumber + i + 1, btn.ColumnNumber))
                        {
                            i++;
                            MyProperty[btn.RowNumber + i][btn.ColumnNumber].LegalNextMove = true;
                        }
                        i = 0;
                        while (isSafe(btn, btn.RowNumber - i - 1, btn.ColumnNumber))
                        {
                            i++;
                            MyProperty[btn.RowNumber - i][btn.ColumnNumber].LegalNextMove = true;
                        }
                        i = 0;
                        while (isSafe(btn, btn.RowNumber , btn.ColumnNumber - i - 1))
                        {
                            i++;
                            MyProperty[btn.RowNumber][btn.ColumnNumber - i].LegalNextMove = true;
                        }
                        i = 0;
                        while (isSafe(btn, btn.RowNumber , btn.ColumnNumber + i + 1))
                        {
                            i++;
                            MyProperty[btn.RowNumber][btn.ColumnNumber + i].LegalNextMove = true;
                        }
                    }
                    break;
                case "Vua":
                    if (isSafe(btn, btn.RowNumber + 1, btn.ColumnNumber + 1))
                    {
                        
                        MyProperty[btn.RowNumber + 1][btn.ColumnNumber + 1].LegalNextMove = true;
                    }
                    
                    if (isSafe(btn, btn.RowNumber  + 1,btn.ColumnNumber - 1))
                    {
                       
                        MyProperty[btn.RowNumber + 1][btn.ColumnNumber - 1].LegalNextMove = true;
                    }
                   
                    if (isSafe(btn, btn.RowNumber - 1, btn.ColumnNumber  + 1))
                    {
                       
                        MyProperty[btn.RowNumber - 1][btn.ColumnNumber + 1].LegalNextMove = true;
                    }
                    
                    if (isSafe(btn, btn.RowNumber  - 1, btn.ColumnNumber  - 1))
                    {
                       
                        MyProperty[btn.RowNumber - 1][btn.ColumnNumber - 1].LegalNextMove = true;
                    }
                    
                    if (isSafe(btn, btn.RowNumber + 1, btn.ColumnNumber))
                    {
                       
                        MyProperty[btn.RowNumber + 1][btn.ColumnNumber].LegalNextMove = true;
                    }
                   
                    if (isSafe(btn, btn.RowNumber  - 1, btn.ColumnNumber))
                    {
                       
                        MyProperty[btn.RowNumber - 1][btn.ColumnNumber].LegalNextMove = true;
                    }
                   
                   if (isSafe(btn, btn.RowNumber, btn.ColumnNumber - 1))
                    {
                       
                        MyProperty[btn.RowNumber][btn.ColumnNumber - 1].LegalNextMove = true;
                    }
                  
                    if (isSafe(btn, btn.RowNumber, btn.ColumnNumber  + 1))
                    {
                      
                        MyProperty[btn.RowNumber][btn.ColumnNumber + 1].LegalNextMove = true;
                    }
                    break;
                case "Tuong":
                    i = 0;
                    while (isSafe(btn, btn.RowNumber + i + 1, btn.ColumnNumber + i + 1))
                    {
                        i++;
                        MyProperty[btn.RowNumber + i][btn.ColumnNumber + i].LegalNextMove = true;
                    }
                    i = 0;
                    while (isSafe(btn, btn.RowNumber + i + 1, btn.ColumnNumber - i - 1))
                    {
                        i++;
                        MyProperty[btn.RowNumber + i][btn.ColumnNumber - i].LegalNextMove = true;
                    }
                    i = 0;
                    while (isSafe(btn, btn.RowNumber - i - 1, btn.ColumnNumber + i + 1))
                    {
                        i++;
                        MyProperty[btn.RowNumber - i][btn.ColumnNumber + i].LegalNextMove = true;
                    }
                    i = 0;
                    while (isSafe(btn, btn.RowNumber - i - 1, btn.ColumnNumber - i - 1))
                    {
                        i++;
                        MyProperty[btn.RowNumber - i][btn.ColumnNumber - i].LegalNextMove = true;
                    }
                    break;
                case "Tot":
                    isSafeForTot(btn);
                    break;
                default: break;
            }
        }

        //Thiết lập lại bàn cờ (Xóa phần gợi ý NextLegal)
        private void NormalBoard ()
        {
            for (int i = 0; i < SIZE; i++)
            {
                for(int j = 0; j < SIZE; j++)
                {
                    if (MyProperty[i][j].LegalNextMove)
                    {
                        MyProperty[i][j].Text = string.Empty;
                        MyProperty[i][j].BackgroundImage = MyProperty[i][j].CHESS.img;
                        MyProperty[i][j].ForeColor = Color.Black;
                    }
                    
                }
            }
        }

     

        //Khóa các nút vừa được mở để di chuyển
        private void LockButton()
        {
            for(int i = 0; i < SIZE; ++i)
            {
                for(int j =0; j < SIZE; j++)
                {
                    if (MyProperty[i][j].LegalNextMove)
                        MyProperty[i][j].LegalNextMove = false;
                }
            }
        }

        //Quân cờ được chọn trước khi thực hiện di chuyển 
        private MyButton myChoose;

        //Di chuyển quân cờ đến btnNext
        private bool ChessMove (MyButton btnNext)
        {
            bool isWin = false;
            if (btnNext.CHESS.chess == "Vua") isWin = true;
            btnNext.CHESS = myChoose.CHESS;
            btnNext.ReloadButton();
            myChoose.CHESS.isWhite = 0;
            myChoose.CHESS.chess = string.Empty;
            myChoose.CHESS.img = new Bitmap(1, 1);
            myChoose.ReloadButton();

            return isWin;
        }

        //Vẽ các nước đi hợp lệ cho quân cờ 
        private void NextLegalDraw()
        {
            for(int i = 0; i < SIZE; i++)
            {
                for(int j = 0; j < SIZE; j++)
                {
                    if (MyProperty[i][j].LegalNextMove) {
                        if (MyProperty[i][j].CHESS.chess != string.Empty) MyProperty[i][j].ForeColor = Color.Red;
                        MyProperty[i][j].Text = "X";
                        
                    }
                }
            }
        }

        public void Rematch()
        {
            chessPiece typeChess;
            for(int i = 0; i < SIZE; ++i)
            {
                for(int j = 0; j < SIZE; ++j)
                {
                    typeChess = SetFlag(i, j);
                    MyProperty[i][j].CHESS = typeChess;
                    MyProperty[i][j].ReloadButton();
                }
            }
        }

        //Lượt đi 
        private int Turn = 1;

        //Sự kiện nhấp chuột vào một nút trên bàn cờ
        private void Btn_Click (object? sender, EventArgs e)
        {
            
            MyButton btn = sender as MyButton;

            NormalBoard();
            // Nếu chọn đúng quân cờ của Turn đánh thì mới được chơi 
            if (btn.CHESS.isWhite == Turn || btn.LegalNextMove)
            {
                //Nếu nhấp vào ô di chuyển 
                if (btn.LegalNextMove)
                {
                    if (ChessMove(btn)) { MessageBox.Show(Turn == 1 ? "Trang WIN" : "Den Win");
                        Rematch();
                    }
                    else {
                        Turn = Turn == 1 ? 2 : 1;
                        LockButton(); }
                }
                else
                {
                    LockButton();
                    NextLegal(btn);
                    NextLegalDraw();
                    myChoose = btn;
                }
                
            }
            
        }
    }
}
