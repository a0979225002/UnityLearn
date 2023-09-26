using UnityEngine;

namespace  Car
{
    public class CarController : MonoBehaviour
    {
        private Object car = null;

        private Object a = null;


        private Object b = null;

        private Object apple = null;

        private void Awake()
        {
            OnCreate();
        }

        private void OnCreate()
        {
            car = null;
        }
    }
}
