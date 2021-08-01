using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    float timer = 0;
    float timeToMove = 0.5f;
    int numOfMovements = 0;
    float speed = 0.25f;
    int numOfJumps = 0;

    public GameObject enemy;
    public GameObject enemyProjectile;
    public GameObject enemyProjectileClone;

    void Start()
    {
       
    }

    void Update()
    {
        if (GameManager.playGame)
        {
            timer += Time.deltaTime;
            if (timer > timeToMove && numOfMovements < 11)
            {
                transform.Translate(new Vector3(speed, 0, 0));
                timer = 0;
                numOfMovements++;
            }
            if (numOfMovements == 11)
            {
                transform.Translate(new Vector3(0, -1, 0));
                numOfMovements = -7;
                speed = -speed;
                timer = 0;
                numOfJumps++;
                if (numOfJumps > 8)
                {
                    GameManager.lives = 0;
                    GameManager.playGame = false;
                }
            }

            fireEnemyProjectile();

        }
    }
    void fireEnemyProjectile()
    {
        if (Random.Range(0f, 4000f) < 1)
        {
            enemyProjectileClone = Instantiate(enemyProjectile, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.4f, 0), enemy.transform.rotation) as GameObject;
        }
    }

    public void Die()
    {
        IEnumerator FadeOut()
        {
            float size = 1.5f;
            while (size > 0.1f)
            {
                size -= 0.025f;
                this.transform.localScale = Vector3.one * size;
                yield return null;
            }
            Destroy(this.gameObject);
        }

        StartCoroutine(FadeOut());
    }

}
