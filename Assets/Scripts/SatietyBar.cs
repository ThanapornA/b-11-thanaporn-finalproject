using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SatietyBar : MonoBehaviour
{
    [ SerializeField ] private Slider slider;

    public void UpdateBar( float currentValue )
    {
        slider.value = currentValue;
    }

    void Update()
    {

    }
}
