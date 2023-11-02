public class EquipmentManager
{
    // EquipItem method: Handles the logic of equipping an item to a character
    public void EquipItem(Character character, Equipment equipment)
    {
        // Check if the item is not already equipped
        if (!character.Equipments.Contains(equipment))
        {
            // Equip the item
            equipment.Equip(character);
            // Additional logic can be added here, such as checking for item type compatibility
        }
    }

    // UnequipItem method: Handles the logic of unequipping an item from a character
    public void UnequipItem(Character character, Equipment equipment)
    {
        // Check if the item is currently equipped
        if (character.Equipments.Contains(equipment))
        {
            // Unequip the item
            equipment.Unequip(character);
            // Additional logic can be added here, such as handling the case where an item cannot be unequipped
        }
    }
}