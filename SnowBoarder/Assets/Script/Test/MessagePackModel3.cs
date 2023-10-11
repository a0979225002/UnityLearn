using System.Collections.Generic;
using MessagePack;

namespace SnowBoarder
{
    [MessagePackObject()]
    public class IWinLine
    {
        [Key(0)]
        public int LineIndex { get; set; }

        [Key(1)]
        public int LineCount { get; set; }

        [Key(2)]
        public float WinPoint { get; set; }

        [Key(3)]
        public int WinSymbolID { get; set; }

        [Key(4)]
        public int[] WinPosList { get; set; }
    }

    [MessagePackObject()]
    public class MessagePackModel3
    {
        [Key(0)]
        public int GameType { get; set; }

        [Key(1)]
        public int[] FinalSymbolList { get; set; }

        [Key(2)]
        public IWinLine[] WinLineList { get; set; }

        [Key(3)]
        public float TotalWinPoint { get; set; }

        [Key(4)]
        public Dictionary<string, string> StrMap { get; set; }

        [Key(5)]
        public Dictionary<int, string> IntMap { get; set; }

        [Key(6)]
        public Dictionary<int, IWinLine> ObjMap { get; set; }

    }
}
