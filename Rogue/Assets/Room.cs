using UnityEngine;

public class Room : MonoBehaviour
{
    public int EnemyCount;
    public GameObject DoorU;
    public GameObject DoorR;
    public GameObject DoorD;
    public GameObject DoorL;
    Component[] Rigids;
    GameObject[] Alo;


    private void Start()
    {
        Rigids = GetComponentsInChildren<Transform>();
        foreach (Component component in Rigids)
        {
            if (component.gameObject.name == "skeleton_enemy") // Если объект неактивен
            {
                EnemyCount += 1;
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
    //public void Update()
    //{
        //Rigids = GetComponentsInChildren<Transform>();
        
    //}
}