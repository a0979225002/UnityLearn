using UnityEngine;

namespace SnowBoarder
{
    /// <summary>
    ///     選手控制器,操控選手動作
    /// </summary>
    public class AthleteController : MonoBehaviour
    {
        /**
         * 選手剛體
         */
        [SerializeField] private Rigidbody2D chara;

        /**
         * 拖尾粒子
         */
        [SerializeField] private ParticleSystem trailParticleSystem;

        /**
         * 額外增加的扭力值
         */
        [SerializeField] private float torqueAmount = 1;

        /**
         * 加速度
         */
        [SerializeField] private float accelerate = 500;


        private void Update()
        {
            KeyBordRotateListener();
            KeyBordSpeedToBoost();
        }

        /// <summary>
        ///     偵測當前滑板是否在雪地上,撥放拖尾粒子
        /// </summary>
        /// <param name="other"></param>
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag(ObjectTagType.Ground.ToString())) return;
            trailParticleSystem.Play();
        }

        /// <summary>
        ///     偵測當前滑板是否離開在雪地上,關閉粒子
        /// </summary>
        /// <param name="other"></param>
        private void OnCollisionExit2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag(ObjectTagType.Ground.ToString())) return;
            trailParticleSystem.Stop();
        }


        /// <summary>
        ///     按壓鍵盤增加速度
        /// </summary>
        private void KeyBordSpeedToBoost()
        {
            if (!GameCenter.Instance.CanControlPlayer()) return;
            // 按下空白鍵,增加速度
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var nowVelcity = chara.velocity.normalized;
                chara.AddForce(nowVelcity * accelerate);
            }
        }

        /// <summary>
        ///     監聽玩家左右鍵輸入,旋轉選手
        /// </summary>
        private void KeyBordRotateListener()
        {
            if (!GameCenter.Instance.CanControlPlayer()) return;
            // 按左右鍵,增加扭力
            var torque = Input.GetAxis("Horizontal");
            //施加扭力
            chara.AddTorque(torque * torqueAmount * -1);
        }
    }
}
