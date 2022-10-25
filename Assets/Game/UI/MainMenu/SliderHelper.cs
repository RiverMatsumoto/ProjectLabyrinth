using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderHelper : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Slider slider;
    
    public void SetText()
    {
        text.text = slider.value.ToString();
    }

    private void Start()
    {
        text.text = slider.value.ToString();
    }
}
