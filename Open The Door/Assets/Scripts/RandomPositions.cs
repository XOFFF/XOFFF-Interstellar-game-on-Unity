using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPositions : MonoBehaviour
{
    public GameObject plane;
    public GameObject chest;
    public GameObject key;
    public GameObject door;
    public GameObject wall_1;
    public GameObject wall_2;
    public GameObject wall_3;
    public GameObject wall_4;

    float chestYAxis = -0.25f;
    float keyYAxis = 1.3f;
    float doorYAxis = 0.95f;
    float wallYAxis = 1f;

    Vector3 planeBounds;

    Vector3 randChestAndKeyPos;
    Vector3 randDoor;

    void Start()
    {
        plane.transform.position = new Vector3(0,0,0);
        plane.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        planeBounds = plane.GetComponent<Renderer>().bounds.size / 2;

        SpawnObjects();
        SpawnWalls();
    }

    public void SpawnObjects()
    {
        chestAndKeySpawn();
        chestAndKeyRotation();
        doorSpawn();
    }

    void chestAndKeySpawn()
    {
        float randomMultiply = Random.Range(0f, 1f);
        float randomX = Random.Range(0f, planeBounds.x - 2f);
        float randomZ = Random.Range(0f, planeBounds.z - 2f);
        if (randomMultiply >= 0.5f)
        {
            randomX *= 1;
            randomZ *= 1;
        }
        else
        {
            randomX *= -1;
            randomZ *= -1;
        }

        randChestAndKeyPos = new Vector3(randomX, chestYAxis, randomZ);
        chest.transform.position = randChestAndKeyPos;

        randChestAndKeyPos = new Vector3(randomX + 0.1f, keyYAxis, randomZ);
        key.transform.position = randChestAndKeyPos;
    }

    void chestAndKeyRotation()
    {
        Vector3 randEuler = chest.transform.eulerAngles;
        randEuler.y = Random.Range(0, 360f);
        chest.transform.eulerAngles = key.transform.eulerAngles = randEuler;
    }

    void doorSpawn()
    {
        float randomSide = Random.Range(0, 4);

        float side = planeBounds.x + 0.5f;

        switch (randomSide)
        {
            case 0:
                randDoor = new Vector3(side, doorYAxis, 0);
                door.transform.eulerAngles = new Vector3(0, 180, 0);
                break;
            case 1:
                randDoor = new Vector3(-side, doorYAxis, 0);
                door.transform.eulerAngles = new Vector3(0, 0, 0);
                break;
            case 2:
                randDoor = new Vector3(0, doorYAxis, side);
                door.transform.eulerAngles = new Vector3(0, 90, 0);
                break;
            case 3:
                randDoor = new Vector3(0, doorYAxis, -side);
                door.transform.eulerAngles = new Vector3(0, -90, 0);
                break;
            default:
                break;
        }

        door.transform.position = randDoor;
    }

    void SpawnWalls()
    {
        wall_1.transform.position = new Vector3(planeBounds.x, wallYAxis, 0);
        wall_1.transform.eulerAngles = new Vector3(0, 90, 0);
        wall_2.transform.position = new Vector3(-planeBounds.x, wallYAxis, 0);
        wall_2.transform.eulerAngles = new Vector3(0, 90, 0);
        wall_3.transform.position = new Vector3(0, wallYAxis, planeBounds.x);
        wall_3.transform.eulerAngles = new Vector3(0, 0, 0);
        wall_4.transform.position = new Vector3(0, wallYAxis, -planeBounds.x);
        wall_4.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
