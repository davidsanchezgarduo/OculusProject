using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SldierController : MonoBehaviour
{
    public Slider slider;
    private TextMeshProUGUI text;
    
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        volSliderValue();
        // diffSliderValue();
    }

    public void volSliderValue()
    {
        text.text = (int)(slider.value * 100) + "%";
    }

    // public void diffSliderValue()
    // {
    //     switch (slider.value)
    //     {
    //         case 0:
    //             text.text = "Easy";
    //             break;
    //         case 1:
    //             text.text = "Medium";
    //             break;
    //         case 2:
    //             text.text = "Hard";
    //             break;
    //         default:
    //             text.text = "Medium";
    //             break;
    //     }
    // }
}
