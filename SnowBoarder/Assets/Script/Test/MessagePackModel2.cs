using System.Collections;
using System.Collections.Generic;
using MessagePack;
using UnityEngine;

namespace SnowBoarder
{
// 標記 MessagePackObjectAttribute
    [MessagePackObject(true)]
    public class MessagePackModel2
    {
        // Key 是序列化索引，对于版本控制非常重要。
        [Key("Age")] public int Age { get; set; }

        [Key("Age1")] public int Age1 { get; set; }

        [Key("Age2")] public int Age2 { get; set; }
        [Key("Age3")] public int Age3 { get; set; }
        [Key("Age4")] public int Age4 { get; set; }
        [Key("Age5")] public int Age5 { get; set; }
        [Key("Age6")] public int Age6 { get; set; }
        [Key("Age7")] public int Age7 { get; set; }

        [Key("FirstName")] public string FirstName { get; set; }

        [Key("LastName")] public string LastName { get; set; }

        [Key("BigData")] public ArrayList BigData { get; set; }

        [Key("BigMap")] public Dictionary<string, string> BigMap { get; set; }


        // 公共成员中不序列化目标，标记IgnoreMemberAttribute
        [IgnoreMember]
        public string fullName
        {
            get { return FirstName + LastName; }
        }
    }
}
