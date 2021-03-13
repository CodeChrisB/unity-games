using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    bool hasHit;
    public float Lifetime = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per framea
    void Update()
    {
        if (Lifetime > 0)
        {
            Lifetime -= Time.deltaTime;
            if (Lifetime < 0)
            {
                Destroy(this.gameObject);
            }
        }


        if (hasHit) {
            float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
