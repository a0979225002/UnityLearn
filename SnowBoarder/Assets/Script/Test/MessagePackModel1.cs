using System.Collections;
using System.Collections.Generic;
using MessagePack;

namespace SnowBoarder
{
// 標記 MessagePackObjectAttribute
    [MessagePackObject]
    public class MessagePackModel1
    {
        // Key 是序列化索引，对于版本控制非常重要。
        [Key(0)] public int Age { get; set; }

        [Key(1)] public int Age1 { get; set; }

        [Key(2)] public int Age2 { get; set; }
        [Key(3)] public int Age3 { get; set; }
        [Key(4)] public int Age4 { get; set; }
        [Key(5)] public int Age5 { get; set; }
        [Key(6)] public int Age6 { get; set; }
        [Key(7)] public int Age7 { get; set; }

        [Key(8)] public string FirstName { get; set; }

        [Key(9)] public string LastName { get; set; }

        [Key(10)] public ArrayList BigData { get; set; }

        [Key(11)] public Dictionary<string, string> BigMap { get; set; }


        // 公共成员中不序列化目标，标记IgnoreMemberAttribute
        [IgnoreMember] public string fullName => FirstName + LastName;
    }
}