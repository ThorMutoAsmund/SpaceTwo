using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Vector3 respawn = new Vector3(7, 4, 0);
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(new Vector3(0, -5 * Time.deltaTime, 0));

        if (transform.position.y < -5) { Destroy(this.gameObject); }

        if (!GameManager.playGame)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && GameManager.playGame)
        {
            GameManager.PlayPlayerShotSound();

            GameManager.lives--;
            GameManager.playGame = false;

            (collision.gameObject.GetComponent<PlayerScript>()).Die(respawn);
        }
    }
}