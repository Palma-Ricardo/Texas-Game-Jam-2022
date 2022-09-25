using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Collider2D coll;
    public SpriteRenderer spriteRenderer;

    public Sprite positiveSprite;
    public Sprite negativeSprite;

    private bool facingRight = true;  // For determining which way the player is currently facing.
    public float speed = 10f;         // The fastest the player can travel in the x axis. 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movement using the move function
        if (Input.GetKey(KeyCode.A)) {
            Move(Vector2.left);
            facingRight = false;
        } else if (Input.GetKey(KeyCode.D)) {
            Move(Vector2.right);
            facingRight = true;
        } else {
            Move(Vector2.zero);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            // change the space
            GameObject.Find("LevelController").GetComponent<LevelController>().negateSpace();
        }
    }

    private void Move(Vector2 direction)
    {
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }
}
