using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	//todo dictonary

	//get a random room that is not the current room
	public GameObject br(GameObject r) => bottomRooms.ToArray()[Random.Range(0, bottomRooms.Length-1)];
	public GameObject tr(GameObject r) => topRooms.ToArray()[Random.Range(0, topRooms.Length-1)];
	public GameObject lr(GameObject r) => leftRooms.ToArray()[Random.Range(0, leftRooms.Length-1)];
	public GameObject rr(GameObject r) => rightRooms.ToArray()[Random.Range(0, rightRooms.Length-1)];


	public GameObject closedRoom;

	public List<GameObject> rooms;

	public float waitTime;
	private bool spawnedBoss;
	public GameObject boss;

	void Update(){

		if(waitTime <= 0 && spawnedBoss == false){
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-1){
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
