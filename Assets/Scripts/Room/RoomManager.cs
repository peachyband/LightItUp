using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomManager : MonoBehaviour
{
    public Room[] roomsPrefabs;

    public int roomsCount = 0;

    private Dictionary<Vector2, Room> _existRoom = new Dictionary<Vector2, Room>();

    public static System.Random RANDOM = new System.Random();

    private Room currentRoom;

    void Start()
    {
        GenerateRoom(Vector2.zero);
        currentRoom = _existRoom[Vector2.zero];
        for(int i = 0; i < roomsCount - 1; i++)
        {
            AddRoom();
        }
        foreach(Room room in _existRoom.Values)
        {
            room.gameObject.SetActive(false);
        }
        _existRoom[Vector2.zero].gameObject.SetActive(true);
    }

    public void GenerateRoom(Vector2 position)
    {
        Room room = Instantiate(GetRandomRoom(), Vector2.zero, Quaternion.identity);
        room.position = position;
        _existRoom.Add(position, room);
        Room existRoom;
        if(_existRoom.TryGetValue(position + Vector2.up, out existRoom))
        {
            existRoom.AddDirection(Directions.Down);
        }
        if (_existRoom.TryGetValue(position + Vector2.down, out existRoom))
        {
            existRoom.AddDirection(Directions.Up);
        }
        if (_existRoom.TryGetValue(position + Vector2.left, out existRoom))
        {
            existRoom.AddDirection(Directions.Right);
        }
        if (_existRoom.TryGetValue(position + Vector2.right, out existRoom))
        {
            existRoom.AddDirection(Directions.Left);
        }
    }

    private Room GetRandomRoom()
    {
        int randnum = Random.Range(0, roomsCount - 1);
        return roomsPrefabs[randnum]; //TODO: Get random value from array
    }

    private void AddRoom()
    {
        Room room;
        List<Room> values = Enumerable.ToList(_existRoom.Values);
        int size = _existRoom.Count;
        do
        {
            room = values[RANDOM.Next(size)];
        } while (room.FreeDirection == 0);
        Directions dir = room.AddRandomDirection();
        Vector2 roomPosition = room.position;
        switch (dir)
        {
            case Directions.Up:
                roomPosition += Vector2.up;
                break;
            case Directions.Down:
                roomPosition += Vector2.down;
                break;
            case Directions.Left:
                roomPosition += Vector2.left;
                break;
            case Directions.Right:
                roomPosition += Vector2.right;
                break;
        }

        GenerateRoom(roomPosition);
        switch (dir)
        {
            case Directions.Up:
                _existRoom[roomPosition].AddDirection(Directions.Down);
                break;
            case Directions.Down:
                _existRoom[roomPosition].AddDirection(Directions.Up);
                break;
            case Directions.Left:
                _existRoom[roomPosition].AddDirection(Directions.Right);
                break;
            case Directions.Right:
                _existRoom[roomPosition].AddDirection(Directions.Left);
                break;
        }

    }

    public void ChangeRoom(Vector2 pos)
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0,0, -0.1f);
        Room room;
        if(_existRoom.TryGetValue(pos, out room))
        {
            currentRoom.gameObject.SetActive(false);
            room.gameObject.SetActive(true);
            currentRoom = room;
        }
        else
        {
            Debug.LogError("Room " + pos.ToString() + " not found");
        }
    }
}
