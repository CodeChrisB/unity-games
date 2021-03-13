using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int OpeningDirection;
    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 3f);
    }




    // Update is called once per frame
    void Spawn()
    {
        //already spawned room
        if (spawned)
        {
            return;
        }

        spawned = true;
        Vector3 pos = this.transform.position;
        pos.x += 6f;
        switch (OpeningDirection)
        {
            case (int)DoorPos.Top:
                Debug.Log($"x{transform.position.x}   y{transform.position.y}");
                Instantiate(templates.bottomRooms[Random.Range(0, templates.tLength)],pos,transform.rotation);
                break;
            /*case (int)DoorPos.Right:
                Instantiate(templates.rightRooms[Random.Range(0, templates.rLength)], transform.position, Quaternion.identity);
                break;
            case (int)DoorPos.Bottom:
                Instantiate(templates.bottomRooms[Random.Range(0, templates.bLength)], transform.position, Quaternion.identity);
                break;
            case (int)DoorPos.Left:
                Instantiate(templates.leftRooms[Random.Range(0, templates.lLength)], transform.position, Quaternion.identity);
                break;*/
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint") && collision.GetComponent<RoomSpawner>().spawned)
            Destroy(gameObject);
    }
}
