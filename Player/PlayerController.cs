using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioSource2;

    [SerializeField] GameObject VFXCollision;

    public static bool IsGrounded = true;
    public static bool GameOver { get; private set; }

    private void Awake()
    {
        GameOver = false;
        VFXCollision.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            IsGrounded = true;
            Debug.Log(string.Format("Is grounded : {0}", IsGrounded));
        }

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            audioSource.Play();
            VFXCollision.SetActive(true);
            GameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            audioSource2.Play();
        }
    }
}
