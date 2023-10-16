using UnityEngine;

namespace SnowBoarder
{
    /// <summary>
    ///     結束遊戲控制器判定
    /// </summary>
    public class FinishLineController : MonoBehaviour
    {
        /**
         * 結束的粒子特效
         */
        [SerializeField] private ParticleSystem finishParticle;

        /**
         * 遊戲通關字體
         */
        [SerializeField] private GameObject gameClearanceText;

        /// <summary>
        ///     碰撞檢測,玩家碰撞到旗子結束遊戲
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!GameCenter.Instance.ChangeGameState(GameType.Finish)) return;
            if (!other.CompareTag(ObjectTagType.Player.ToString())) return;
            FinishParticleListenerPosition(other);
            gameClearanceText.SetActive(true);
            GroundController.Instance.StopGroundAction();
            StartCoroutine(GameCenter.Instance.DelayLoadSceneAction());
        }

        /// <summary>
        ///     修正當前玩家的Y軸位置補正當前粒子顯示位置
        /// </summary>
        /// <param name="other"></param>
        private void FinishParticleListenerPosition(Collider2D other)
        {
            var finishParticleTransform = finishParticle.transform; //結束粒子
            var athletePosition = other.transform.position; //當前運動員位置
            var finishParticlePosition = finishParticleTransform.position; //拿取當前粒子位置
            var newPosition =
                new Vector3(finishParticlePosition.x, athletePosition.y, finishParticlePosition.z); //新的位置,比對當前運動員高度
            finishParticleTransform.position = newPosition; //更新位置
            finishParticle.Play();
        }
    }
}
