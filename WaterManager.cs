using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WaterManager : MonoBehaviour
{
    [SerializeField]
    float MaxY;

    [SerializeField]
    float MinY;

    [SerializeField]
    float MaxX;

    [SerializeField]
    float MinX;

    void Update()
    {
        GameObject[] waters = GameObject.FindGameObjectsWithTag("Water");
        for(int i = 0; i < waters.Length; i++)
        {
            if(waters[i].transform.position.x < MinX || waters[i].transform.position.x >  MaxX)
            {
                if(Mathf.Abs(waters[i].transform.position.x -  MinX) < Mathf.Abs(waters[i].transform.position.x -  MaxX))
                {
                    waters[i].transform.position = new Vector3(MinX, waters[i].transform.position.y, 0);
                }
                else
                {
                    waters[i].transform.position = new Vector3(MaxX, waters[i].transform.position.y, 0);
                }
                
            }  
            if(waters[i].transform.position.y < MinY || waters[i].transform.position.y >  MaxY)
            {
                if(Mathf.Abs(waters[i].transform.position.y -  MinY) < Mathf.Abs(waters[i].transform.position.y -  MaxY))
                {
                    waters[i].transform.position = new Vector3(waters[i].transform.position.x, MinY, 0);
                }
                else
                {
                    waters[i].transform.position = new Vector3(waters[i].transform.position.x, MaxY, 0);
                }
            }
        }
        
    }
}
