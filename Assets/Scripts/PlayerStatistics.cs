using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShooter
{
    public class PlayerStatistics : MonoBehaviour
    {
        public int numKills;
        public int score;
        public int time;

        public const string keyNumKills = "numKills";
        public const string keyScore = "score";
        public const string keyTime = "time";

        public void Reset()
        {
            numKills = 0;
            score = 0;
            time = 0;
        }
        public void SaveStatistic(int score, int numKills, int time)
        {
                if(PlayerPrefs.GetInt(keyNumKills) < numKills)
                {
                    PlayerPrefs.SetInt(keyNumKills, numKills);
                }
            
           
                if (PlayerPrefs.GetInt(keyScore) < score)
                {
                    PlayerPrefs.SetInt(keyScore, score);
                }
            
            
                if (PlayerPrefs.GetInt(keyTime) < time)
                {
                    PlayerPrefs.SetInt(keyTime, time);
                }
            
        }
        public int LoadKills()
        {
            if (PlayerPrefs.HasKey(keyNumKills))
            {
                int kill = PlayerPrefs.GetInt(keyNumKills);
                return kill;
            }
            else
            {
                return 0;
            }
        }
        public int LoadScore()
        {
            if (PlayerPrefs.HasKey(keyScore))
            {
                return PlayerPrefs.GetInt(keyScore);
            }
            else
            {
                return 0;
            }
        }
        public int LoadTime()
        {
            if (PlayerPrefs.HasKey(keyTime))
            {
                return PlayerPrefs.GetInt(keyTime);
            }
            else
            {
                return 0;
            }
        }
    }
}
