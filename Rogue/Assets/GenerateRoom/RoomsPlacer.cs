using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomsPlacer : MonoBehaviour
{
    public Room[] RoomPrefabs;
    public Room StartingRoom;
    public Room[] PlacedRooms;
    public Room[,] spawnedRooms;
    public HashSet<Vector2Int> vacantPlaces;
    public Room BossRoom;
    public GameObject player;
    Room FarthersRoom;
    public Room alo;
    public static int Count = 0;

    private IEnumerator Start()
    {
        PlacedRooms = new Room[12];
        spawnedRooms = new Room[11, 11];
        spawnedRooms[5, 5] = StartingRoom;
        Vector3 CordsPlayer = player.transform.position;
        

        for (int i = 0; i < 12; i++)
        {
            yield return new WaitForSecondsRealtime(0.001f);
            PlaceOneRoom();
        }
        PlaceBossRoom(BossRoom, FindFarthestRoom(PlacedRooms, CordsPlayer).transform);
    }

    private void PlaceOneRoom()
    {
        vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x, y] == null) continue;

                int maxX = spawnedRooms.GetLength(0) - 1;
                int maxY = spawnedRooms.GetLength(1) - 1;

                if (x > 0 && spawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                if (y > 0 && spawnedRooms[x, y - 1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                if (x < maxX && spawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }

        // ��� ������� ����� �������� �� ����� ������� � ������ � �����������, ����� ��� � ChunksPlacer.GetRandomChunk()
        Room newRoom = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]);
        newRoom.gameObject.name = $"room {Count++}";
        alo = newRoom;
        int limit = 500;
        while (limit-- > 0)
        {
            // ��� ������� ����� �������� �� ����� ��������� ������� � ������ ���� ��������� �� ������/������ �� ������,
            // ��� ������� � ���� �������, ����� ������������ ����� �������, ��� ��������, ���������� �����
            Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));
            

            if (ConnectToSomething(newRoom, position))
            {
                newRoom.transform.position = new Vector3(position.x - 5, 0, position.y - 5) * 12;
                spawnedRooms[position.x, position.y] = newRoom;
                for (int i = 0; i < 12; i++)
                {
                    if (PlacedRooms[i] == null)
                    {
                        PlacedRooms[i] = newRoom;
                        break;
                    }
                }
                return;
            }
        }
        

        newRoom.RotateRandomly();
        Destroy(newRoom.gameObject);
    }

    private bool ConnectToSomething(Room room, Vector2Int p)
    {
        int maxX = spawnedRooms.GetLength(0) - 1;
        int maxY = spawnedRooms.GetLength(1) - 1;

        List<Vector2Int> neighbours = new List<Vector2Int>();

        if (room.DoorU != null && p.y < maxY && spawnedRooms[p.x, p.y + 1]?.DoorD != null) neighbours.Add(Vector2Int.up);
        if (room.DoorD != null && p.y > 0 && spawnedRooms[p.x, p.y - 1]?.DoorU != null) neighbours.Add(Vector2Int.down);
        if (room.DoorR != null && p.x < maxX && spawnedRooms[p.x + 1, p.y]?.DoorL != null) neighbours.Add(Vector2Int.right);
        if (room.DoorL != null && p.x > 0 && spawnedRooms[p.x - 1, p.y]?.DoorR != null) neighbours.Add(Vector2Int.left);

        if (neighbours.Count == 0) return false;

        Vector2Int selectedDirection = neighbours[Random.Range(0, neighbours.Count)];
        Room selectedRoom = spawnedRooms[p.x + selectedDirection.x, p.y + selectedDirection.y];

        if (selectedDirection == Vector2Int.up)
        {
            room.DoorU.SetActive(false);
            selectedRoom.DoorD.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.down)
        {
            room.DoorD.SetActive(false);
            selectedRoom.DoorU.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.right)
        {
            room.DoorR.SetActive(false);
            selectedRoom.DoorL.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.left)
        {
            room.DoorL.SetActive(false);
            selectedRoom.DoorR.SetActive(false);
        }

        return true;
    }

    public GameObject FindFarthestRoom(Room[] rooms, Vector3 startPoint)
    {
        Transform farthestRoom = null;
        float maxDistance = 0;

        foreach (Room room in rooms)
        {
            float distance = Vector3.Distance(startPoint, room.transform.position);
            if (distance > maxDistance)
            {
                maxDistance = distance;
                farthestRoom = room.transform;
                FarthersRoom = room;
            }
        }

        return farthestRoom.gameObject;
    }

    public void PlaceBossRoom(Room bossRoom, Transform cords)
    {

        
        GameObject DoorU = FarthersRoom.DoorU;
        GameObject DoorD = FarthersRoom.DoorD;
        GameObject DoorR = FarthersRoom.DoorR;
        GameObject DoorL = FarthersRoom.DoorL;
        Destroy(FarthersRoom.gameObject);
        Vector3 Cords = cords.position;
        Quaternion Rotation = cords.rotation;
        Room boss = Instantiate(bossRoom);
        boss.transform.position = Cords;
        boss.transform.rotation = Rotation;
        if (DoorU.activeSelf == false)
        {
            boss.DoorU.SetActive(false);
        }
        else if (DoorD.activeSelf == false)
        {
            boss.DoorD.SetActive(false);
           
        }
        else if (DoorR.activeSelf == false)
        {
            boss.DoorR.SetActive(false);
           
        }
        else if (DoorL.activeSelf == false)
        {
            boss.DoorL.SetActive(false);
            
        }
    }
}