using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsDisplay : MonoBehaviour {
    PlayerStats stats;

    public GameObject player;

    public int maxHealth;
    public int health;
    public int damage;
    public int armor;
    public int movespeed;

    public Text t_Health;
    public Text t_Damage;
    public Text t_Armor;
    public Text t_Movespeed;

	// Use this for initialization
	void Start () {
        stats = player.GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
        maxHealth = stats.maxHealth;
        health = stats.currentHealth;
        armor = stats.armor.GetValue();
        damage = stats.damage.GetValue();

        t_Health.text = "Health : " + health.ToString() + " / " + maxHealth;
        t_Damage.text = "Damage : " + damage.ToString();
        t_Armor.text = "Armor : " + armor.ToString(); 
        t_Movespeed.text = "Speed : " + movespeed.ToString();
    }
}
