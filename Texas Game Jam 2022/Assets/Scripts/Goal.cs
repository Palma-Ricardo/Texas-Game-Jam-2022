
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int tokensCollected = 0;
    public int tokensNeeded = 0;

    public Collider2D goalCollider;
    public Collider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        goalCollider = GetComponent<Collider2D>();
        playerCollider = GameObject.Find("Player").GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other == playerCollider && tokensCollected >= tokensNeeded && playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
            // load the next scene
            GameObject.Find("GameStateManager").GetComponent<GameStateManager>().enterNextScene();
        }
    }

    public void addCoin()
    {
        tokensCollected++;
    }
}
