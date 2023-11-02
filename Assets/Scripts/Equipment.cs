using System.Collections.Generic;
using System.Linq;

public class Equipment
{
    public string Name { get; set; }
    public string Type { get; set; }
    public List<Attribute> AttributeBonuses { get; set; }

    public Equipment(string name, string type, List<Attribute> attributeBonuses)
    {
        Name = name;
        Type = type;
        AttributeBonuses = attributeBonuses;
    }

    // Equip method: Equips the item to the character
    public void Equip(Character character)
    {
        // Add the equipment to the character's equipment list
        character.Equipments.Add(this);

        // Apply the attribute bonuses to the character
        foreach (var bonus in AttributeBonuses)
        {
            var targetAttribute = character.PrimaryAttributes
                .Concat(character.SecondaryAttributes)
                .FirstOrDefault(attr => attr.Name == bonus.Name);

            if (targetAttribute != null)
            {
                targetAttribute.Value += bonus.Value;
            }
        }
    }

// Unequip method: Unequips the item from the character
    public void Unequip(Character character)
    {
        // Remove the equipment from the character's equipment list
        character.Equipments.Remove(this);

        // Remove the attribute bonuses from the character
        foreach (var bonus in AttributeBonuses)
        {
            var targetAttribute = character.PrimaryAttributes
                .Concat(character.SecondaryAttributes)
                .FirstOrDefault(attr => attr.Name == bonus.Name);

            if (targetAttribute != null)
            {
                targetAttribute.Value -= bonus.Value;
            }
        }
    }
    
}