using UnityEngine;

public class DamageHandler
{
    private UnitConfig config;
    private int hitPoints; // The unit's current hit points
    private bool isCriticallyHit; // Flag to indicate if the unit has been critically hit


    public DamageHandler(UnitConfig config)
    {
        this.config = config;
    }

    public void HandleDamage(int damage)
    {
        config.hitPoints -= damage;
        if (config.hitPoints <= 0)
        {
            // Handle unit death
        }
    }

    public void ApplyDamageToBodyPart(string bodyPartName, int damageAmount, DamageType damageType)
    {
        // Logic for applying damage to specific body parts
    }

    public void CheckForMortalWound()
    {
        // Logic for checking and applying mortal wounds
    }

    public void CheckForInjuries()
    {
        // In Zweihänder, injuries often occur when hit points reach certain thresholds.
        // For example, if hit points are less than or equal to 0, the unit is seriously injured.
        if (hitPoints <= 0)
        {
            Debug.Log("Unit is seriously injured!");
            // Apply serious injury effects here
        }
        else if (hitPoints <= 10) // Replace 10 with a threshold suitable for your game
        {
            Debug.Log("Unit is moderately injured!");
            // Apply moderate injury effects here
        }
        else
        {
            Debug.Log("Unit is not injured.");
        }
    }

    public void ApplyCriticalHitToBodyPart()
    {
        // In Zweihänder, critical hits often target specific body parts.
        // You can use a random number generator to determine which body part is hit.
        if (isCriticallyHit)
        {
            int bodyPart = UnityEngine.Random.Range(1, 7); // Roll a 6-sided die

            switch (bodyPart)
            {
                case 1:
                    Debug.Log("Critical hit to the head!");
                    // Apply effects for critical hit to the head
                    break;
                case 2:
                    Debug.Log("Critical hit to the torso!");
                    // Apply effects for critical hit to the torso
                    break;
                case 3:
                    Debug.Log("Critical hit to the left arm!");
                    // Apply effects for critical hit to the left arm
                    break;
                case 4:
                    Debug.Log("Critical hit to the right arm!");
                    // Apply effects for critical hit to the right arm
                    break;
                case 5:
                    Debug.Log("Critical hit to the left leg!");
                    // Apply effects for critical hit to the left leg
                    break;
                case 6:
                    Debug.Log("Critical hit to the right leg!");
                    // Apply effects for critical hit to the right leg
                    break;
                default:
                    Debug.Log("Invalid body part!");
                    break;
            }
        }
    }
}