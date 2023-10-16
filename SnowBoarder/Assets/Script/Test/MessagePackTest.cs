using System;
using System.Collections;
using System.Collections.Generic;
using MessagePack;
using UnityEngine;
using ZstdNet;

namespace SnowBoarder
{
    public class MessagePackTest
    {
        /// <summary>
        ///     序列化
        /// </summary>
        /// <returns></returns>
        private byte[] Serialization(int quantity, string name)
        {
            Debug.Log("==========數據名稱 : " + name + " =========== 數據數量 " + quantity);
            var mc = new MessagePackModel1
            {
                Age = 99,
                Age1 = 99,
                Age2 = 99,
                Age3 = 99,
                Age4 = 99,
                Age5 = 99,
                Age6 = 99,
                Age7 = 99,
                FirstName = "hoge",
                LastName = "huga",
                BigData = AddArrayData(quantity),
                BigMap = AddMayData(quantity)
            };
            return MessagePackSerializer.Serialize(mc);
        }


        /// <summary>
        ///     序列化
        /// </summary>
        /// <returns></returns>
        private byte[] Serialization2(int quantity, string name)
        {
            Debug.Log("==========數據名稱 : " + name + " =========== 數據數量 " + quantity);
            var mc = new MessagePackModel2
            {
                Age = 99,
                Age1 = 99,
                Age2 = 99,
                Age3 = 99,
                Age4 = 99,
                Age5 = 99,
                Age6 = 99,
                Age7 = 99,
                FirstName = "hoge",
                LastName = "huga",
                BigData = AddArrayData(quantity),
                BigMap = AddMayData(quantity)
            };
            return MessagePackSerializer.Serialize(mc);
        }

        /// <summary>
        ///     反序列化
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T Deserialization<T>(byte[] data)
        {
            var d = MessagePackSerializer.Deserialize<T>(data);
            return d;
        }

        /// <summary>
        ///     動態添加Map 數據
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private Dictionary<string, string> AddMayData(int quantity)
        {
            var map = new Dictionary<string, string>();
            for (var i = 0; i < quantity; i++) map.Add(i.ToString(), i.ToString());

            return map;
        }

        /// <summary>
        ///     動態添加 Array 數據
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private ArrayList AddArrayData(int quantity)
        {
            var list = new ArrayList();
            for (var i = 0; i < quantity; i++) list.Add(i);
            return list;
        }

        public void TestShan()
        {
            var a = Convert.FromBase64String(
                "hahnYW1lVHlwZdEXg69maW5hbFN5bWJvbExpc3SYAQIDBAUGBwiod2luTGluZXOThKlsaW5lSW5kZXgBqHdpblBvaW50y0DH3wAAAAAAq3dpblN5bWJvbElECqp3aW5Qb3NMaXN0mAECAwQFBgcIhKlsaW5lSW5kZXgBqHdpblBvaW50y0DH3wAAAAAAq3dpblN5bWJvbElECqp3aW5Qb3NMaXN0mAECAwQFBgcIhKlsaW5lSW5kZXgBqHdpblBvaW50y0DH3wAAAAAAq3dpblN5bWJvbElECqp3aW5Qb3NMaXN0mAECAwQFBgcIrXRvdGFsV2luUG9pbnTLQMgagAAAAACmc3RyTWFwg6Rqc29upGpzb26lcHJvdG+lcHJvdG+nbXNncGFja6dtc2dwYWNr");

            var data2 = MessagePackSerializer.ConvertToJson(a);

            var data = MessagePackSerializer.Deserialize<MessagePackModel3>(a);
            Debug.Log(data2);
            Debug.Log(data);
            Debug.Log("結束");
            // ZstdNetTest();
        }

        /// <summary>
        ///     壓縮,解壓縮測試
        /// </summary>
        private void ZstdNetTest()
        {
            var a = Convert.FromBase64String(
                "hahnYW1lVHlwZdEXg69maW5hbFN5bWJvbExpc3SYAQIDBAUGBwiod2luTGluZXOThKlsaW5lSW5kZXgBqHdpblBvaW50y0DH3wAAAAAAq3dpblN5bWJvbElECqp3aW5Qb3NMaXN0mAECAwQFBgcIhKlsaW5lSW5kZXgBqHdpblBvaW50y0DH3wAAAAAAq3dpblN5bWJvbElECqp3aW5Qb3NMaXN0mAECAwQFBgcIhKlsaW5lSW5kZXgBqHdpblBvaW50y0DH3wAAAAAAq3dpblN5bWJvbElECqp3aW5Qb3NMaXN0mAECAwQFBgcIrXRvdGFsV2luUG9pbnTLQMgagAAAAACmc3RyTWFwg6Rqc29upGpzb26lcHJvdG+lcHJvdG+nbXNncGFja6dtc2dwYWNr");

            //壓縮
            var options = new CompressionOptions(a, 5);
            var compressor = new Compressor(options);
            var wrap = compressor.Wrap(a);

            //解壓縮
            var decompressor = new Decompressor();
            var unzstd = decompressor.Unwrap(wrap);
            var data2 = MessagePackSerializer.ConvertToJson(unzstd);
        }


        private void SerializationTime()
        {
            // var a1_1 = Utils.TestFunctionTime<byte[]>(() => { return Serialization(100, "序列化 Array 格式");});
            // Deserialization<MessagePackModel1>(a1_1);
            //
            //
            // var a1_2 = Utils.TestFunctionTime<byte[]>(() => { return Serialization2(100, "序列化 Map 格式");});
            // Deserialization<MessagePackModel2>(a1_2);
            //
            // var a2_1 = Utils.TestFunctionTime<byte[]>(() => { return Serialization(100, "序列化 Array 格式");});
            // Deserialization<MessagePackModel1>(a2_1);
            //
            // var a2_2 = Utils.TestFunctionTime<byte[]>(() => { return Serialization2(100, "序列化 Map 格式");});
            // Deserialization<MessagePackModel2>(a2_2);
            //
            // var a3_1 = Utils.TestFunctionTime<byte[]>(() => { return Serialization(100, "序列化 Array 格式");});
            // Deserialization<MessagePackModel1>(a3_1);
            //
            // var a3_2 = Utils.TestFunctionTime<byte[]>(() => { return Serialization2(100000, "序列化 Map 格式");});
            // Deserialization<MessagePackModel2>(a3_2);
            //
            // var a4_1 = Utils.TestFunctionTime<byte[]>(() => { return Serialization(100000, "序列化 Array 格式");});
            // Deserialization<MessagePackModel1>(a4_1);
            //
            // var a4_2 = Utils.TestFunctionTime<byte[]>(() => { return Serialization2(100000, "序列化 Map 格式");});
            // Deserialization<MessagePackModel2>(a4_2);
        }

        private void DeserializationTime()
        {
            // var a1_1 = Serialization(100,"反序列化 Array 格式");
            // var b1_1 = Utils.TestFunctionTime(() => { return Deserialization<MessagePackModel1>(a1_1); });
            //
            // var a1_2 = Serialization2(100,"反序列化 Map 格式");
            // var b1_2 = Utils.TestFunctionTime(() => { return Deserialization<MessagePackModel2>(a1_2); });
            //
            // var a2_1 = Serialization(100,"反序列化 Array 格式");
            // var b2_1 = Utils.TestFunctionTime(() => { return Deserialization<MessagePackModel1>(a2_1); });
            //
            // var a2_2 = Serialization2(100,"反序列化 Map 格式");
            // var b2_2 = Utils.TestFunctionTime(() => { return Deserialization<MessagePackModel2>(a1_2); });
            //
            // var a3_1 = Serialization(100000,"反序列化 Array 格式");
            // var b3_1 = Utils.TestFunctionTime(() => { return Deserialization<MessagePackModel1>(a3_1); });
            //
            // var a3_2 = Serialization2(100000,"反序列化 Map 格式");
            // var b3_2 = Utils.TestFunctionTime(() => { return Deserialization<MessagePackModel2>(a3_2); });
            //
            // var a4_1 = Serialization(100000,"反序列化 Array 格式");
            // var b4_1 = Utils.TestFunctionTime(() => { return Deserialization<MessagePackModel1>(a4_1); });
            //
            // var a4_2 = Serialization2(100000,"反序列化 Map 格式");
            // var b4_2 = Utils.TestFunctionTime(() => { return Deserialization<MessagePackModel2>(a4_2); });
        }

        public void Run()
        {
            // ZstdNetTest();
            TestShan(); //測試 base64 封包

            // SerializationTime();//序列化時間

            // DeserializationTime();//反序列化時間
        }
    }
}