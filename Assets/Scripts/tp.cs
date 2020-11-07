using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tp : MonoBehaviour
{
    float cam_distx = 20f;
    float cam_disty = 12f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player") {
            switch (transform.tag)
            {
                case "door_x":
                    float difx = other.transform.position.x - transform.position.x;
                    if (difx < 0)
                    {
                        other.transform.position += new Vector3(transform.localScale.x, 0, 0);
                        Camera.main.transform.position += new Vector3(cam_distx, 0, 0);
                    }
                    else if (difx > 0)
                    {
                        other.transform.position += new Vector3(-transform.localScale.x, 0, 0);
                        Camera.main.transform.position += new Vector3(-cam_distx, 0, 0);
                    }
                    break;
                case "door_y":
                    float dify = other.transform.position.y - transform.position.y;
                    if (dify < 0)
                    {
                        other.transform.position += new Vector3(0, transform.localScale.x, 0);
                        Camera.main.transform.position += new Vector3(0, cam_disty, 0);
                    }
                    else if (dify > 0)
                    {
                        other.transform.position += new Vector3(0, -transform.localScale.x, 0);
                        Camera.main.transform.position += new Vector3(0, -cam_disty, 0);
                    }
                    break;
                
            }
            
        }
        
     }
}
