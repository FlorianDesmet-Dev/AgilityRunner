using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 6f;

    [SerializeField] private GameObject VFXRun;

    public float SpeedRun
    {
        get
        {
            return speed;
        }
    }

    private float speedShift = 6f;
    private float rightBound = 2f;
    private float leftBound = -2f;

    private bool lane1 = false;
    private bool lane2 = true;
    private bool lane3 = false;
    private bool toRight = false;
    private bool toLeft = false;

    public static bool ToMove { get; private set; }

    private void Awake()
    {
        ToMove = false;
        VFXRun.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.start)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && PlayerController.IsGrounded)
            {
                toRight = true;
                toLeft = false;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && PlayerController.IsGrounded)
            {
                toLeft = true;
                toRight = false;
            }

            if (toRight && !lane3 && lane1)
            {
                lane2 = true;
                lane1 = false;
                lane3 = false;
                toRight = false;
            }
            else if (toLeft && lane2 && transform.position.x <= 0.2f)
            {
                lane1 = true;
                lane2 = false;
                lane3 = false;
                toLeft = false;
            }
            else if (toRight && lane2 && transform.position.x >= -0.2f)
            {
                lane3 = true;
                lane2 = false;
                lane1 = false;
                toRight = false;
            }
            else if (toLeft && !lane1 && lane3)
            {
                lane2 = true;
                lane1 = false;
                lane3 = false;
                toLeft = false;
            }

            if (lane3 && transform.position.x < rightBound)
            {
                transform.Translate(Vector3.right * speedShift * Time.deltaTime);
                ToMove = true;
            } 
            else if (lane1 & transform.position.x > leftBound)
            {
                transform.Translate(Vector3.left * speedShift * Time.deltaTime);
                ToMove = true;
            }
            else if (lane2 && transform.position.x <= -0.1f)
            {
                transform.Translate(Vector3.right * speedShift * Time.deltaTime);
                ToMove = true;
            }
            else if (lane2 && transform.position.x >= 0.1f)
            {
                transform.Translate(Vector3.left * speedShift * Time.deltaTime);
                ToMove = true;
            }
            else
            {
                ToMove = false;
            }

            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            
            if (PlayerController.IsGrounded && !PlayerController.GameOver)
            {
                VFXRun.SetActive(true);
            }
            else
            {
                VFXRun.SetActive(false);
            }
        }
    }
}
