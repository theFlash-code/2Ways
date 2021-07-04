using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
    public GameObject player;
    public Transform heaven;
    public Rigidbody rb;
    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        player = players[0];
    }
    private void FixedUpdate()
    {
        if(transform.position.z < player.transform.position.z-10)
        {
            DestroyObs();
        }
    }
    public void DestroyObs()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        transform.position = new Vector3(heaven.position.x, heaven.position.y, heaven.position.z);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
