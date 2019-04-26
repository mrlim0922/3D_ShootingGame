using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Image RedHP;
    public float tempHP;

    void Awake()
    {
        GetComponent<Transform>().SetParent(GameObject.Find("HPBars").GetComponent<Transform>());
        gameObject.transform.localScale = new Vector3(1, 1, 1);  //해상도에 따른 스케일 고정.
    }

    public void HP(float MaxHP, float CurrentHP)
    {
        tempHP = CurrentHP / MaxHP;
        RedHP.fillAmount = tempHP;
    }
}
