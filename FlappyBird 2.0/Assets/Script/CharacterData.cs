using UnityEngine;

public class CharacterData
{
    public int characterID;
    public Sprite characterSprite;
    public AbilityType abilityType;
}

public enum AbilityType
{
    None,
    Slow,
    Small,
    Intangible
}