using System.Runtime.InteropServices.JavaScript;
using ChessEngine.Engine;
using MyGame.Peices;

namespace ChessEngine.Engine;

public class Board
{
    Tile[,] _board;
    
    private int turnCount;

    public Board()
    {
        _board = new Tile[8,8];
        initTile();
        initPeices();
        
        
    }

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
                currentColor= false;
            }
            else
            {
                currentColor = true;
            }
            
            for (int j = 0; j < 8; j++)
            {
                
                _board[i,j] = new Tile(i, j,currentColor);
                currentColor = !currentColor;
            }
        }
        
    }

    public void initPeices()
    {   
        //Place Pawns
        for (int i = 0; i < 8; i++)
        {
            _board[1,i].placePeice( new Pawn(_board[1,i],false));
        }
        for (int i = 0; i < 8; i++)
        {
            _board[6,i].placePeice( new Pawn(_board[6,i],true));
        } 
    }

    public override string ToString()
    {   
        string result = "";
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                
               result += _board[i,j].ToString();
            }

            result += "\n";
        }

        
       return result;
    }
    
}