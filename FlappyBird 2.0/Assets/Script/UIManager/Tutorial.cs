using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI DisplayText;

    public int timerMax = 3;

    private void Update()
    {
        int timer = timerMax - (int)Time.timeSinceLevelLoad;
        DisplayText.text = timer.ToString(); 
        //Debug.Log("Timer: " + Time.timeSinceLevelLoad);

        if (timer <= 0 || Mouse.current.leftButton.isPressed)
        {
            //Debug.Log("Tutorial finished, starting game..."); 
            GameManager.instance.StartGame(); 
        }
    }
}
