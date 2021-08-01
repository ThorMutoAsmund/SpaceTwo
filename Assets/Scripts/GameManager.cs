using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int lives = 3;
    public static bool playGame = true;
    private float time;

    public Text liveText;
    public Text timeText;
    public Text endScreen;

    public AudioClip wonClip;
    public AudioClip lostClip;
    public AudioClip fireClip;
    public AudioClip enemyShotClip;
    public AudioClip playerShotClip;

    public AudioSource audioSource;

    void Start()
    {
        lives = 3;
        playGame = true;

        liveText.text = "Lives: " + lives;
        timeText.text = "Time: 0";
        this.time = 0;
        this.audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        IEnumerator Restart(float seconds)
        {
            yield return new WaitForSeconds(seconds);
            lives = -1;
        }

        if (lives >= 0)
        {
            if (playGame)
            {
                time += Time.deltaTime;
            }
            liveText.text = "Lives: " + lives;
            timeText.text = "Time: " + (int)time + "." + (int)((time - (int)time) * 10);

            if (lives == 0)
            {
                PlayPlayerLostSound();
                lives = -2;
                endScreen.text = "YOU LOSE!\nPRESS SPACE TO TRY AGAIN";
                StartCoroutine(Restart(2));
            }

            if (FindObjectsOfType<Enemy>().Length == 0)
            {
                playGame = false;
                PlayPlayerWonSound();
                lives = -2;
                endScreen.text = "YOU WON!\nPRESS SPACE TO TRY AGAIN";
                StartCoroutine(Restart(6));
            }
        }
    }

    public static void RestartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public static void PlayPlayerShotSound()
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.audioSource.PlayOneShot(gameManager.playerShotClip);
    }
    public static void PlayEnemyShotSound()
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.audioSource.PlayOneShot(gameManager.enemyShotClip);
    }
    public static void PlayShotSound()
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.audioSource.PlayOneShot(gameManager.fireClip);
    }
    public static void PlayPlayerLostSound()
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.audioSource.PlayOneShot(gameManager.lostClip);
    }
    public static void PlayPlayerWonSound()
    {
        var gameManager = FindObjectOfType<GameManager>();
        gameManager.audioSource.PlayOneShot(gameManager.wonClip);
    }
}
