using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    

    public PlayerMovement movement;
    private void FixedUpdate()
    {
        
    }
    void OnCollisionEnter(Collision collisionInfo){
        if(collisionInfo.collider.tag == "Obstacle"){
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }else if(collisionInfo.collider.tag == "BlackWall"){
            if(movement.isBlack == collisionInfo.collider.GetComponent<WallControl>().isBlackWall){
                collisionInfo.collider.GetComponent<WallControl>().BreakWall();
            }
            else
            {
                movement.enabled = false;
                FindObjectOfType<GameManager>().EndGame();
            }
        }else if(collisionInfo.collider.tag == "WhiteWall"){
            if (movement.isBlack == collisionInfo.collider.GetComponent<WallControl>().isBlackWall)
            {
                collisionInfo.collider.GetComponent<WallControl>().BreakWall();
            }
            else
            {
                movement.enabled = false;
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }
}
