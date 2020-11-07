using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public bool isRoomClosed = false; //TODO: chnge on True
    [HideInInspector]
    public Vector2 position;

    public RoomTeleport leftTeleport, rightTeleport, upTeleport, downTeleport;

    private RoomTeleport[] teleports;

    public int FreeDirection { get; private set; } = 4;

    private void Awake()
    {
        teleports = new RoomTeleport[] { upTeleport, downTeleport, leftTeleport, rightTeleport };
        foreach (RoomTeleport teleport in teleports)
        {
            teleport.gameObject.SetActive(false);
        }
    }

    public void AddDirection(Directions dir)
    {
        RoomTeleport teleport;
        Vector2 nextRoomPosition = new Vector2(position.x, position.y);
        switch (dir)
        {
            case Directions.Up:
                teleport = upTeleport;
                nextRoomPosition += Vector2.up;
                break;
            case Directions.Down:
                teleport = downTeleport;
                nextRoomPosition += Vector2.down;
                break;
            case Directions.Left:
                teleport = leftTeleport;
                nextRoomPosition += Vector2.left;
                break;
            default:
                teleport = rightTeleport;
                nextRoomPosition += Vector2.right;
                break;
        }
        teleport.coordinateNextRoom = nextRoomPosition;
        teleport.selfRoom = this;
        teleport.gameObject.SetActive(true);
        FreeDirection--;
    }

    public Directions AddRandomDirection()
    {
        int value = RoomManager.RANDOM.Next(FreeDirection - 1) + 1;
        int i = 0;
        while(value != 0)
        {
            if (teleports[i++].gameObject.activeSelf) continue;
            value--;
        }/*
        int i = 0;
        for(; i < teleports.Length; i++)
        {
            if (!teleports[i].gameObject.activeSelf) break;
        }*/
        i--;

        Directions direction;
        switch (i)
        {
            case 0:
                direction = Directions.Up;
                break;
            case 1:
                direction = Directions.Down;
                break;
            case 2:
                direction = Directions.Left;
                break;
            default:
                direction = Directions.Right;
                break;
        }
        AddDirection(direction);
        return direction;
    }
}
