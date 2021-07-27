using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int lives = 3;
    public static bool playGame = true;

    public Text liveText;
    public Text endScreen;
    // Start is called before the first frame update
    void Start()
    {
        liveText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        liveText.text = "lives: " + lives;
        if (lives == 0)
        {
            endScreen.text = "YOU LOSE!";
        }
    }
}
