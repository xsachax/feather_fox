using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddForce(new Vector3(0, 20, 0));
        } else if (Input.GetKeyUp(KeyCode.Space)) {
            rb.velocity *= 1f;
        }
    }
}
