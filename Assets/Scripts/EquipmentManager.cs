public class EquipmentManager
{
    private UnitConfig config;

    public EquipmentManager(UnitConfig config)
    {
        this.config = config;
    }

    public void EquipItem(Equipment item)
    {
        config.equippedItems.Add(item);
    }

    public void UnequipItem(Equipment item)
    {
        config.equippedItems.Remove(item);
    }

    public int CalculateTotalAttackBonus()
    {
        int total = 0;
        foreach (Equipment item in config.equippedItems)
        {
            total += item.attackBonus;
        }
        return total;
    }

    public int CalculateTotalDefenseBonus()
    {
        int total = 0;
        foreach (Equipment item in config.equippedItems)
        {
            total += item.defenseBonus;
        }
        return total;
    }
}