using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerater : MonoBehaviour
{
    int cur;
    public GameObject[] Platforms;
    
    void Start(){
        cur = 0;
    }
    void FixedUpdate(){
        if(transform.position.z>Platforms[cur].transform.position.z+50){
            int m = cur;
            cur = cur==0? 1:0;
            float tempz = Platforms[cur].transform.position.z+249;
            Platforms[m].transform.position = new Vector3(1,0,tempz);
            
        }    
    }
}
