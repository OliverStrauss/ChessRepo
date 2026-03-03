using ChessEngine.Engine;
using ChessEngine.Library;

namespace MyGame.Peices;

public class Queen:Peice
{
    public Queen(Tile anchor, bool isBlack) : base(anchor, isBlack)
    {
        
    }

    public override List<Move>  generateMoves()
    {
        return null;
     //   maxSteps

    }
        
    public override string ToString()
    {
        return "Q";
    }
    
}