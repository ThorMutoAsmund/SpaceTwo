using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        liveText.text = "Lives: " + lives;
        if (lives == 0)
        {
            endScreen.text = "YOU LOSE!";

            StartCoroutine(RestartGame());
        }
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(5f);

        lives = 3;
        playGame = true;
        SceneManager.LoadScene("Scene1");
    }
}
