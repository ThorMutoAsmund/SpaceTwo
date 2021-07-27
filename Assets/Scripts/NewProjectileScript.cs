using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewProjectileScript : MonoBehaviour
{
    public GameObject projectille;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -5 * Time.deltaTime, 0));

        if (transform.position.y > 5) { Destroy(projectille); }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(projectille);
            GameManager.playGame = true;
        }
         
        
       
        
    }


}
