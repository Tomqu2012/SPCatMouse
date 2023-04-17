using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class catMove : MonoBehaviour
{
    public Rigidbody2D rb2D;

    public bool ready;
    private float speed;
    private Vector3 offset = new Vector3(0, 1.2f, 0);
    public Camera cam;
	public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        speed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            rotation();
            thrust();
        }
    }


    public void rotation() {
        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Rotate(0f, 0f, 1f);
        }

        if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Rotate(0f, 0f, -1f);
        }
    }

    public void thrust() {
        rb2D.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);
        Vector3 catPos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(new Vector3(0,0,5), catPos - transform.position);    
    }
}
