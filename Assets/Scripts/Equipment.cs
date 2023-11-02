using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Equipment
{
    public string name;
    public string type;
    public List<Attribute> attributeBonuses;

    // Removed constructor in favor of Unity's serialization system

    // Equip method: Equips the item to the character
    public void Equip(Character character)
    {
        // Add the equipment to the character's equipment list
        character.equipments.Add(this);

        // Apply the attribute bonuses to the character
        foreach (var bonus in attributeBonuses)
        {
            var targetAttribute = character.primaryAttributes
                .Concat(character.secondaryAttributes)
                .FirstOrDefault(attr => attr.name == bonus.name);

            if (targetAttribute != null)
            {
                targetAttribute.value += bonus.value;
            }
        }
    }

    // Unequip method: Unequips the item from the character
    public void Unequip(Character character)
    {
        // Remove the equipment from the character's equipment list
        character.equipments.Remove(this);

        // Remove the attribute bonuses from the character
        foreach (var bonus in attributeBonuses)
        {
            var targetAttribute = character.primaryAttributes
                .Concat(character.secondaryAttributes)
                .FirstOrDefault(attr => attr.name == bonus.name);

            if (targetAttribute != null)
            {
                targetAttribute.value -= bonus.value;
            }
        }
    }
}