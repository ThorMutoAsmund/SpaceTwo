using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public GameObject enemyprojectile;
    Vector3 respawn = new Vector3(7, 4, 0);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -5 * Time.deltaTime, 0));

        if (transform.position.y < -5) { Destroy(enemyprojectile); }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = respawn; 
            Destroy(enemyprojectile);
            GameManager.lives--;
            GameManager.playGame = false;
        }
    }
}