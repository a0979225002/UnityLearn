using System;
using UnityEngine;

namespace Car
{
    public class Collision : MonoBehaviour
    {
        /// <summary>
        /// 2D Box Collider 開啟 Is Trigger 監聽 (射線檢測
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Adam 碰撞中 Is Trigger "+other);
        }

        /// <summary>
        /// 內部是件 ( 当传入碰撞体与该对象的碰撞体接触时发送（仅限 2D 物理）。 此函数可以是协同程序。)
        /// </summary>
        /// <param name="other"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void OnCollisionEnter2D(Collision2D other)
        {

            Debug.Log("Adam 碰撞中"+other);
        }
    }
}
