using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

	public int openingDirection;
	// 1 --> need bottom door
	// 2 --> need top door
	// 3 --> need left door
	// 4 --> need right door


	private RoomTemplates templates;
	private int rand;
	public bool spawned = false;
	public int minRoom;
	private static int rooms = 0;
	private GameObject room;
	public float waitTime = 4f;

	void Start()
	{
		Destroy(gameObject, waitTime);
		templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
		Invoke("Spawn", 0.1f);
	}


	void Spawn()
	{
		if (spawned == false)
		{

			if (openingDirection == 1)
			{
				room = templates.tr(this.gameObject);
			}
			else if (openingDirection == 2)
			{
				room = templates.rr(this.gameObject);
			}
			else if (openingDirection == 3)
			{
				room = templates.br(this.gameObject);
			}
			else if (openingDirection == 4)
			{
				room = templates.lr(this.gameObject);
			}
			Instantiate(room, transform.position, room.transform.rotation);

			rooms++;
			spawned = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		other.CheckArgument();

		if (other.CompareTag("SpawnPoint"))
		{
			if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
			{
				Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
				Destroy(gameObject);
			}
			spawned = true;
		}
	}
}
