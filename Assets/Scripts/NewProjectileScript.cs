using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewProjectileScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(new Vector3(0, -5 * Time.deltaTime, 0));

        if (transform.position.y > 5) { Destroy(this.gameObject); }

        if (!GameManager.playGame)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.PlayEnemyShotSound();
            (collision.gameObject.GetComponent<Enemy>()).Die();
            Destroy(this.gameObject);
        }
    }
}
