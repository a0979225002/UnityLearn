using UnityEngine;
using UnityEngine.Serialization;

namespace  Car
{
    public class Driver : MonoBehaviour
    {
        /**
         * 旋轉速度
         */
        [SerializeField] private float rotateSpeed = 1f;

        /**
         * 移動速度
         */
        [SerializeField] private float moveSpeed = 0.1f;

        /**
         * 速率
         */
        [SerializeField] private float rate = 50;


        private void Start()
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        /// <summary>
        /// 獲取當前鍵盤 上下鍵按壓時間長度 0~1
        /// </summary>
        /// <returns></returns>
        private float GetUpAndDownListener()
        {
            float steerAmount = Input.GetAxis("Vertical") * moveSpeed;
            return  steerAmount * Time.deltaTime;
        }

        /// <summary>
        /// 獲取當前鍵盤 上下鍵按壓時間長度 0~1
        /// </summary>
        private float GetRightAndLeftListener()
        {
            //玩家操控
            //按壓長度取決轉向程度, 左鍵 -0.1~-0.99 按越久素質越大
            //按壓長度取決轉向程度, 右鍵 0.1 ~ 0.99 按越久素質越大
            float steerAmount = Input.GetAxis("Horizontal") * rotateSpeed;
            return steerAmount * Time.deltaTime * -1;
        }

        private void Update()
        {
            SimpleUpdateRotate(GetRightAndLeftListener(), GetUpAndDownListener());
            // UpdateRotate();
        }


        /// <summary>
        /// 簡易寫法 自體旋轉
        /// </summary>
        /// <param name="rotate">旋轉軸向,由User 按鍵監聽</param>
        /// <param name="move">移動方向</param>
        private void SimpleUpdateRotate(float rotate, float move)
        {
            transform.Rotate(0, 0, rotate);
            transform.Translate(0, move, 0);
        }

        /// <summary>
        ///     自體旋轉
        /// </summary>
        private void UpdateRotate()
        {
            // 计算从对象到旋转中心的向量
            var offset = transform.position - new Vector3(0, 0.5f, 0);
            // 应用旋转
            offset = Quaternion.Euler(0, 0, rotateSpeed * Time.deltaTime) * offset;
            // 更新位置
            transform.position = new Vector3(0, 0.5f, 0) + offset;
            // 如果你还想旋转物体自身，你可以使用 Quaternion.Euler 或者 transform.rotation
            transform.rotation *= Quaternion.Euler(0, 0, rate * Time.deltaTime);
        }
    }
}
