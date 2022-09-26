using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Goal goal;
    public PlayerController player;

    public bool isNegated = false;
    public float playerOffset = 1.5f;

    public Grid positiveGrid;
    public Grid negativeGrid;
    

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("Goal").GetComponent<Goal>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();  
        isNegated = false;

        positiveGrid = GameObject.Find("Positive").GetComponent<Grid>();
        negativeGrid = GameObject.Find("Negative").GetComponent<Grid>();

        negativeGrid.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void negateSpace()
    {
        Grid activeGrid;
        Grid inactiveGrid;

        if (isNegated) {
            activeGrid = negativeGrid;
            inactiveGrid = positiveGrid;
            
        } else {
            activeGrid = positiveGrid;
            inactiveGrid = negativeGrid;
        }

        activeGrid.gameObject.SetActive(false);
        inactiveGrid.gameObject.SetActive(true);
        player.rb.gravityScale = -player.rb.gravityScale;

        if (isNegated) {
            player.spriteRenderer.sprite = player.positiveSprite;
            player.spriteRenderer.flipY = false;
            player.isPositive = true;

            player.rb.MovePosition(new Vector2(player.rb.position.x, player.rb.position.y + playerOffset));
            Debug.Log("entering positive space");
        } else {
            player.spriteRenderer.sprite = player.negativeSprite;
            player.spriteRenderer.flipY = true;
            player.isPositive = false;

            player.rb.MovePosition(new Vector2(player.rb.position.x, player.rb.position.y - playerOffset));
            Debug.Log("entering negative space");
        }

        isNegated = !isNegated;
    }

}
