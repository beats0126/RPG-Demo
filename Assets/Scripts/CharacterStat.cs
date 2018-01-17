using UnityEngine;
using UnityEngine.UI;

public class CharacterStat : MonoBehaviour {

    public GameObject healthBar;
    Slider slider;

    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stats health;
    public Stats damage;
    public Stats armor;


    void Awake()
    {
        slider = healthBar.GetComponent<Slider>();
        maxHealth = health.GetValue();
        currentHealth = maxHealth;
    }

    void Update()
    {
        maxHealth = health.GetValue();
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(25);
        }
        
        slider.maxValue = maxHealth;
        slider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;

        Debug.Log(transform.name + " takes " + damage + " damage!");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {

    }
}
