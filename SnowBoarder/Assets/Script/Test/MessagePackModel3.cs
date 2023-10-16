using System.Collections.Generic;
using MessagePack;

namespace SnowBoarder
{
    [MessagePackObject]
    public class IWinLine
    {
        [Key("lineIndex")] public int LineIndex { get; set; }

        [Key("lineCount")] public int LineCount { get; set; }

        [Key("winPoint")] public float WinPoint { get; set; }

        [Key("winSymbolID")] public int WinSymbolID { get; set; }

        [Key("winPosList")] public int[] WinPosList { get; set; }
    }

    [MessagePackObject]
    public class MessagePackModel3
    {
        [Key("gameType")] public int GameType { get; set; }

        [Key("finalSymbolList")] public int[] FinalSymbolList { get; set; }

        [Key("winLines")] public IWinLine[] WinLines { get; set; }

        [Key("totalWinPoint")] public float TotalWinPoint { get; set; }

        [Key("strMap")] public Dictionary<string, string> StrMap { get; set; }

        // [Key(5)] public Dictionary<int, string> IntMap { get; set; }
        //
        // [Key(6)] public Dictionary<int, IWinLine> ObjMap { get; set; }
    }
}