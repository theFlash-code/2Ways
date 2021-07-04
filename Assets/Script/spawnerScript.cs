using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public Transform heaven;
    public Transform player;
    public Vector3 offset;

    public float spawnRate;
    float nextSpawn = 0.0f;

    public List<GameObject> Obstacles;
    public GameObject Obstacle;
    int cur = 0;

    public Transform heavenw;
    public List<GameObject> wall;
    public GameObject blackWall;
    public GameObject whiteWall;
    int curw = 0;
    float nextSpawnW = 0.0f;
    public float wallSpawnRate;

    private void Start()
    {
        
        for(int i=0; i<10; ++i)
        {
            Obstacles.Add(Instantiate(Obstacle, heaven.position, heaven.rotation));
        }
        for(int i=0; i<3; ++i)
        {
            wall.Add(Instantiate(blackWall, heavenw.position, heavenw.rotation));
            wall.Add(Instantiate(whiteWall, heavenw.position, heavenw.rotation));
        }
    }
    private void Update()
    {
        transform.position = player.position + offset;
    }
    private void FixedUpdate()
    {
        if(Time.time >= nextSpawn)
        {
            cur = cur >= 10 ? 0 : cur;
            if(Obstacles[cur].transform.position == heaven.position)
            {
                Obstacles[cur].transform.position = new Vector3(1+Random.Range(-12f,12f), 1, transform.position.z);
                Obstacles[cur].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                nextSpawn = Time.time + spawnRate;
                cur++;
            }
        }
        
        if(Time.time >= nextSpawnW)
        {
            curw = curw >= 6 ? 0 : curw;
            if(wall[curw].transform.position == heavenw.position)
            {
                wall[curw].transform.position = new Vector3(1, 2, transform.position.z);
                wall[curw].GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                nextSpawnW = Time.time + wallSpawnRate;
                curw += Random.Range(1,3);
            }
        }
        
    }
}
