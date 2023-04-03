using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hunger : MonoBehaviour
{
    public bool energy;
    public float hunger;
    public float diff;
    public Image hungerBarimg;

    // Start is called before the first frame update
    void Start()
    {
        energy = true;
        hunger = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (hunger <= 100f)
        {
            hunger += (diff * Time.deltaTime);
        }

        if (hunger <= 10f)
        {
            energy = true;
        }

        else if (hunger <= 40f)
        {
            energy = false;
            gameObject.GetComponent<health>().HP -= (0.01f * diff * Time.deltaTime);

        }

        else if (hunger <= 70)
        {
            energy = false;
            gameObject.GetComponent<health>().HP -= (0.010f * diff * Time.deltaTime);
            gameObject.GetComponent<movement>().stamina -= (0.10f * diff * Time.deltaTime);
        }
        else
        {
            energy = false;
            gameObject.GetComponent<health>().HP -= (0.02f * diff * Time.deltaTime);
            gameObject.GetComponent<movement>().stamina -= (0.2f * diff * Time.deltaTime);
        }

        HungerFill();
    }

    public void HungerFill()
    {
        if (gameObject.GetComponent<movement>().ready) {
            hungerBarimg.fillAmount = 1 - (hunger / 100);
        }
    }
}
