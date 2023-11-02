using UnityEngine;

[System.Serializable] // This makes the class visible in the Unity inspector
public class Attribute
{
    public string name;
    public int value;
    public int modifier;

    // Constructors are not typically used in Unity for serialized classes
    // Unity will handle the instantiation and setup through the inspector
}