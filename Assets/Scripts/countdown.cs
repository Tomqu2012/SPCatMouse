using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class countdown : MonoBehaviour
{
    public GameObject bot;
    public GameObject player;
    public List<GameObject> cats;
    public float countdownTime;
    public TMP_Text countdownDisplay;
    public bool active;
	public bool mouseMode;


    // Start is called before the first frame update

    void Start()
    {
        active = true;
        foreach (GameObject cat in cats)
        {
            cat.GetComponent<CatBot>().gameReady = false;
        }
        // player.GetComponent<movement>().ready = false;
        StartCoroutine(CountdownStart());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CountdownStart() {
        while (countdownTime > 0) {
            countdownDisplay.text = countdownTime.ToString("0");
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }

        active = false;
        player.GetComponent<movement>().ready = true;
        foreach (GameObject cat in cats)
        {
            cat.GetComponent<CatBot>().gameReady = true;
        }

        countdownDisplay.text = "GO!";
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }

    public bool isActive()
    {
        return active;
    }
}
