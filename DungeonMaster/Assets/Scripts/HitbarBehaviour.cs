using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitbarBehaviour : MonoBehaviour
{
    public Slider Slider;
	public Gradient gradient;
	public Image fill;

    public void SetMaxHealth(float maxHealth)
    {
        Slider.value = maxHealth;
        Slider.maxValue = maxHealth;

		fill.color = gradient.Evaluate(1f);
    }

	public void SetHealth(float health)
    {
        Slider.value = health;
		fill.color = gradient.Evaluate(Slider.normalizedValue);
    }
}
