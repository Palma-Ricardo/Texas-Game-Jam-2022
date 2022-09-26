using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D coll;
    public Collider2D groundCollider;
    public SpriteRenderer spriteRenderer;

    public Sprite positiveSprite;
    public Sprite negativeSprite;

    public float speed = 10f;         // The fastest the player can travel in the x axis.
    public float jumpFactor = 1.5f;     // Amount of force added when the player jumps.

    public bool isGrounded = true;
    public bool isPositive = true; 


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        groundCollider = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movement using the move function
        if (Input.GetKey(KeyCode.A)) {
            Move(Vector2.left);
        } else if (Input.GetKey(KeyCode.D)) {
            Move(Vector2.right);
        } else {
            Move(Vector2.zero);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded) {
            Debug.Log("Shift read");
            // change the space
            GameObject.Find("LevelController").GetComponent<LevelController>().negateSpace();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            Jump();
        }

        // check if the player is touching the ground
        if (groundCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            isGrounded = true;
        } else {
            isGrounded = false;
        }

    }


    private void Move(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }

    private void Jump() 
    {
        Debug.Log("Attempting to jump");
        if (isPositive) {
            rb.velocity = new Vector2(rb.velocity.x, speed * jumpFactor);
        } else {
            rb.velocity = new Vector2(rb.velocity.x, -speed * jumpFactor);
        }
    }
}
