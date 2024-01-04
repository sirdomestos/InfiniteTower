using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomObject : MonoBehaviour
{
    public int x;
    public int y;

    public void Init(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    private void Start()
    {
        var controller = LevelController.levelController;

        if(x < 4 && controller.Rooms[x+1, y] != null)
        {
            OpenDoor(0);
        }
        if (x > 0 && controller.Rooms[x - 1, y] != null)
        {
            OpenDoor(1);
        }
        if (y < 4 && controller.Rooms[x, y + 1] != null)
        {
            OpenDoor(2);
        }
        if (y > 0 && controller.Rooms[x, y - 1] != null)
        {
            OpenDoor(3);
        }
    }

    public void OpenDoor(int door)
    {
        Walls[door].SetActive(false);
        Doors[door].SetActive(true);
    }

    public GameObject[] Doors;
    public GameObject[] Walls;
}
