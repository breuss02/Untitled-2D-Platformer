using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public float maxTime = 1;
    private float timer = 0;
    public GameObject[] wallPrefabs;
    public float height;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!PlayerManager.isGameStarted)
        {
            return;
        }

        if (timer > maxTime)
        {
            SpawnWall(Random.Range(0, wallPrefabs.Length));
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    public void SpawnWall(int wallIndex)
    {
        GameObject newwall = Instantiate(wallPrefabs[wallIndex]);
        newwall.transform.position = transform.position;
        Destroy(newwall, 15);
    }
}