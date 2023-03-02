using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShooter
{
    public class LevelSequenceController : SingletonBase<LevelSequenceController>
    {
        public static string MainMenuSceneNickname = "main_menu";
        public Episode CurrentEpisode { get; private set; }
        public int CurrentLevel { get; private set; }
        public bool LastLevelResult{get;private set;}
        public PlayerStatistics PlayerStatistic { get; private set; }
        public static SpaceShip PlayerShip { get; set; }


        public void StartEpisode(Episode e)
        {
            CurrentEpisode = e;
            CurrentLevel = 0;

            PlayerStatistic = GetComponent<PlayerStatistics>();

            PlayerStatistic.Reset();
            SceneManager.LoadScene(e.Levels[CurrentLevel]);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
            PlayerStatistic.SaveStatistic(Player.Instance.Score, Player.Instance.NumKills, (int)LevelController.Instance.LevelTime);
        }

        public void FinishCurrentLevel(bool success)
        {
            LastLevelResult = success;
            SetFieldsLevelStatisctic();
            
            ResultPanelController.Instance.ShowResults(PlayerStatistic, success);

            PlayerStatistic.SaveStatistic(Player.Instance.Score, Player.Instance.NumKills, (int)LevelController.Instance.LevelTime);
        }

        public void AdvanceLevel()
        {
            CurrentLevel++;
            PlayerStatistic.SaveStatistic(Player.Instance.Score, Player.Instance.NumKills, (int)LevelController.Instance.LevelTime);
            if (CurrentEpisode.Levels.Length <= CurrentLevel)
            {
                SceneManager.LoadScene(MainMenuSceneNickname);
            }
            else
            {
                SceneManager.LoadScene(CurrentEpisode.Levels[CurrentLevel]);
            }

        }
      
        private void SetFieldsLevelStatisctic()
        {
            PlayerStatistic.score = Player.Instance.Score;
            PlayerStatistic.numKills = Player.Instance.NumKills;
            PlayerStatistic.time = (int)LevelController.Instance.LevelTime;
        }
       
    }
}