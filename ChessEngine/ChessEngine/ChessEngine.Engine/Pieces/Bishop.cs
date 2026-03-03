using ChessEngine.Engine;
using ChessEngine.Library;

namespace MyGame.Peices;

public class Bishop:Peice
{   
    
    
    public Bishop(Tile anchor, bool isBlack):base(anchor, isBlack)
    {
        
    }
    
    public override List<Move> generateMoves()
    {
        return null;
    }
    
    public override string ToString()
    {
        return "B";
    }
    
}