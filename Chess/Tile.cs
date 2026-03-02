using System;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.Xna.Framework;

namespace MyGame;

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

    public override string ToString()
    {

        String peiceStr = "";
        if (peice == null)
        {
           peiceStr = "";
        }
        else
        {
            peiceStr = peice.ToString();
        }
        String stringBlack = isBlack ? "B" : "W";
        return "(" + position.X + "," + position.Y + "," +  stringBlack
               + "," + peiceStr + ")";
    }
}