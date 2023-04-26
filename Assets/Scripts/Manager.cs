using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Manager : MonoBehaviour
{
    
    public static float coins = 0;
    public static float keys = 0;
    public static int mouseSpriteID = 13;
    public static int catSpriteID = 14;
	public Sprite[] sprites;
	public static float levelCompleted = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter2D(Collision2D col)
    	{
    	    Destroy(gameObject, 1f);
    	}
    }
}
