using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitPointBar : MonoBehaviour
{
    [SerializeField] Image bar, supBar;

    public Vector3 offset;
    [SerializeField] Transform target;
    private Transform myTransform;

    private float curValue, maxValue;
    private float tempValue;


    public void Init(Transform target, float maxHp)
    {
        myTransform = GetComponent<Transform>();
        this.target = target;
        curValue = 0;
        maxValue = maxHp;
        Set(maxHp);
    }
    void Update()
    {
        tempValue = Mathf.MoveTowards(tempValue, curValue, Time.unscaledDeltaTime * maxValue / 3f);
        bar.fillAmount = tempValue / maxValue;
        supBar.fillAmount = curValue / maxValue;
        if (bar.fillAmount < 0.05f) bar.fillAmount = 0.05f;
        if (supBar.fillAmount < 0.05f) supBar.fillAmount = 0.05f;


        //myTransform.position = Camera.main.WorldToScreenPoint(target.position + offset);
    }
    public void Set(float val)
    {
        curValue = val;
    }

}
