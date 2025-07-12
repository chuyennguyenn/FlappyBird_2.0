using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Objects/CharacterData")]
public class CharacterData : ScriptableObject
{
    public Character[] character;

    public int characterCount => character.Length;

    public Character GetCharacter(int index)
    {
        if (index < 0 || index >= character.Length)
        {
            Debug.LogError("Index out of bounds: " + index);
            return null;
        }
        return character[index];
    }
}
