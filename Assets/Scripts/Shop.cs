using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{

    public int[,] shopItems = new int[4,14];
    public float coins;
    public TMP_Text coinTxt;
    public List<GameObject> items = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        coins = Manager.coins;
        coinTxt.text = "Coins: " + coins.ToString();

        //IDs
        for (int i = 1; i < 14; i++)
        {
            shopItems[1, i] = i;
            shopItems[1, i] = 0;
        }
        

        //Price
        shopItems[2, 1] = 50;
        shopItems[2, 2] = 100;
        shopItems[2, 3] = 999;
        shopItems[2, 4] = 200;
        shopItems[2, 5] = 200;
        shopItems[2, 6] = 200;
        shopItems[2, 7] = 200;
        shopItems[2, 8] = 200;
        shopItems[2, 9] = 200;
        shopItems[2, 10] = 400;
        shopItems[2, 11] = 999;
        shopItems[2, 12] = 500;
        shopItems[2, 13] = 500;
        

    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, buttonRef.GetComponent<ItemInfo>().ItemID]) {

            coins -= shopItems[2, buttonRef.GetComponent<ItemInfo>().ItemID];
            Manager.coins -= shopItems[2, buttonRef.GetComponent<ItemInfo>().ItemID];
            if (buttonRef.GetComponent<ItemInfo>().ItemID == 2 ||
                buttonRef.GetComponent<ItemInfo>().ItemID == 3 ||
                buttonRef.GetComponent<ItemInfo>().ItemID == 11 ||
                buttonRef.GetComponent<ItemInfo>().ItemID == 12)
            {
                Manager.catSpriteID = buttonRef.GetComponent<ItemInfo>().ItemID - 1;
            }
            else
            {
                Manager.mouseSpriteID = buttonRef.GetComponent<ItemInfo>().ItemID - 1;
            }
            for (int i = 0; i < 13; i++)
            {
                items[i].GetComponent<Image>().color = new Color32(0,0,0,150);
            }
            items[buttonRef.GetComponent<ItemInfo>().ItemID - 1].GetComponent<Image>().color = new Color32(0,150,0,150);
            shopItems[3, buttonRef.GetComponent<ItemInfo>().ItemID]++;
            coinTxt.text = "Coins: " + coins.ToString();
            buttonRef.GetComponent<ItemInfo>().QuantityTxt.text = shopItems[3, buttonRef.GetComponent<ItemInfo>().ItemID].ToString();
        }
    }
}
