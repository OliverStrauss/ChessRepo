using System.Numerics;
using MyGame;
using MyGame.Peices;
using System.Collections.Generic;

namespace ChessEngine.Library;

public class Move
{
    private Vector2 start;
    private Vector2 end;
    public Move(Vector2 startPos,Vector2 endPos){
        start = startPos;
        end = endPos;
        
    }

    public Vector2 getEndPos()
    {
        return end;
    }
    public Vector2 getStartPos()
    {
        return start;
    }

   
    

   
  

    private static bool IsOnBoard(Vector2 pos)
    {
        return pos.X >= 0 && pos.X < 8 && pos.Y >= 0 && pos.Y < 8;
    }
}