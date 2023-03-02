
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public enum Lang
    {
        ru,eng
    }
    [SerializeField] private Lang lang;
    [SerializeField] private Button btnSelectLang;
    private void Start()
    {
        btnSelectLang.onClick.AddListener(ClickBtn);
    }
    
    public void ClickBtn()
    {
        if (lang == Lang.ru)
        {
            lang = Lang.eng;
            btnSelectLang.GetComponentInChildren<Text>().text = "Русский";
        }
        else
        {
            lang = Lang.ru;
            btnSelectLang.GetComponentInChildren<Text>().text = "English";
        }

    }
}
