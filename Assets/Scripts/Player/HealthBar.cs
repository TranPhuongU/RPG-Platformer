using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillBar;
    public void UpdateBar(int currenValue, int maxValue)
    {
        fillBar.fillAmount = (float)currenValue/(float)maxValue;
    }
}
