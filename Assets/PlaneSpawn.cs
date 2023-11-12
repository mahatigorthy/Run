using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneSpawn : MonoBehaviour
{
    public GameObject bottomPlanePrefab;
    public GameObject topPlanePrefab; 
    public GameObject obstaclePrefab;
    public GameObject obstaclePrefab2;

    float[] arr = {-9.5f, -3.63f, -0.31f, 3.18f, 6.4f};
    int spawnPos;
    int randObject; 
    public static List<GameObject> planesSpawned;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = 0;
        planesSpawned = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnPos == 650)
        {
            SpawnPlane();
            spawnPos = 0;
        }
        spawnPos++;

        if (transform.position.y > 5 || transform.position.y < -5)
        {
            transform.position = (new Vector3(0f, 1f, -8f));
            DestroyPlanes();
        }
    }

    public void RandomPositionTop()
    {
        int randSpawnPosition = Random.Range(0, 5);

        for (int i = 0; i < randSpawnPosition; i++)
        {
            Vector3 topPos = new Vector3(arr[(int)Random.Range(0, 4)], 3.82f, transform.position.z + 6.5f);
            GameObject plane = Instantiate(topPlanePrefab, topPos, Quaternion.Euler(180, 0, 0));
            randObject = Random.Range(0, 5);
            if (randObject == 1)
            {
                Vector3 obstaclePos = new Vector3(plane.transform.position.x, plane.transform.position.y - 0.5f, plane.transform.position.z);
                GameObject obstacle = Instantiate(obstaclePrefab, obstaclePos, Quaternion.Euler(180, 0, 0));
                planesSpawned.Add(obstacle);
            }
            if (randObject == 2)
            {
                Vector3 obstaclePos2 = new Vector3(plane.transform.position.x, plane.transform.position.y - 0.5f, plane.transform.position.z);
                GameObject obstacle2 = Instantiate(obstaclePrefab2, obstaclePos2, Quaternion.Euler(180, 0, 0));
                planesSpawned.Add(obstacle2);
            }
            planesSpawned.Add(plane);
        }

    }
    public void RandomPositionBot()
    {
        int randSpawnPosition = Random.Range(0, 5);

        for (int i = 0; i < randSpawnPosition; i++)
        {
            Vector3 bottomPos = new Vector3(arr[(int)Random.Range(0, 4)], 0f, transform.position.z + 6.5f);
            GameObject plane = Instantiate(bottomPlanePrefab, bottomPos, Quaternion.Euler(0, 0, 0));
            randObject = Random.Range(0, 5);
            if(randObject == 1)
            {
                Vector3 obstaclePos = new Vector3(plane.transform.position.x, plane.transform.position.y + 0.5f, plane.transform.position.z);
                GameObject obstacle = Instantiate(obstaclePrefab, obstaclePos, Quaternion.Euler(0, 0, 0));
                planesSpawned.Add(obstacle);
            }
            if (randObject == 2)
            {
                Vector3 obstaclePos2 = new Vector3(plane.transform.position.x, plane.transform.position.y + 0.5f, plane.transform.position.z);
                GameObject obstacle2 = Instantiate(obstaclePrefab2, obstaclePos2, Quaternion.Euler(0, 0, 0));
                planesSpawned.Add(obstacle2);
            }
            planesSpawned.Add(plane);
        }

    }

    public void SpawnPlane()
    {
        RandomPositionTop();
        RandomPositionBot();

    }

    public void DestroyPlanes()
    {
        for (int i = 0; i < planesSpawned.Count; i++)
        {
            Destroy(planesSpawned[i]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "shroom")
        {
            transform.position = (new Vector3(0f, 1f, -8f));
            DestroyPlanes();
        }
    }
}