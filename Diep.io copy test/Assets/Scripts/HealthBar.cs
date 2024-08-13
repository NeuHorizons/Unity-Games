using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public CanvasGroup canvasGroup;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void ShowHealthBar()
    {
        canvasGroup.alpha = 1; // Make the health bar visible.
    }

    public void HideHealthBar()
    {
        canvasGroup.alpha = 0; // Make the health bar invisible.
    }

    // Start is called before the first frame update
    void Start()
    {
        HideHealthBar(); // Hide the health bar by default.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
