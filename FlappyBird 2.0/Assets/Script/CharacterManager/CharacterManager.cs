using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;

    public CharacterData characterData;
    public int characterId = 0;
    public Sprite characterSprite;

    private void Awake()
    {
        // Singleton pattern: only one instance allowed
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate
            return;
        }
    }

    private void Start()
    {
        SetID(characterId);
    }

    public void SetID(int id)
    {
        characterId = id;
        Character selectedCharacter = characterData.GetCharacter(characterId);
        characterSprite = selectedCharacter.Sprite;
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public Sprite SelectedCharacterSprite
    {
        get
        {
            return characterSprite;
        }
    }

    public int SelectedCharacterId
    {
        get
        {
            return characterId;
        }
    }
}
