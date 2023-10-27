using UnityEngine;
using System.Collections;

public class BattleManager : MonoBehaviour
{
    public Combatant player;
    public Combatant enemy;

    private bool isPlayerTurn = true;

    void Start()
    {
        StartCoroutine(BattleLoop());
    }

    private IEnumerator BattleLoop()
    {
        while (player.currentHealth > 0 && enemy.currentHealth > 0)
        {
            if (isPlayerTurn)
            {
                ExecuteAttack(player, enemy);
            }
            else
            {
                ExecuteAttack(enemy, player);
            }

            isPlayerTurn = !isPlayerTurn;

            yield return new WaitForSeconds(1f);
        }

        if (player.currentHealth <= 0)
        {
            Debug.Log("Player defeated!");
        }
        else
        {
            Debug.Log("Enemy defeated!");
        }
    }

    private void ExecuteAttack(Combatant attacker, Combatant defender)
    {
        int hitChance = Random.Range(0, 100);
        int requiredHitChance = 50 - attacker.config.dexterity + defender.config.dexterity; // Example formula

        if (hitChance < requiredHitChance)
        {
            Debug.Log("Attack missed!");
            return;
        }

        int damage = attacker.config.baseAttackPower + attacker.config.strength;
        defender.TakeDamage(damage);

        Debug.Log($"{attacker.name} attacks! {defender.name} health: {defender.currentHealth}");
        
        foreach (StatusEffect effect in attacker.config.statusEffects)
        {
            if (effect.CheckTriggerCondition(attacker, defender, damage))
            {
                defender.ApplyEffect(effect);
            }
        }

        // Process active effects on both combatants
        player.ProcessEffects();
        enemy.ProcessEffects();
    }
}