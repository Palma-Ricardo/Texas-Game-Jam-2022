using UnityEngine;

public class Token : MonoBehaviour
{
    public Collider2D coll;
    public Collider2D playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coll.IsTouching(playerCollider)) {
            // add a coin to the player's coin count
            GameObject.Find("Goal").GetComponent<Goal>().addCoin();
            // destroy the coin
            Destroy(this.gameObject);
        }
    }
}
