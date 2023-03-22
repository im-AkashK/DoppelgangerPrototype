using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Movement speed of the player
    [SerializeField] private Animator animator; // The animator component attached to the player GameObject

    private Vector2 facingDirection = Vector2.up; // Current facing direction of the player

    void Start()
    {
        animator.SetFloat("Horizontal", 0);
        animator.SetFloat("Vertical", 1);
    }

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput).normalized * speed * Time.deltaTime;

        // Update facing direction based on movement input
        if (movement != Vector3.zero)
        {
            facingDirection = new Vector2(movement.x, movement.z);
        }

        // Update player position
        transform.position += movement;

        // Update animation
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        // Set the animation for the player's current facing direction
        animator.SetFloat("Horizontal", facingDirection.x);
        animator.SetFloat("Vertical", facingDirection.y);
    }
}
