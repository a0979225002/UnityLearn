using System;
using UnityEngine;
using UnityEngine.Pool;
using Object = System.Object;

namespace SnowBoarder
{
    /// <summary>
    /// 結束遊戲控制器判定
    /// </summary>
    public class FinishLineController : MonoBehaviour
    {

        /// <summary>
        /// 碰撞檢測
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("有來嗎?");
        }
    }
}
