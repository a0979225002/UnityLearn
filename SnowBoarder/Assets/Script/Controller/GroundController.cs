
using UnityEngine;

namespace SnowBoarder
{
    public class GroundController : BaseSingleton<GroundController>
    {
        [SerializeField] private SurfaceEffector2D groundSurfaceEffector2D;


        /// <summary>
        /// 靜止地板自動移動
        /// </summary>
        public void StopGroundAction()
        {
            groundSurfaceEffector2D.speed = 0;          //移動速度歸零
            groundSurfaceEffector2D.forceScale = 0;     //移動力歸零
        }
    }
}
