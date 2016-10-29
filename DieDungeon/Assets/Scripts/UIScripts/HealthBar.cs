using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class HealthBar : MonoBehaviour 
{
    public Slider Slider;

    void Start()
    {
        gameObject.SetActive(true);
    }

    public void SetPercent(float p)
    {
        gameObject.SetActive(true);
        Slider.value = p;
    }
}
