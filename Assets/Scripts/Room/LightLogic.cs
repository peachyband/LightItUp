using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLogic : MonoBehaviour
{
    public Room doorctrl;
    private GameObject player;

    void Start()
    {
        if (gameObject.activeSelf)
        {
            doorctrl.isRoomClosed = false;
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().SetLamps();
        }    
    }

   
}
