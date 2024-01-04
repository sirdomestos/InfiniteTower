using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using Random = UnityEngine.Random;

public class LevelController : MonoBehaviour
{
    public static LevelController levelController;

    public RoomObject RoomPrefab;

    public RoomObject[,] Rooms = new RoomObject[5,5];

    void Awake()
    {
        levelController = this;

        var me = GetComponent<RoomObject>();
        me.Init(2, 2);
        Rooms[2, 2] = me;
        int rmk = Random.Range(0, (int)Mathf.Pow(2, 16));

        GenerateRoom(3, 2, (roomCon)(rmk & 0b_0000_0000_0000_1111 >> 0), me); //Right
        GenerateRoom(1, 2, (roomCon)(rmk & 0b_0000_0000_1111_0000 >> 4), me); //Left
        GenerateRoom(2, 3, (roomCon)(rmk & 0b_0000_1111_0000_0000 >> 8), me); //Top
        GenerateRoom(2, 1, (roomCon)(rmk & 0b_1111_0000_0000_0000 >> 12), me); //Bottom
    }


    public void GenerateRoom(int x, int y, roomCon cost, RoomObject connectedRoom)
    {
        if (Rooms[x, y] != null) return;

        var room = Instantiate(RoomPrefab);
        room.transform.position = new Vector3((x-2) * 14, (y-2) * 8, 0);

        if (cost.HasFlag(roomCon.right))
        {
            GenerateRoom(x + 1, y, roomCon.nothing, room);
        }
        if (cost.HasFlag(roomCon.left))
        {
            GenerateRoom(x - 1, y, roomCon.nothing, room);
        }
        if (cost.HasFlag(roomCon.top))
        {
            GenerateRoom(x, y + 1, roomCon.nothing, room);
        }
        if (cost.HasFlag(roomCon.bottom))
        {
            GenerateRoom(x, y - 1, roomCon.nothing, room);
        }
        Rooms[x, y] = room;
        room.Init(x, y);
    }

    [Flags]
    public enum roomCon : int
    {
        nothing =0b0000,
        right =  0b0001,
        left =   0b0010,
        top =    0b0100,
        bottom = 0b1000,
    }
}
