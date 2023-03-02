using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace SpaceShooter
{
    public class PauseMenuPanel : MonoBehaviour
    {
        public bool IsActiveButton { get; set; }
        private void Start()
        {
            gameObject.SetActive(false);
            IsActiveButton = true;
        }

        public void OnButtonShowPause()
        {
            if (IsActiveButton == false) return;
            Time.timeScale = 0;
            gameObject.SetActive(true);
        }
        public void OnButtonContinue()
        {
            Time.timeScale = 1;
            gameObject.SetActive(false);
        }

        public void OnButtonMainMenu()
        {
            Time.timeScale = 1;
            PlayerStatistics PlayerStatistic = FindObjectOfType<PlayerStatistics>();
            PlayerStatistic.SaveStatistic(Player.Instance.Score, Player.Instance.NumKills, (int)LevelController.Instance.LevelTime);
            gameObject.SetActive(false);
            SceneManager.LoadScene(LevelSequenceController.MainMenuSceneNickname);

        }
    }
}
