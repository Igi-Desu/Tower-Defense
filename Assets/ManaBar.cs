using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    // Start is called before the first frame update
    public void SetMax(int val)
    {
        slider.maxValue = val;
    }
    public void ResizeBar(int val)
    {
        slider.value = val;
    }
}

