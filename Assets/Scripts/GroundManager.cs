using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour {

    public GameObject[] groundPrefabs;
    private Transform playerTransform;
    private float spawnZ = -15.0f;
    private float groundLenght = 10.0f;
    private float safeZone = 15.0f;
    private int amnGroundsOnScreen = 7;
    private int lastPrefabIndex = 0;

    private List<GameObject> activeGround;

	// Use this for initialization
	private void Start ()
    {
        activeGround = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amnGroundsOnScreen; i++)
        {
            if(i < 4)
            {
                SpawnGround(0);
            }
            else
            {
                SpawnGround();
            }
            
            
        }

    }
	
	// Update is called once per frame
	private void Update () {

		if(playerTransform.position.z -safeZone > (spawnZ - amnGroundsOnScreen * groundLenght))
        {
            SpawnGround();
            DeleteGround();
        }
	}

    private void SpawnGround(int prefabIndex = -1)
    {
        GameObject go;
        if(prefabIndex == -1)
        {
            go = Instantiate(groundPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(groundPrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += groundLenght;
        activeGround.Add(go);

    }
    private void DeleteGround()
    {
        Destroy(activeGround[0]);
        activeGround.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if(groundPrefabs.Length <= 1)
        {
            return 0;
        }
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, groundPrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
