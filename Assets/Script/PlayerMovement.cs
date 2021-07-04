using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool isBlack;
    float dirX;
    public float LRspeed;
    public Rigidbody rigidBody;
    public Renderer playerRenderer;
    public int speed;
    public Color ColorB, ColorW;

    public Transform LeftCheck;
    public Transform RightCheck;
    bool left, right;
    public int distance;
    void Start(){
        ColorB = new Color(1,1,1,1);
        ColorW = new Color(0,0,0,0);
        playerRenderer = gameObject.GetComponent<Renderer>();
        isBlack = true;
    }
    void Update(){
        dirX = Input.acceleration.x*LRspeed;
        if(Input.touchCount>0){
            if(Input.GetTouch(0).phase == TouchPhase.Began){
                isBlack = !isBlack;
                if(isBlack){
                    playerRenderer.material.color = ColorW;
                }else{
                    playerRenderer.material.color = ColorB;
                }
            }            
        }
        //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.5f, 7.5f), transform.position.y, transform.position.z);
    }
    void FixedUpdate()
    {
        if(transform.position.y < 0)
        {
            rigidBody.constraints = RigidbodyConstraints.None;
        }
        rigidBody.AddForce(dirX, 0, speed*Time.deltaTime, ForceMode.VelocityChange);

        if(rigidBody.position.y < -3)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        //Update Obstacle
        
        RaycastHit obsInfoL, obsInfoR;
        Physics.Raycast(LeftCheck.position, Vector3.left, out obsInfoL, distance);
        Physics.Raycast(RightCheck.position, Vector3.right, out obsInfoR, distance);
        if (obsInfoL.collider == null)
        {
            left = false;
        }else if (obsInfoL.collider.tag == "Obstacle" && left == false)
        {
            left = true;
            Score.addScore(10);
        }
        if (obsInfoR.collider == null)
        {
            right = false;
        }else if (obsInfoR.collider.tag == "Obstacle" && right == false)
        {
            right = true;
            Score.addScore(10);
        }
        
    }
}
