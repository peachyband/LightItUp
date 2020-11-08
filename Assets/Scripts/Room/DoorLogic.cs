using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public Room doorctrl;
    public SpriteRenderer sprtctrl;
    public Sprite closeddoor;
    public Sprite openeddoor;

    void Update()
    {
        if (doorctrl.GetComponent<Room>().isRoomClosed)
        {
            sprtctrl.GetComponent<SpriteRenderer>().sprite = closeddoor;
        }
        else sprtctrl.GetComponent<SpriteRenderer>().sprite = openeddoor;
    }
}
