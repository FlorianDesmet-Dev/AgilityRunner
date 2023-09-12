using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectPrefab;

    [SerializeField] 
    private Transform[] spawnPoints;

    private void Start()
    {
        for (int i = 0;  i < spawnPoints.Length; i++)
        {
            int randomPrefab = Random.Range(0, objectPrefab.Length - 1);

            GameObject clone = Instantiate(objectPrefab[randomPrefab], transform);
            clone.transform.position = new Vector3(spawnPoints[i].position.x, spawnPoints[i].position.y, spawnPoints[i].position.z);
        }
    }
}
