using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchManager : MonoBehaviour
{
    public List<GameObject> achievements = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        int[] unlocks = new int[3];
        unlocks[0] = Manager.levelCompleted > 0? 1:0;
        unlocks[1] = Manager.levelCompleted > 2? 1:0;
		unlocks[2] = Manager.keys > 2? 1:0;
        for (int i = 0; i < achievements.Count; i++)
        {
            achievements[i].GetComponent<Image>().color = new Color32(0,(byte) (150 * unlocks[i]),0,150);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
