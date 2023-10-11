using System.Collections;
using System.Collections.Generic;
using Script.Global;
using UnityEngine;

namespace SnowBoarder
{
    public class JsonPackTest
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <returns></returns>
        private string Serialization(int quantity, string name)
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
                BigMap = AddMayData(quantity),
            };
            return JsonUtility.ToJson(mc);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private T Deserialization<T>(string data)
        {
            var d = JsonUtility.FromJson<T>(data.ToString());
            return d;
        }

        /// <summary>
        /// 動態添加Map 數據
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private Dictionary<string, string> AddMayData(int quantity)
        {
            var map = new Dictionary<string, string>();
            for (var i = 0; i < quantity; i++)
            {
                map.Add(i.ToString(), i.ToString());
            }

            return map;
        }

        /// <summary>
        /// 動態添加 Array 數據
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private ArrayList AddArrayData(int quantity)
        {
            var list = new ArrayList();
            for (var i = 0; i < quantity; i++)
            {
                list.Add(i);
            }

            return list;
        }

        private void SerializationTime()
        {
            float time1 = 0;
            float time2 = 0;
            for (var i = 0; i < 100; i++)
            {
                var a1 = Utils.TestFunctionTime(() => { return Serialization(100, "Json序列化"); });
                Deserialization<MessagePackModel1>(a1.Data);
                time1+= a1.Time;
            }
            Debug.Log("==========Adam Json序列化 : 時間" + time1/100 + " =========== 數單據數量 :" + 100 +" =========== 總單數 :" + 100);

            for (var i = 0; i < 100; i++)
            {
                var a1 = Utils.TestFunctionTime(() => { return Serialization(100000, "Json序列化"); });
                Deserialization<MessagePackModel1>(a1.Data);
                time2+= a1.Time;
            }
            Debug.Log("==========Adam Json序列化 : 時間" + time2/100 + " =========== 數單據數量 :" + 100000 +" =========== 總單數 :" + 100);

        }

        private void DeserializationTime()
        {

            float time1 = 0;
            float time2 = 0;
            for (var i = 0; i < 100; i++)
            {
                var a1 =  Serialization(100, "Json反序列化");
                var test = Utils.TestFunctionTime(() => { return Deserialization<MessagePackModel1>(a1); });
                time1+= test.Time;
            }
            Debug.Log("==========Adam Json反序列化 : 時間" + time1/100 + " =========== 數單據數量 :" + 100 +" =========== 總單數 :" + 100);

            for (var i = 0; i < 100; i++)
            {
                var a1 =  Serialization(100000, "Json反序列化");
                var test = Utils.TestFunctionTime(() => { return Deserialization<MessagePackModel1>(a1); });
                time2+= test.Time;
            }
            Debug.Log("==========Adam Json反序列化 : 時間" + time2/100 + " =========== 數單據數量 :" + 100000+" =========== 總單數 :" + 100);
        }


        public void Run()
        {
            SerializationTime();//序列化時間
            // DeserializationTime(); //反序列化時間
        }
    }
}
