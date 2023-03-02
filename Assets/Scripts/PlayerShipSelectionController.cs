using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace SpaceShooter
{
    public class PlayerShipSelectionController : MonoBehaviour
    {
        [SerializeField] private SpaceShip m_Prefab;

        [SerializeField] private TextMeshProUGUI m_ShipName;
        [SerializeField] private TextMeshProUGUI m_Hitpoints;
        [SerializeField] private TextMeshProUGUI m_Speed;
        [SerializeField] private TextMeshProUGUI m_Agility;

        [SerializeField] private Image m_PreviewImage;
        [SerializeField] private Button selectButton;
        [SerializeField] private int price;
        [SerializeField] private TextMeshProUGUI priceText;

        private void Start()
        {
            if(m_Prefab !=null)
            {
                m_ShipName.text = m_Prefab.name;

                m_Hitpoints.text = "Состояние: "+ m_Prefab.HitPoints.ToString();
                m_Speed.text ="Скорость: "+ m_Prefab.MaxLinearVelocity.ToString();
                m_Agility.text = "Управляемость: "+ m_Prefab.MaxAngularVelocity.ToString();

                m_PreviewImage.sprite = m_Prefab.PreviewImage;

               
            }
        }

        public void OnSelectShip()
        {
            int kill = 0;
            if (PlayerPrefs.HasKey("score"))
            {
                kill = PlayerPrefs.GetInt("score");
            }
            if (kill < price)
            {
                priceText.enabled = true;
                priceText.text = $"Для этого судна нужно {price} очков!";
                return;
            }
                LevelSequenceController.PlayerShip = m_Prefab;

            MainMenuController.Instance.gameObject.SetActive(true);
        }

    }
}
