using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnowBoarder
{
    /// <summary>
    /// 遊戲狀態
    /// </summary>
    public enum GameType
    {
        /**
         * 遊玩中
         */
        Playing,

        /**
         * 結束遊戲
         */
        Finish,

        /**
         * 遊戲失敗
         */
        GameOver
    }

    /// <summary>
    /// 遊戲中心
    /// </summary>
    public class GameCenter : BaseSingleton<GameCenter>
    {
        /// <summary>
        ///     結束的時間
        /// </summary>
        [SerializeField] private float finishDelayTime;

        /// <summary>
        ///     遊戲狀態
        /// </summary>
        private GameType _gameState = GameType.Playing;

        private void Awake()
        {
            _gameState = GameType.Playing;
        }

        /// <summary>
        ///     是否可以操控玩家
        /// </summary>
        public bool CanControlPlayer()
        {
            if (_gameState == GameType.Finish) return false;
            if (_gameState == GameType.GameOver) return false;
            return true;
        }

        /// <summary>
        ///     改變當前狀態
        /// </summary>
        /// <param name="state"></param>
        public bool ChangeGameState(GameType state)
        {
            var canChangeState = CheckGameProcess(state);
            if (canChangeState) _gameState = state;

            return canChangeState;
        }

        /// <summary>
        ///     當前狀態是否能夠改變
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool CheckGameProcess(GameType state)
        {
            if (_gameState == state) return false; //狀態無須改變

            if (_gameState == GameType.Finish && state == GameType.GameOver) return false; //當前狀態為結束,無法跳轉為遊戲失敗

            if (_gameState == GameType.GameOver && state == GameType.Finish) return false; //當前狀態為游係失敗,無法跳轉為結束

            return true;
        }

        /// <summary>
        ///     延遲重新加載場景
        /// </summary>
        /// <returns></returns>
        public IEnumerator DelayLoadSceneAction()
        {
            yield return new WaitForSeconds(finishDelayTime);
            ReLoadScene();
            Debug.Log("遊戲結束 自動重新開始");
        }


        /// <summary>
        ///     重新加載場景,重新開始遊戲
        /// </summary>
        public void ReLoadScene()
        {
            SceneManager.LoadScene("SnowBoarderGame");
        }
    }
}
