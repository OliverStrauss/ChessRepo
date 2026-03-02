namespace MyGame;

public abstract class Peice
{
    private bool isBlack;
    private Tile anchor;
    private bool isTaken;


    public Peice(Tile anchor, bool isBlack)
    {
        this.anchor = anchor;
        this.isBlack = isBlack;
        isTaken = false;
        
    }

    public bool IsBlack()
    {
        return isBlack;
    }
    
    public bool IsTaken()
    {
        return IsTaken();
    }

    public abstract void Move();


}