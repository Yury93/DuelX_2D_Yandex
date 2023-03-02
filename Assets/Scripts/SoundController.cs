using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public static bool soundOn;
    public TextMeshProUGUI txtBtn;

    public void Start()
    {
        if(soundOn)
        {
            Debug.Log($"«вук есть!{soundOn}");
            Camera.main.GetComponent<AudioListener>().enabled = true;
            if(txtBtn)
            {
                txtBtn.text = "«вук вкл.";
            }
        }
        else
        {
            Debug.Log($"«вука нет!{soundOn}");
            Camera.main.GetComponent<AudioListener>().enabled = false;
            if (txtBtn)
            {
                txtBtn.text = "«вук выкл.";
            }
        }
    }
    public void ClickSound()
    {
        if (!soundOn)
        {
            Camera.main.GetComponent<AudioListener>().enabled = true;
            soundOn = true;
            if (txtBtn)
            {
                txtBtn.text = "«вук вкл.";
            }
        }
        else
        {
            Camera.main.GetComponent<AudioListener>().enabled = false;
            soundOn = false;
            if (txtBtn)
            {
                txtBtn.text = "«вук выкл.";
            }
        }
    }
}
