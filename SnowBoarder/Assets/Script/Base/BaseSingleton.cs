using UnityEngine;

namespace SnowBoarder
{
    public class BaseSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static readonly object _lockBackObject = new();

        private static T _instance;

        public static T Instance => LockToGetInstance();

        private void Awake()
        {
            if (_instance == null) _instance = gameObject.GetComponent<T>();
        }

        private void OnDestroy()
        {
            _instance = null;
        }

        /// <summary>
        ///     獲取同步的單利
        /// </summary>
        /// <returns> This </returns>
        private static T LockToGetInstance()
        {
            lock (_lockBackObject)
            {
                if (_instance == null)
                {
                    // 在場景中尋找該物件
                    _instance = FindObjectOfType<T>();
                    // 如果場景中沒有該物件,則創建一個
                    if (_instance == null)
                    {
                        var node = new GameObject(typeof(T).ToString());
                        _instance = node.AddComponent<T>();
                        DontDestroyOnLoad(_instance.gameObject);
                    }
                }

                return _instance;
            }
        }
    }
}