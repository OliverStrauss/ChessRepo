using ChessEngine.Engine;
using ChessEngine.Library;

namespace MyGame.Peices;

public class Knight: Peice

{
    public Knight(Tile anchor, bool color):base(anchor, color)
    {
        
    }

    public override List<Move>  generateMoves()
    {
        return null;
    }
    
    public override string ToString()
    {
        return "H";
    }
}