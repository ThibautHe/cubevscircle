using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Rigidbody rb;
    [SerializeField] private Animator anim;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float Yspeed = 5f;
    private float lastDirection = 1f;
    public bool canClimb = false;
    public bool isClimbing = false;

    private float moveY = 0f;
    private float moveX = 0f;

    private float ladderX = 0f;

    private bool IsGrounded()
    {
        // Distance du rayon sous le joueur
        float groundCheckDistance = 1f;
        // Le layer du sol (assurez-vous que vos objets de sol ont bien ce layer)
        LayerMask groundLayer = LayerMask.GetMask("ground");

        // Position de départ du rayon (juste sous le joueur)
        Vector3 rayStart = transform.position;

        // Direction du rayon (vers le bas)
        Vector3 rayDirection = Vector3.down;

        // Dessine un rayon visuellement dans la scène pour le debugger
        Debug.DrawRay(rayStart, rayDirection * groundCheckDistance, Color.red, 1f); // 0.1f est la durée durant laquelle le rayon est visible

        // Si le rayon touche le sol, la fonction retourne true
        return Physics.Raycast(rayStart, rayDirection, groundCheckDistance, groundLayer);
    }

    public void SetLadderX(Transform t)
    {
        ladderX = t.position.x;
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        anim.SetBool("grounded", IsGrounded());
        moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right Arrow

        if (canClimb)
        {
            moveY = Input.GetAxisRaw("Vertical"); // W/S or Up/Down Arrow
            if (moveY > 0 || (moveY < 0 && !IsGrounded()))
            {
                gameObject.transform.position = new Vector3(ladderX, gameObject.transform.position.y, 0);
                lastDirection = 0;
                anim.SetBool("isClimbing", true);
            }else
            {
                anim.SetBool("isClimbing", false);
            }

            if (!IsGrounded())
            {
                moveX = 0;
            }

            rb.useGravity = false;

        }
        else
        {
            rb.useGravity = true;
            anim.SetBool("isClimbing", false);
        }
    }


    void FixedUpdate()
    {
        // Set velocity only on the X-axis, preserving Y for gravity
        if (!canClimb || IsGrounded())
        {
            if (moveX != 0)
            {
                lastDirection = moveX; // Update last direction when moving
            }

            rb.linearVelocity = new Vector3(moveX * speed, rb.linearVelocity.y, 0f);
        }

        anim.SetBool("isleft", lastDirection < 0);
        anim.SetBool("isRunning", moveX != 0);

        anim.SetFloat("speed", Mathf.Round(moveX));
        anim.gameObject.transform.rotation = Quaternion.Euler(0, lastDirection < 0 ? -90 : 90, 0);

        if (canClimb)
        {
            rb.linearVelocity = new Vector3(moveX * speed, moveY * Yspeed, 0f);
        }

    }
}
