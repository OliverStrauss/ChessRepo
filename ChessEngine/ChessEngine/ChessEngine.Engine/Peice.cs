using ChessEngine.Engine;
using ChessEngine.Library;

namespace MyGame;

public abstract class Peice
{
    private bool isWhite;
    
    private Tile _tile;
    private bool isTaken;


    public Peice(Tile anchor, bool isWhite)
    {
        this._tile = anchor;
        this.isWhite = isWhite;
        isTaken = false;
        
    }

    public bool IsWhite()
    {
        return isWhite;
    }
    
    public bool IsTaken()
    {
        return IsTaken();
    }
    public Tile GetTile()
    {
        return _tile;
    }

    public void setTile(Tile tile)
    {
        this._tile = tile;
    }

    public abstract List<Move> generateMoves();


}