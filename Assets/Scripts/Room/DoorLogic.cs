using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour
{
    public Room doorctrl;
    private SpriteRenderer sprtctrl;
    public Sprite closeddoor;
    public Sprite openeddoor;

    private void Start()
    {
        doorctrl = gameObject.GetComponent<Room>();
        sprtctrl = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (doorctrl.isRoomClosed)
        {
            sprtctrl.sprite = closeddoor;
        }
        else sprtctrl.sprite = openeddoor;
    }
}
