using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private HealthManager healthMan;
    public Slider healthBar;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
        SetMaxHealth(healthMan.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //healthBar.maxValue = healthMan.maxHealth;
        //healthBar.value = healthMan.currentHealth;
        SetHealth(healthMan.currentHealth);
    }

    void SetMaxHealth(int health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    void SetHealth(int health)
    {
        healthBar.value = health;

        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }
}
