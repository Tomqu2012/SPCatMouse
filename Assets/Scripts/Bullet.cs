using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        rb2D.velocity = transform.up * speed;
    }

}
