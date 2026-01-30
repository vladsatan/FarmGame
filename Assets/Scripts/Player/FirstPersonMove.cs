using UnityEngine;

public class FirstPersonMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    public float runSpeed = 8f;

    public float walkSpeed = 5f;

    public float gravity = -25f;

    public float jumpForce = 7f;

    private float velocityY;

    private CharacterController controller;
    public void Start ()
    {
        controller = GetComponent<CharacterController>();
        velocityY = 0f;
    }

    public void Update ()
    {
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        bool run = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool jump = Input.GetKeyDown(KeyCode.Space);

        bool grounded = controller.isGrounded;  

        if (grounded && velocityY < 0f) velocityY = -2f;
        if (grounded && jump) velocityY = jumpForce;
        velocityY += gravity * Time.deltaTime;

        if(run && z > 0){moveSpeed = runSpeed;}
        else{moveSpeed = walkSpeed;}

        Vector3 directionForward = transform.forward * z;

        Vector3 directionRight = transform.right * x;

        Vector3 direction = directionForward + directionRight;

        if(direction.magnitude > 1f){direction = direction.normalized;}
        
        direction *= moveSpeed;

        direction.y = velocityY;

        controller.Move(direction * Time.deltaTime);

    }
}
