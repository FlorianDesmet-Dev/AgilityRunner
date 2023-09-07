using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] groundsPrefabs;
    private GameObject[] groundsOnStage;
    private GameObject dog;
    private int numberOfGrounds = 10;

    private float groundSize;

    private void Start()
    {
        dog = GameObject.Find("Dog");
        groundsOnStage = new GameObject[numberOfGrounds];

        for (int i = 0; i < numberOfGrounds; i++)
        {
            int n = Random.Range(0, groundsPrefabs.Length - 1);
            groundsOnStage[i] = Instantiate(groundsPrefabs[n], transform);
        }

        groundSize = groundsOnStage[0].GetComponentInChildren<Transform>().Find("Floor").localScale.z;

        float pos = groundSize;
        foreach (var ground in groundsOnStage)
        {
            ground.transform.position = new Vector3(0, 0.2f, pos);
            pos += groundSize;
        }
    }

    private void Update()
    {
        for (int i = groundsOnStage.Length - 1; i >= 0; i--)
        {
            GameObject ground = groundsOnStage[i];

            if (ground.transform.position.z + (groundSize / 2) < dog.transform.position.z - 5f)
            {
                float z = ground.transform.position.z;
                int n = Random.Range(0, groundsPrefabs.Length - 1);
                ground = Instantiate(groundsPrefabs[n], transform);
                Debug.Log("Grounds spawn");
                ground.transform.position = new Vector3(0, 0.2f, z + groundSize * numberOfGrounds);
                groundsOnStage[i] = ground;
            }
        }
    }
}
