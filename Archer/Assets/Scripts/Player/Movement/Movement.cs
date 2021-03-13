using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;                //Floating point variable to store the player's movement speed.
    public float jump = 5f;
    private Rigidbody2D rb;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb.AddForce(Vector2.up * (Input.GetKey(KeyCode.Space)?jump:0), ForceMode2D.Impulse);
        float moveBy = x * speed;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + moveBy,transform.position.y, 0), speed );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
            player.transform.parent = other.gameObject.transform;
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Platform"))
            player.transform.parent = null;
    }


}
