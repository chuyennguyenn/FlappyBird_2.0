using TMPro;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI DisplayText;

    public int timer = 3;

    private void Update()
    {
        timer = 3 - (int)Time.timeSinceLevelLoad;
        DisplayText.text = timer.ToString(); 
        Debug.Log("Timer: " + Time.timeSinceLevelLoad); // Log the timer value for debugging

        if (timer <= 0)
        {
            Debug.Log("Tutorial finished, starting game..."); // Log when the tutorial finishes
            GameManager.instance.StartGame(); 
        }
    }
}
