using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour
{
    public Transform heaven;
    public ParticleSystem breakEffect;
    public bool isBlackWall;
    public Rigidbody rb;
    private GameObject player;
    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        player = players[0];
    }
    private void FixedUpdate()
    {
        //Debug.Log(player.transform.position.z + ", " + transform.position.z);
        if(transform.position.z < player.transform.position.z)
        {
            UpdateWall();
        }
    }
    public void UpdateWall()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        transform.position = new Vector3(heaven.position.x, heaven.position.y, heaven.position.z);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public void BreakWall()
    {
        Instantiate(breakEffect, transform.position+new Vector3(0, 0f, 2), Quaternion.identity);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        transform.position = new Vector3(heaven.position.x, heaven.position.y, heaven.position.z);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        Score.addScore(100);
    }
}
