using UnityEngine;

public class DestroyGround : MonoBehaviour
{
    private GameObject dog;
    private float groundSize;

    private void Start()
    {
        dog = GameObject.Find("Dog");
        groundSize = GetComponentInChildren<Transform>().Find("Floor").localScale.z;
    }

    void Update()
    {
        if (transform.position.z + (groundSize / 2) < dog.transform.position.z - 5f)
        {
            Destroy(gameObject);
        }
    }
}
