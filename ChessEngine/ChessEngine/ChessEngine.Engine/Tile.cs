using System;
using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

using MyGame;

namespace ChessEngine.Engine;

public class Tile
{
    Vector2 position;
    bool isBlack;
    private Peice peice;
    
    public Tile(int x, int y,bool isBlack)
    {
        position = new Vector2(x, y);
        this.isBlack = isBlack;

    }
    
    public Vector2 Position
    {
        get { return position; }
    }

    public void placePeice(Peice peice)
    {
        this.peice = peice;
    }

    public void removePeice()
    {
        peice = null;
    }

    public Peice getPeiceFromTile()
    {
        return peice;
    }

    public override string ToString()
    {
     
        String colStr = "";
        if (peice == null)
        {
            return $"|   |";
        }
        if (peice.IsWhite())
        {
            colStr = "W";
        }
        else
        {
            colStr = "B";
        }
        return $"|" + peice.ToString() +"," +colStr +"|" ;
    }
}