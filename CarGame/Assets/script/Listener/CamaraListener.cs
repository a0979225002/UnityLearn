using System;
using UnityEngine;
using Object = System.Object;

namespace Car
{
    public class CamaraListener : MonoBehaviour
    {
        [SerializeField] private Transform carObject;

        [SerializeField] private Transform camaraObject;

        private const float Def = 0.001f;

        private float _m = Def;

        private bool CheckPosition()
        {
            var position = camaraObject.localPosition;
            var camaraObjectX = position.x;
            var camaraObjectY = position.y;
            var localPosition = carObject.localPosition;
            var carObjectX = localPosition.x;
            var carObjectY = localPosition.y;
            return Math.Abs(camaraObjectX - carObjectX) > 0.001f  ||Math.Abs(camaraObjectY - carObjectY) > 0.001f ;
        }

        private Vector3 _before;

        private Vector3 _after;

        private Vector3 rate()
        {
            var a =(_before - _after) / _m;
            return a;
        }

        private void Update()
        {

            if (CheckPosition())
            {
                Debug.Log("Adam 有來嗎....");
                if (_m < 1)
                {
                    _m += Def;
                }

                var localPosition = carObject.localPosition;
                var v2 = new Vector2(localPosition.x, localPosition.y)/_m;
                _before = camaraObject.localPosition;
                camaraObject.localPosition = (new Vector3(v2.x,v2.y,localPosition.z) + new Vector3(0, 0, -100));
                _after = localPosition;
            }
            else
            {
                Debug.Log("Adam 有來嗎....02");

                _m = Def;
                camaraObject.localPosition = ((carObject.localPosition) + new Vector3(0, 0, -100));
                _before = camaraObject.localPosition;
                _after = camaraObject.localPosition;
            }
        }
    }
}
