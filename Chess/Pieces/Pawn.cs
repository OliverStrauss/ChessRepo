namespace MyGame.Peices;

public class Pawn: Peice
{
    public Pawn(Tile anchor, bool isBlack):base(anchor, isBlack)
    {
        
    }
    public override void Move()
    {
        
    }

    public override string ToString()
    {
        return "P";
    }
}