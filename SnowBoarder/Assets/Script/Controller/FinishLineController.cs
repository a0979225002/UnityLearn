using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnowBoarder
{
    /// <summary>
    /// 結束遊戲控制器判定
    /// </summary>
    public class FinishLineController : MonoBehaviour
    {
        /// <summary>
        /// 生命週期只能一次
        /// </summary>
        private bool _isOnece;

        private void Awake()
        {
            _isOnece = true;
        }

        /// <summary>
        /// 碰撞檢測,玩家碰撞到旗子結束遊戲
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_isOnece) return;
            if (!other.CompareTag(ObjectTagType.Player.ToString())) return;
            _isOnece = false;
            GroundController.Instance.StopGroundAction();
            StartCoroutine(DelayLoadSceneAction());
        }

        /// <summary>
        /// 延遲重新加載場景
        /// </summary>
        /// <returns></returns>
        private IEnumerator DelayLoadSceneAction()
        {
            yield return new WaitForSeconds(2f);
            ReLoadScene();
            Debug.Log("遊戲結束 自動重新開始");
        }


        /// <summary>
        /// 重新加載場景,重新開始遊戲
        /// </summary>
        public void ReLoadScene()
        {
            SceneManager.LoadScene("SnowBoarderGame");
        }
    }
}
