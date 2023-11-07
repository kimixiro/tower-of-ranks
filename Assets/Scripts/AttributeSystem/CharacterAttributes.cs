[System.Serializable]
public class CharacterAttributes {
    public int Combat;
    public int Body;
    public int Dexterity;
    public int Perception;
    public int Intelligence;
    public int Willpower;
    public int Communication;

    // Constructor to initialize the attributes
    public CharacterAttributes(int combat, int body, int dexterity, int perception, int intelligence, int willpower, int communication) {
        Combat = combat;
        Body = body;
        Dexterity = dexterity;
        Perception = perception;
        Intelligence = intelligence;
        Willpower = willpower;
        Communication = communication;
    }

    // You can add methods here to modify attributes, if needed
}