using UnityEngine;

namespace SnowBoarder
{
    /// <summary>
    ///     物理碰撞偵測 頭部碰撞器
    /// </summary>
    public class HeadDetectorController : MonoBehaviour
    {
        /**
         * 頭部
         */
        [SerializeField] private CircleCollider2D headCollider;

        /**
         * 頭部撞擊粒子
         */
        [SerializeField] private ParticleSystem impactParticle;

        /**
         * 遊戲結束字體
         */
        [SerializeField] private GameObject gameOverText;

        /// <summary>
        ///     監聽頭部撞擊地板,結束遊戲
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!GameCenter.Instance.ChangeGameState(GameType.GameOver)) return;
            if (!other.CompareTag(ObjectTagType.Ground.ToString())) return;
            impactParticle.Play(); //播放撞擊粒子
            gameOverText.SetActive(true); //顯示遊戲結束文字
            GroundController.Instance.StopGroundAction(); //停止地板移動
            headCollider.isTrigger = false; //關閉監聽器,打開物理
            Debug.Log("遊戲結束");
            StartCoroutine(GameCenter.Instance.DelayLoadSceneAction()); //重新加載場景
        }
    }
}
