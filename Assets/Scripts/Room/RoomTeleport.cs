using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTeleport : MonoBehaviour
{
    [HideInInspector]
    public Vector2 coordinateNextRoom;
    [HideInInspector]
    public Room selfRoom;
    [HideInInspector]
    public RoomManager _manager;
    private void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            if (selfRoom.isRoomClosed) return;
            _manager.ChangeRoom(coordinateNextRoom);
        }
    }

}
