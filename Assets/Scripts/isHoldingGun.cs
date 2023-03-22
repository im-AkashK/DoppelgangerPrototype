using UnityEngine;

public class isHoldingGun : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public bool isHoldinggun;

    private void Update()
    {
       

        // Set animator parameters
        //animator.SetFloat("Speed", movement.magnitude);
        animator.SetBool("IsHoldingGun", isHoldinggun);
    }
}