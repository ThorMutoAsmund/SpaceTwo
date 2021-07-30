using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject player;   
    public GameObject projectile;
    public GameObject projectileClone1;
    public GameObject projectileClone2;

    public VariableJoystick variableJoystick;
    public Button button;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("STARTED");
    }

    // Update is called once per frame
    void Update()
    { 
    }

    public void FixedUpdate()
    {
        if (GameManager.lives > 0)
        {
            fireprojectile();
            movement();

            if (Mathf.Abs(variableJoystick.Vertical) > Mathf.Abs(variableJoystick.Horizontal))
            {
                if (variableJoystick.Vertical > 0.01)
                {
                    MoveUp(variableJoystick.Vertical);
                }
                else if (variableJoystick.Vertical < -0.01)
                {
                    MoveDown(-variableJoystick.Vertical);
                }
            }
            else
            {
                if (variableJoystick.Horizontal > 0.01)
                {
                    MoveRight(variableJoystick.Horizontal);
                }
                else if (variableJoystick.Horizontal < -0.01)
                {
                    MoveLeft(-variableJoystick.Horizontal);
                }
            }
        }


        //Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    void MoveRight(float amount = 1)
    {
        if (transform.position.x < 6)
        {
            transform.Translate(new Vector3(amount * -7 * Time.deltaTime, 0, 0));
        }
    }

    void MoveLeft(float amount = 1)
    {
        if (transform.position.x > -6)
        {
            transform.Translate(new Vector3(amount * 7 * Time.deltaTime, 0, 0));
        }
    }

    void MoveUp(float amount = 1)
    {
        if (transform.position.y < 5)
        {
            transform.Translate(new Vector3(0, amount * -7 * Time.deltaTime, 0));
        }
    }

    void MoveDown(float amount = 1)
    {
        if (transform.position.y > -5)
        {
            transform.Translate(new Vector3(0, amount * 7 * Time.deltaTime, 0));
        }
    }

    void movement()    
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
        }
    }
    void fireprojectile()
    {
        var buttonDown = this.button.GetDown();

        if (projectileClone1 == null && (Input.GetKeyDown(KeyCode.Space) || buttonDown))
        {
            if (GameManager.playGame == false && GameManager.lives > 0)
            {
                GameManager.playGame = true;
            }
            projectileClone1 = Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y + 0.6f, 0), player.transform.rotation) as GameObject;
        }
        else if (projectileClone2 == null && (Input.GetKeyDown(KeyCode.Space) || buttonDown))
        {
            projectileClone2 = Instantiate(projectile, new Vector3(player.transform.position.x, player.transform.position.y + 0.6f, 0), player.transform.rotation) as GameObject;
        }
    }
}