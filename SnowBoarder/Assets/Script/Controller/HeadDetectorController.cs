using System;
using UnityEngine;

namespace SnowBoarder
{
    /// <summary>
    /// 物理碰撞偵測 頭部碰撞器
    /// </summary>
    public class HeadDetectorController : MonoBehaviour
    {
        /**
         * 頭部
         */
        [SerializeField] private CircleCollider2D headCollider;

        /// <summary>
        /// 監聽頭部撞擊地板,結束遊戲
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(ObjectTagType.Ground.ToString())) return;
            GroundController.Instance.StopGroundAction();
            headCollider.isTrigger = false;
            Debug.Log("遊戲結束");
        }
    }
}
