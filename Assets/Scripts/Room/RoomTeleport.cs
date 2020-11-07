using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTeleport : MonoBehaviour
{
    public Vector2 coordinateNextRoom;
    public Room selfRoom;

    public RoomManager _manager;
    private void Start()
    {
        _manager = GameObject.FindGameObjectWithTag("RoomManager").GetComponent<RoomManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (selfRoom.isRoomClosed) return;
        _manager.ChangeRoom(coordinateNextRoom);
    }

}
