using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{   
    Rigidbody2D rb;
    public float jumpForce;
    public bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);
        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            rb.AddForce(Vector3.up * jumpForce * 30f);
        }
    }

    /*

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ground") {
            isGrounded= true;
        }
    }

    void OnCollisionStay2D(Collision2D other) {
        if (other.collider.tag == "Ground") {
            isGrounded= true;
        }
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.collider.tag == "Ground") {
            isGrounded= false;
        }
    }
    */
}
