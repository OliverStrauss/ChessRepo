using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using ChessEngine.Engine;
using ChessEngine.Library;
using MyGame;
using MyGame.Peices;

namespace ChessEngine.Engine;

public class Board
{
    Tile[,] _board;

    private int turnCount;

    bool whiteTurn = true;

    public Board()
    {
        _board = new Tile[8, 8];
        initTile();
        initPeices();

    }
    
    public bool WhiteTurn(){return whiteTurn;}

    public void swapTurn(){whiteTurn = !whiteTurn;}


    public int getTurnCount()
    {
        return turnCount;
    }

    public void initTile()
    {
        bool currentColor;

        for (int i = 0; i < 8; i++)
        {


            if (i % 2 == 0)
            {
                currentColor = false;
            }
            else
            {
                currentColor = true;
            }

            for (int j = 0; j < 8; j++)
            {

                _board[i, j] = new Tile(i, j, currentColor);
                currentColor = !currentColor;
            }
        }

    }

    public void initPeices()
    {
        //Place Pawns
        for (int i = 0; i < 8; i++)
        {
            _board[1, i].placePeice(new Pawn(_board[1, i], false));
        }

        for (int i = 0; i < 8; i++)
        {
            _board[6, i].placePeice(new Pawn(_board[6, i], true));
        }


        //ROOKS
        _board[0, 0].placePeice(new Rook(_board[0, 0], false)); // Passing tile 0,0 to a rook at 0,7

        _board[0, 7].placePeice(new Rook(_board[0, 0], false)); // Passing tile 0,0 to a rook at 0,7
        _board[7, 0].placePeice(new Rook(_board[7, 0], true)); // Passing tile 0,0 to a black rook
        _board[7, 7].placePeice(new Rook(_board[7, 7], true)); // Passing tile 0,0 to an

        //Knights
        //White Knights
        _board[0, 1].placePeice(new Knight(_board[0, 1], false));
        _board[0, 6].placePeice(new Knight(_board[0, 6], false));
        //Black Knights
        _board[7, 1].placePeice(new Knight(_board[7, 1], true));
        _board[7, 6].placePeice(new Knight(_board[7, 6], true));

        //Bishops
        //White Bishops
        _board[0, 2].placePeice(new Bishop(_board[0, 2], false));
        _board[0, 5].placePeice(new Bishop(_board[0, 5], false));
        //Black Bishops
        _board[7, 2].placePeice(new Bishop(_board[7, 2], true));
        _board[7, 5].placePeice(new Bishop(_board[7, 5], true));

        //Queens
        _board[0, 3].placePeice(new Queen(_board[0, 3], false));
        _board[7, 3].placePeice(new Queen(_board[7, 3], true));

        //Kings
        _board[0, 4].placePeice(new King(_board[0, 4], false));
        _board[7, 4].placePeice(new King(_board[7, 4], true));






    }

    public Peice getPeice(int i, int j)
    {
        return _board[i, j].getPeiceFromTile();
    }

    public void movePeice(int startX, int startY, int endX, int endY)
    {
        Peice peice = getPeice(startX, startY);

        peice.setTile(_board[endX, endY]);


        _board[startX, startY].removePeice();

        _board[endX, endY].placePeice(peice);
        whiteTurn = !whiteTurn;


    }

    public void printBoard()
    {
        string result = "";
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {

                result += _board[i, j].ToString();
            }

            result += "\n";
        }
    }

    public override string ToString()
    {
        string result = "";
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {

                result += _board[i, j].ToString();
            }

            result += "\n";
        }


        return result;
    }

}