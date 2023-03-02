using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


namespace SpaceShooter 
{
    public class Player : SingletonBase<Player>
    {
        [SerializeField] private int m_NumLives;

        [SerializeField] private SpaceShip m_Ship;
        public SpaceShip ActiveShip => m_Ship;

        [SerializeField] private GameObject m_PlayerShipPrefab;

        [SerializeField] private CameraController m_CameraController;

        [SerializeField] private MovementController m_MovementController;
        [SerializeField] private TextMeshProUGUI hpText;
        private Coroutine corRespawn;
        protected override void Awake()
        {
            base.Awake();

            if (m_Ship != null)
            {
                Destroy(m_Ship.gameObject);
            }
            
        }


        void Start()
        {
            Respawn();
            //Добавили метод в событие
           m_Ship.EventOnDeath.AddListener(OnShipDeath);
           
        }
        



        private void OnShipDeath()
        {
            
            m_NumLives--;
            if(corRespawn != null)
            StopCoroutine(corRespawn);
            //   Debug.Log($"Событие, после чего должен происходить респавн. Если {m_NumLives}  больше нуля");
            if (m_NumLives > 0)
            {
                corRespawn = StartCoroutine(CoroutineRespawn());
            //    Debug.Log("Respawn corountine");
                
            }
            else
            {
                Debug.Log("Больше нет респавна");
                LevelSequenceController.Instance.FinishCurrentLevel(false); //Возможность сделать выход в главное меню, если заканчивается уровень

            }
            
        }
        private void Respawn()
        {
            Debug.Log("произходит респавн");
            if (LevelSequenceController.PlayerShip != null && !m_Ship)//!= null)
            {
                var newPlayerShip = Instantiate(LevelSequenceController.PlayerShip);
                m_Ship = newPlayerShip.GetComponent<SpaceShip>();
                m_Ship.onCheckHp += ShowHp;

                m_CameraController.SetTarget(m_Ship.transform);

                m_MovementController.SetTargetShip(m_Ship);
              //  Debug.Log("Respawn");
               // Start();
            }

        }

        private void ShowHp(int hp)
        {
            hpText.text = $"Состояние судна: {hp}";
        }

        #region Score
        public int Score { get; private set; }
        public int NumKills { get; private set; }

        public void AddKiil(int num)
        {
             NumKills += num;
        }
        public void AddScore(int num)
        {
            Score += num;
        }
       

        #endregion
        IEnumerator CoroutineRespawn()
        {
           yield return new WaitForSeconds(1.5f);
            Respawn();
            //Добавили метод в событие
            m_Ship.EventOnDeath.AddListener(OnShipDeath);
        }
        
    }
}
