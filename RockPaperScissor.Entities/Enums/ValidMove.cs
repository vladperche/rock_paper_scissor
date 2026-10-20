
using System.ComponentModel;

namespace RockPaperScissor.Entities.Enums;

public enum ValidMove
{
    [Description("Rock")]
    Rock,
    [Description("Paper")]
    Paper,
    [Description("Scissor")]
    Scissor
}

public static class ValidMoveExtension
{
    public static string ConvertToString(this Enum move)
    {
        if(move == null)
            return string.Empty;

        var moveType = move.GetType();
        if(moveType == null)
            return string.Empty;

        var moveName = Enum.GetName(moveType, move);
        return moveName ?? string.Empty;
    }
}
