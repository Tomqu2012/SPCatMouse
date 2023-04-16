using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject botPrefab;
    public GameObject cheesePrefab;
    public List<GameObject> catPrefabs;
    public GameObject coinPrefab;
    public GameObject[] forestPrefabs;
    public float numBots;
    public float forestObstacles;
    public float numCheese;
    public float maxCheese = 5f;
    public float numCoins;
    public float maxCoins = 10f;
    public float upperBoundX = 50f;
    public float lowerBoundX = -50f;
    public float upperBoundY = 33f;
    public float lowerBoundY = -33f;
	public bool catMode;

    // Start is called before the first frame update
    void Start()
    {
        numCheese = 0f;
        numCoins = 0f;
        spawnBots();
        spawnForestObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        spawnCheese();
        spawnCoins();
    }


    void spawnBots() {
        for (int i = 0; i < numBots; i++)
        {
            GameObject botClone = Instantiate(botPrefab, new Vector2(Random.Range(lowerBoundX, upperBoundX), Random.Range(lowerBoundY, upperBoundY)),
                Quaternion.identity);
			if (!catMode) {
				foreach (GameObject catPrefab in catPrefabs)
            	{
                	catPrefab.GetComponent<CatBot>().mice.Add(botClone);
                	botClone.GetComponent<MiceAI>().Cat.Add(catPrefab);
            	}
			}
            
        }
    }

    void spawnCheese() {
        if ((numCheese < maxCheese) && (numCheese >= 0)) {
            Instantiate(cheesePrefab, new Vector2(Random.Range(lowerBoundX, upperBoundX), Random.Range(lowerBoundY, upperBoundY)), Quaternion.identity);
            numCheese++;
        }
    }

    void spawnCoins()
    {
        if ((numCoins < maxCoins) && (numCoins >= 0))
        {
            Instantiate(coinPrefab, new Vector2(Random.Range(lowerBoundX, upperBoundX), Random.Range(lowerBoundY, upperBoundY)), Quaternion.identity);
            numCoins++;
        }
    }

    void spawnForestObstacles()
    {
        for (int i = 0; i < forestObstacles; i++)
        {
            Instantiate(forestPrefabs[Random.Range(0, 13)], new Vector2(Random.Range(lowerBoundX, upperBoundX), Random.Range(lowerBoundY, upperBoundY)), Quaternion.identity);
        }
    }
}
