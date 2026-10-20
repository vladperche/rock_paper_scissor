
using RockPaperScissor.Entities.Enums;
using RockPaperScissor.Entities.Resources;

namespace RockPaperScissor.Entities.Models;

public class PlayerMove
{
    private static Dictionary<ValidMove, List<ValidMove>> WinnerMove = new()
    {
        { ValidMove.Paper, new(){ ValidMove.Rock } },
        { ValidMove.Rock, new(){ ValidMove.Scissor } },
        { ValidMove.Scissor, new(){ ValidMove.Paper } }
    };

    private ValidMove _validMove;

    public PlayerMove(ValidMove validMove)
    {
        _validMove = validMove;
    }

    public ValidMove GetMove() => _validMove;

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static implicit operator ValidMove(PlayerMove move)
    {
        if(move == null)
            throw new ArgumentNullException(nameof(move));
        
        return move.GetMove();
    }

    public override bool Equals(object? obj)
    {
        if(obj == null)
            throw new ArgumentNullException(nameof(obj));
        
        if(!(obj is PlayerMove))
            return false;
        
        return _validMove == ((PlayerMove)obj).GetMove();
    }

    public static bool operator >(PlayerMove moveA, PlayerMove moveB)
    {
        if (!WinnerMove.ContainsKey(moveA))
        {
            throw new InvalidOperationException(string.Format(Messages.MOVE_NOT_DEFINED, moveA));
        }

        var result = WinnerMove[moveA].Contains(moveB);
        return result;
    }

    public static bool operator <(PlayerMove moveA, PlayerMove moveB)
    {
        if (!WinnerMove.ContainsKey(moveB))
        {
            throw new InvalidOperationException(string.Format(Messages.MOVE_NOT_DEFINED, moveB));
        }

        var result = WinnerMove[moveB].Contains(moveA);
        return result;
    }
}
