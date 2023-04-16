using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keys : MonoBehaviour
{
    public GameObject player;
    public TMP_Text keytxt;
	public bool catMode;

    // Start is called before the first frame update
    void Start()
    {
        keytxt = GetComponent<TMP_Text>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
		bool x = false;
		if (!catMode) {
			x = !player.GetComponent<health>().alive;
		}
        //keytxt.text = "�" + player.GetComponent<movement>().keys.ToString("0");
        if (x)
        {
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-780f, -579f);
        }
    }
}
