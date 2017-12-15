using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 movement;
    private Animator animator;
    private Rigidbody playerRigdbody;
    private int floorMask;                //A layer mask so that a ray can be cast just at gameobjects on the floor layer;
    private float camRayLength = 100f;

    private void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        animator = GetComponent<Animator>();
        playerRigdbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        Move(h, v);
        Turning();
        Animating(h, v);
    }

    private void Move(float h, float v)
    {
        movement.Set(h, 0, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigdbody.MovePosition(transform.position + movement);

        // 把drag 设置为0 下面一行代码可以达到移动效果
        //playerRigdbody.velocity = movement;

    }

    private void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigdbody.MoveRotation(newRotation);
        }
    }

    private void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        Debug.Log(walking);
        animator.SetBool("IsWalking", walking);
    }


}
