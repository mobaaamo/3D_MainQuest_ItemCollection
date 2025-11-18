using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotateSpeed = 2.0f;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private float smoothInputSpeed = 5.0f;
    [SerializeField] private LayerMask groundLayer;

    private Animator animator;
    private Rigidbody rb;
    private Vector3 smoothInput = Vector3.zero;

    private static readonly int moveSpeedHash = Animator.StringToHash("Speed");
    private static readonly int jumpHash = Animator.StringToHash("Jump");

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
        animator = GetComponent<Animator>();
    }


    void Update()
    {

        Move();
        Jump();
    }


    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movedir = (transform.forward * moveZ + transform.right * moveX).normalized;

        smoothInput = Vector3.Lerp(smoothInput, movedir, smoothInputSpeed*Time.deltaTime);

        if (smoothInput.sqrMagnitude > 0.01f && moveZ >= 0f)
        {
            Quaternion targetRot = Quaternion.LookRotation(smoothInput, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);
        }

        transform.Translate(smoothInput*moveSpeed*Time.deltaTime, Space.World);

        animator.SetFloat(moveSpeedHash, smoothInput.magnitude);

    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetBool(jumpHash, true);
        }
        else if(rb.velocity.y <= 0.05f)
        {
            animator.SetBool(jumpHash, false);
        }
    }
    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.5f, groundLayer);
    }

}
