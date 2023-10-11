using System;
using SnowBoarder;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Center
{
    public class NetPacketCenter : MonoBehaviour
    {
        [SerializeField] private Button myButton;
        [SerializeField] private bool serializationType;

        private void Start()
        {
            // MessageDateTest();
            // JsonDateTest();
        }

        /// <summary>
        ///
        /// </summary>
        private void MessageDateTest()
        {
            var test = new MessagePackTest();
            test.Run();
        }

        /// <summary>
        ///
        /// </summary>
        private void JsonDateTest()
        {
            var test = new JsonPackTest();
            test.Run();
        }

        // public MainCenter()
        // {
        //     Debug.Log("建構式執行...");
        //     var test = new Test();
        //     test.Run();
        // }
    }
}
