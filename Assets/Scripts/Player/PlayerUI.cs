using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider vitalSlider;
    public Slider steminaSlider;


    public void UpdateVitalSlider(float vital)
    {
        vitalSlider.value = vital;
    }
}
