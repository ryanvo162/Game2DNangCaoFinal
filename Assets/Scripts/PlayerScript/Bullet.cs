using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Destroy(gameObject);
        if (hitInfo.gameObject.tag == "Enemy")
        {
            Destroy(hitInfo.gameObject);
            // plus 1 point
            // Point.AddPoint();
        }
    }

}
