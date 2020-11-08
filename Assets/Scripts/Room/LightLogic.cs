using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLogic : MonoBehaviour
{
    private GameObject player;
    public Room doorctrl;

    void Start(){
        if (gameObject.activeSelf) {
            player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerMovement>().SetLamp();
            doorctrl.isRoomClosed = false;
        }
    }

}
