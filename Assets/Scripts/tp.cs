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
                case "door_l":
                    other.transform.position += new Vector3(-transform.localScale.x, 0, 0);
                    Camera.main.transform.position += new Vector3(-cam_distx, 0, 0);
                    transform.tag = "door_r";
                    break;
                case "door_r":
                    other.transform.position += new Vector3(transform.localScale.x, 0, 0);
                    Camera.main.transform.position += new Vector3(cam_distx, 0, 0);
                    transform.tag = "door_l";
                    break;
                case "door_up":
                    other.transform.position += new Vector3(0, transform.localScale.x, 0);
                    Camera.main.transform.position += new Vector3(0, cam_disty, 0);
                    transform.tag = "door_d";
                    break;
                case "door_d":
                    other.transform.position += new Vector3(0, -transform.localScale.x, 0);
                    Camera.main.transform.position += new Vector3(0, -cam_disty, 0);
                    transform.tag = "door_up";
                    break;
            }
        }
        
     }
}
