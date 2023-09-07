using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private GameObject VFXJump;

    [SerializeField] private AudioSource audioSource;

    public Rigidbody rb;
    public float jumpAmount = 6f;

    private void Awake()
    {
        VFXJump.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.start && PlayerController.IsGrounded)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && !PlayerMove.ToMove)
            {
                Debug.Log(string.Format("Is grounded : {0}", PlayerController.IsGrounded));
                Jump();
            }
        }

        VFXJump.transform.position = new Vector3(transform.position.x, 0.3f, transform.position.z);

        if (PlayerController.IsGrounded)
        {
            VFXJump.SetActive(false);
        }
    }

    void Jump()
    {
        VFXJump.SetActive(true);
        audioSource.Play();
        rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
        PlayerController.IsGrounded = false;
    }
}
