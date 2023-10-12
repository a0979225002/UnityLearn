using UnityEngine;
namespace SnowBoarder
{
    /// <summary>
    /// 選手控制器,操控選手動作
    /// </summary>
    public class AthleteController : BaseSingleton<AthleteController>
    {
        /**
         * 選手剛體
         */
        [SerializeField] private Rigidbody2D chara;

        /**
         * 額外增加的扭力值
         */
        [SerializeField] private float torqueAmount = 1;


        private void Update()
        {
            KeyBordListener();
        }

        /// <summary>
        /// 監聽玩家左右鍵輸入,旋轉選手
        /// </summary>
        private void KeyBordListener()
        {
            // 按左右鍵,增加扭力
            var torque = Input.GetAxis("Horizontal");

            //施加扭力
            chara.AddTorque(torque * torqueAmount * -1);
        }
    }
}
