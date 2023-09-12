using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private float degreesPerSecond = 20f;

    private void Update()
    {
        transform.eulerAngles += new Vector3(0, degreesPerSecond * Time.unscaledDeltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance.IncreaseScore(5);
            Destroy(gameObject);
        }
    }
}
