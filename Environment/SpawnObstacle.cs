using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] objectPrefab;
    [SerializeField] private Vector3 zoneSize;

    private void Start()
    {
        int randomPrefab = Random.Range(0, objectPrefab.Length - 1);
        GameObject clone = Instantiate(objectPrefab[randomPrefab], transform);

        clone.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, zoneSize);
    }
}
