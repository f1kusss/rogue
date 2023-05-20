using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Room : MonoBehaviour
{
    public int EnemyCount=>RigidsList.Count;
    public GameObject DoorU;
    public GameObject DoorR;
    public GameObject DoorD;
    public GameObject DoorL;
    public List<Transform> RigidsList;

    private void Start()
    {
        RigidsList = new List<Transform>();
        var allObjects = GetComponentsInChildren<Transform>();

        foreach (Transform item in allObjects)
        {
            if (item.gameObject.name == "skeleton_enemy")
            {

                RigidsList.Add(item);
            }
        }
    }

    public void RotateRandomly()
    {
        int count = Random.Range(0, 4);

        for (int i = 0; i < count; i++)
        {
            transform.Rotate(0, 90, 0);

            GameObject tmp = DoorL;
            DoorL = DoorD;
            DoorD = DoorR;
            DoorR = DoorU;
            DoorU = tmp;
        }
    }
}