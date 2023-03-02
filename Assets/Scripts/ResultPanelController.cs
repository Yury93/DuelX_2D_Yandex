using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{

    public class ResultPanelController : SingletonBase<ResultPanelController>
    {
        [SerializeField] private TextMeshProUGUI m_Kills;
        [SerializeField] private TextMeshProUGUI m_Score;
        [SerializeField] private TextMeshProUGUI m_Time;
        
        [SerializeField] private TextMeshProUGUI m_Result;
     

        [SerializeField] private TextMeshProUGUI m_ButtonNextText;
        [SerializeField] private PauseMenuPanel m_pauseMenuPanel;
        
        private bool m_Success;

        private void Start()
        {
            gameObject.SetActive(false);
        }
        
        public void ShowResults(PlayerStatistics levelResults, bool success)
        {
            
          
            gameObject.SetActive(true);

            m_Success = success;

            m_Kills.text = "Уничтожено: "+ levelResults.numKills.ToString();
            m_Score.text = "Очков: " + levelResults.score.ToString();
            m_Time.text = "Время: " + levelResults.time.ToString();
          
          
            m_Result.text = success ? "Сделано!" : "Поражение";

            m_ButtonNextText.text = success ? "Продолжить" : "Рестарт";
            m_pauseMenuPanel.IsActiveButton = false;
            Time.timeScale = 0;
        }
        

        public void OnButtonNextAction()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
            m_pauseMenuPanel.IsActiveButton = true;
            if (m_Success == true)
            {
                print("win");
                LevelSequenceController.Instance.AdvanceLevel();
            }
            else
            {
                print("level lose");
                LevelSequenceController.Instance.RestartLevel();
            }
        }
    }
}
