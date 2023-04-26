using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacles : MonoBehaviour
{
    public GameObject Manager;
    // Start is called before the first frame update
    void Start()
    {
        Manager = GameObject.Find("Spawner");
    }

    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter2D(Collision2D col)
        {
            Manager.GetComponent<Spawner>().numCheese--;
            Destroy(gameObject, 1f);
        }
    }
}
