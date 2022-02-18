using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class Water : MonoBehaviour
{
    [SerializeField, Range(0,10)]
    float scale = 1;

    public float PullingForce = 1;

    public float DirForce;

    public float MaxDistance;

    public float MinDistance;

    GameObject[] waters;

    public Rigidbody rb;

    float x,y,z,l;

    void Update()
    {
        x = 0;
        y = 0;
        z = 0;
        transform.localScale = new Vector3(scale,scale,scale); 
        waters = GameObject.FindGameObjectsWithTag("Water");
        for(int i = 0; i < waters.Length; i++)
        {
            if(Vector3.Distance(transform.position,waters[i].transform.position) < MaxDistance && Vector3.Distance(transform.position,waters[i].transform.position) > MinDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, waters[i].transform.position ,PullingForce);
                x += waters[i].GetComponent<Rigidbody>().velocity.x;
                y += waters[i].GetComponent<Rigidbody>().velocity.y;
                z += waters[i].GetComponent<Rigidbody>().velocity.z;
                l++;
            }
            else if(Vector3.Distance(transform.position,waters[i].transform.position) < MinDistance)
            {
                float dist = Vector3.Distance(transform.position,waters[i].transform.position);

                float distX = Mathf.Abs(scale + (transform.position.x - waters[i].transform.position.x));
                float distY = Mathf.Abs(scale + (transform.position.y - waters[i].transform.position.y));

                if(distY < MinDistance)
                {
                    if(transform.position.y -waters[i].transform.position.y < 0)
                    {
                        waters[i].transform.position = new Vector3(waters[i].transform.position.x, waters[i].transform.position.y - distY, 0);
                    }
                    else
                    {
                        waters[i].transform.position = new Vector3(waters[i].transform.position.x, waters[i].transform.position.y + distY, 0);
                    }
                }
                if(distX < MinDistance)
                {
                     if(transform.position.x -waters[i].transform.position.x < 0)
                    {
                        waters[i].transform.position = new Vector3(waters[i].transform.position.x - distX, waters[i].transform.position.y, 0);
                    }
                    else
                    {
                        waters[i].transform.position = new Vector3(waters[i].transform.position.x + distX, waters[i].transform.position.y, 0);
                    }
                }

                // waters[i].transform.position = new Vector3(waters[i].transform.position.x +((dist  + scale) * PullingForce), waters[i].transform.position.y + ((dist  + scale) * PullingForce), waters[i].transform.position.z);
            }
           
        }
       
        rb.velocity = new Vector3(rb.velocity.x + (x  / l) * DirForce, rb.velocity.y + (y / l) * DirForce, 0);
        
    }
}
