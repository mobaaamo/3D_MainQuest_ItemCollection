using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }


    void Update()
    {

        Move();

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }


    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0.0f, moveZ).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime);

    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.0f, groundLayer);
    }
}
