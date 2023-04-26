using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject Spawner;
    public GameObject GM;
    public GameObject Fireworks;
    public Rigidbody2D rb2D;
    public ParticleSystem dust;
    public Image staminaBarimg;
    private float speed;
    public float NormalSpeed = 150f;
	public float IAmSped = 1000f;
    public float stamina = 10f;
    public bool ready;
    public Camera cam;
    

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = GM.GetComponent<Manager>().sprites[Manager.mouseSpriteID];
        Spawner = GameObject.Find("Spawner");
        speed = NormalSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        if (ready) {
            // if (!rotation())
            // {
            //     thrust(200);
            // }
            // else
            // {
            //     thrust(130);
            // }
            thrust(200);
            StaminaFill();
        }

    }


    // public bool rotation() {
        // if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        // {
        //     transform.Rotate(0f, 0f, 3.5f);
        //     return true;
        // }

        // if (Input.GetButton("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        // {
        //     transform.Rotate(0f, 0f, -3.5f);
        //     return true;
        // }

        // else
        // {
        //     transform.Rotate(0f, 0f, Random.Range(-0.5f, 0.5f));
        //     return false;
        // }

    //     Vector3 catPos = cam.ScreenToWorldPoint(Input.mousePosition);
    //     transform.rotation = Quaternion.LookRotation(new Vector3(0,0,5), catPos - transform.position);
    // }

    public void thrust(float speed) {
        dust.Play();
		
        if (stamina > 0f && ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))))
        {
            stamina -= (2 * Time.deltaTime);
            speed = IAmSped;
        }
        else
        {
            speed = NormalSpeed;
        }
        rb2D.AddForce(transform.up * speed * Time.deltaTime, ForceMode2D.Impulse);
        if (stamina < 10f && !((Input.GetKey(KeyCode.W) || Input.GetMouseButton(0) || Input.GetKey(KeyCode.UpArrow))))
        {
            StartCoroutine("Regen", 3f);
        }
        Vector3 catPos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(new Vector3(0,0,5), catPos - transform.position);
    }


    IEnumerator Regen(float duration)
    {
        speed = NormalSpeed;
        yield return new WaitForSeconds(duration);
        if (stamina < 10f && !((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))) && gameObject.GetComponent<Hunger>().energy) {
            stamina += Time.deltaTime;
        }
    }

    public void StaminaFill()
    {
        staminaBarimg.fillAmount = stamina / 10;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Manager.coins++;
            Spawner.GetComponent<Spawner>().numCoins--;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Key")
        {
            Manager.keys++;
            GameObject clone2 = Instantiate(Fireworks, col.gameObject.transform.position, Quaternion.identity);
            Destroy(clone2.gameObject, 1f);
            Destroy(col.gameObject);
        }
    }

}
