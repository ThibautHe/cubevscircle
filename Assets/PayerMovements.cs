using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    [SerializeField]private Animator anim;

    [SerializeField]private float speed = 5f;
    private float lastDirection = 1f; 
    public bool canClimb = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow

        if (moveX != 0)
        {
            lastDirection = moveX; // Update last direction when moving
        }


        // Set velocity only on the X-axis, preserving Y for gravity
        rb.linearVelocity = new Vector3(moveX * speed, rb.linearVelocity.y, 0f);
        anim.SetBool("isleft", lastDirection < 0);
        Debug.Log(moveX);
        anim.SetBool("isRunning", moveX != 0);

        Debug.Log(Mathf.Round(moveX));
        anim.SetFloat("speed", Mathf.Round(moveX));
        anim.gameObject.transform.rotation = Quaternion.Euler(0, lastDirection < 0 ? -90 : 90, 0);

        if (canClimb)
        {
            float moveY = Input.GetAxisRaw("Vertical"); // W/S or Up/Down Arrow
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, moveY * speed, 0f);
        }
    }
}
