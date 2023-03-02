using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
   
    public class GeneralStatistics : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_KillsText;
        [SerializeField] private TextMeshProUGUI m_ScoreText;
        [SerializeField] private TextMeshProUGUI m_TimeText;


        private void OnEnable()
        {
            var kill = 0;
            var score = 0;
            var time = 0;


            PlayerStatistics stat = GetComponent<PlayerStatistics>();

            m_KillsText.text = "������ �����������: " + stat.LoadKills();
            m_ScoreText.text = "������ �� �����: " + stat.LoadScore();
            m_TimeText.text = "������ �����: " + stat.LoadTime();
        }
    }
}