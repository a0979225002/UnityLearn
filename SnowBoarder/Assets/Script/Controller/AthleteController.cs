using System;
using System.Collections.Generic;
using UnityEngine;

namespace SnowBoarder
{

    /// <summary>
    /// 選手控制器,操控選手動作
    /// </summary>
    public class AthleteController : MonoBehaviour
    {
        /**
         * 選手剛體
         */
        [SerializeField] private Rigidbody2D chara;

        /**
         * 額外增加的扭力值
         */
        [SerializeField] private float torqueAmount = 1;

        private void Awake()
        {

        }

        /// <summary>
        ///
        /// </summary>
        private void KeyBordListener()
        {
            // 按左右鍵,增加扭力
            var torque = Input.GetAxis("Horizontal");

            //施加扭力
            chara.AddTorque(torque * torqueAmount * -1);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
        }

        private void Update()
        {
            KeyBordListener();
        }
    }
}
