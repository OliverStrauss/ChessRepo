using Microsoft.Xna.Framework;

namespace MyGame;

public class Tile
{
    Vector2 position;
    bool isBlack;
    public Tile(int x, int y,bool isBlack)
    {
        position = new Vector2(x, y);
        this.isBlack = isBlack;

    }
    
    public Vector2 Position
    {
        get { return position; }
    }

    public override string ToString()
    {
        return "(" + position.X + "," + position.Y + "," +  isBlack + ")";
    }
}