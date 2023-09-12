using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    private void Update()
    {
        if (GameManager.start)
        {
            playerAnimator.SetBool("Run", true);

            if (!PlayerController.IsGrounded)
            {
                playerAnimator.SetBool("Jump", true);
            }
            else
            {
                playerAnimator.SetBool("Jump", false);
            }
        } 
        else
        {
            playerAnimator.SetBool("Run", false);
        }
    }
}
