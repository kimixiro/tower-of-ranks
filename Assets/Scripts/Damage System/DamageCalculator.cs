public static class DamageCalculator
{
    public static void ApplyDamageToBodyPart(Unit unit, string bodyPartName, int damageAmount, DamageType damageType)
    {
        BodyPart part = unit.config.bodyParts.Find(bp => bp.name == bodyPartName);
        if (part != null)
        {
            int effectiveDamage = CalculateEffectiveDamage(part, damageAmount, damageType);
            part.strength -= effectiveDamage;
        }
    }

    private static int CalculateEffectiveDamage(BodyPart part, int damageAmount, DamageType damageType)
    {
        int resistance = part.resistances[damageType];
        int armorReduction = part.equippedArmor != null ? part.equippedArmor.damageReduction[damageType] : 0;
        return damageAmount - resistance - armorReduction;
    }
}