using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour {

    public float attackSpeed = 1.0f;
    private float attackCoolDown = 0.0f;

    CharacterStat myStats;

    public float attackDelay = 1.0f;

    public event System.Action onAttack;

    private void Start()
    {
        myStats = GetComponent<CharacterStat>();
    }

    public void Attack(CharacterStat targetStat)
    {
        if(attackCoolDown <= 0f)
        {
            StartCoroutine (DoDamage (targetStat, attackDelay));

            if (onAttack != null)
                onAttack();

            attackCoolDown = 1f / attackSpeed;
        }

    }
    
    IEnumerator DoDamage(CharacterStat stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.TakeDamage(myStats.damage.GetValue());
    }
}
