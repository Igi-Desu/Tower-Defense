using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    [SerializeField] Slider slider;

    public void SetMax(int val)
    {
        slider.maxValue = val;
    }
    public void ResizeBar(int val)
    {
        slider.value = val;
    }
}

