using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public int bLength => bottomRooms.Length;
    public int tLength => topRooms.Length;
    public int lLength => leftRooms.Length;
    public int rLength => rightRooms.Length;

}
