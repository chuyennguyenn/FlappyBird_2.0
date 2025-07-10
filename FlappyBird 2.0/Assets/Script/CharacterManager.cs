using UnityEngine;

public class CharacterManager: MonoBehaviour
{
    public CharacterData[] characterDataArray; // Array to hold character data
    public int currentCharacterIndex = 0; // Index of the currently selected character
    public static CharacterManager Instance; // Singleton instance

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // Set the singleton instance
            DontDestroyOnLoad(gameObject); // Prevent destruction on scene load
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    public CharacterData GetCurrentCharacterData()
    {
        if (currentCharacterIndex < 0 || currentCharacterIndex >= characterDataArray.Length)
        {
            Debug.LogError("Current character index is out of bounds.");
            return null; // Return null if index is invalid
        }
        return characterDataArray[currentCharacterIndex]; // Return the current character data
    }

    public void SetCurrentCharacter(int index)
    {
        if (index < 0 || index >= characterDataArray.Length)
        {
            Debug.LogError("Index out of bounds. Cannot set current character.");
            return; // Do nothing if index is invalid
        }
        currentCharacterIndex = index; // Set the current character index
    }

    public void LoadScene()
    {

    }
}
