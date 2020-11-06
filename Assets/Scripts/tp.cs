using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tp : MonoBehaviour
{
    float cam_distx = 20f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player") {
            switch (transform.tag)
            {
                case "door_l":
                    other.transform.position += new Vector3(-transform.position.x/2, 0, 0);
                    Camera.main.transform.position += new Vector3(-cam_distx, 0, 0);
                    transform.tag = "door_r";
                    break;
                case "door_r":
                    other.transform.position += new Vector3(transform.position.x/2, 0, 0);
                    Camera.main.transform.position += new Vector3(cam_distx, 0, 0);
                    transform.tag = "door_l";
                    break;
                case "door_up":

                    break;
                case "door_d":

                    break;
            }
        }
        
     }
}
