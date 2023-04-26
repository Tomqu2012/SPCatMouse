using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class catMove : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject GM;
    public GameObject Spawner;

    public Rigidbody2D rb2D;

    public bool ready;
    private float speed;
    private Vector3 offset = new Vector3(0, 1.2f, 0);
    public Camera cam;
	public int score = 0;
	public List<GameObject> mice = new List<GameObject>();
	public TMP_Text scoretxt;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = GM.GetComponent<Manager>().sprites[Manager.catSpriteID];
        speed = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        if (ready)
        {
            rotation();
            thrust();
			updateScore();
			scoretxt.text = "Score: " + score.ToString("0");
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

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Manager.coins++;
            Spawner.GetComponent<Spawner>().numCoins--;
            Destroy(col.gameObject);
        }
    }

    public void updateScore() {
		foreach (GameObject g in mice) {
			if (g == null) {
				score++;
				mice.Remove(g);

			}

		}

	}
}
