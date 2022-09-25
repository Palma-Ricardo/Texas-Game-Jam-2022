
using UnityEngine;

public class Goal : MonoBehaviour
{
    public int coinsCollected = 0;
    public int coinsNeeded = 0;

    public Collider2D goalCollider;
    public Collider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        goalCollider = GetComponent<Collider2D>();
        playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coinsCollected >= coinsNeeded && goalCollider.IsTouching(playerCollider)) {
            // load the next scene
            GameObject.Find("GameStateManager").GetComponent<GameStateManager>().enterNextScene();
        }
    }

    public void addCoin()
    {
        coinsCollected++;
    }
}
