using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;

    private void Update()
    {
        if (GameManager.start)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
