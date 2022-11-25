using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed;
    public float maxSpeed;
    Rigidbody2D rb;
    Jump jumpSwitch;
    LongJump longJumpSwitch;
    Fly flySwitch;

    public bool isMoving;
    public Vector3 lastPos;
    public float tolerance;

    public bool isDead = false;




    // Start is called before the first frame updatee
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        jumpSwitch = GetComponent<Jump>();
        longJumpSwitch = GetComponent<LongJump>();
        flySwitch = GetComponent<Fly>();

        
    }

    void Update() {
        if (playerSpeed < maxSpeed && gameObject.transform.position.x > 20) {
            playerSpeed += 0.15f * Time.deltaTime;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (!isDead){
            transform.Translate(Vector2.right *(Time.deltaTime * playerSpeed));
        }
        
        
        if ((transform.position.x - tolerance) > lastPos.x){
            lastPos = transform.position;
            isMoving = true; 
            }
        else {
            isMoving = false;
            
        }
        
        
        if (!isMoving) 
        {
            Death();
        }
        
    }


    void Death() {
        isDead = true;
        GetComponent<LongJump>().enabled = false;
        FindObjectOfType<GameController>().GameOver();
    }

     void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Spike"){
            Death();
        }
     }

    
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Water"){
            Death();
        }

        if (collision.gameObject.tag == "PortalToJump") {
            jumpSwitch.enabled = true;
            longJumpSwitch.enabled = false;
            flySwitch.enabled = false;
        } else if (collision.gameObject.tag == "PortalToLongJump") {
            jumpSwitch.enabled = false;
            longJumpSwitch.enabled = true;
            flySwitch.enabled = false;
        } else if (collision.gameObject.tag == "PortalToFly") {
            jumpSwitch.enabled = false;
            longJumpSwitch.enabled = false;
            flySwitch.enabled = true;
            
        }

        if (collision.gameObject.tag == "BouncePad"){
            rb.AddForce(Vector2.up * 40f, ForceMode2D.Impulse);
            rb.AddForce(Vector2.right * 1f, ForceMode2D.Impulse);

    }
    }
}
