using System.Runtime.InteropServices.JavaScript;

namespace MyGame;

public class Board
{
    Tile[,] _board;
    private int turnCount;

    public Board()
    {
        _board = new Tile[8,8];
        initTile();
        
        
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