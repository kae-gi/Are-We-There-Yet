using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public void setGas(float val)
    {
        slider.value = val;
    }
}
