using UnityEngine;

public class Token : MonoBehaviour
{
    public Collider2D coll;
    public Collider2D playerCollider;

    public Grid blocks;
    public bool defaultState = true;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();

        if (blocks != null) {
            blocks.gameObject.SetActive(defaultState);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == playerCollider) {
            // add a coin to the player's coin count
            GameObject.Find("Goal").GetComponent<Goal>().addCoin();
            if (blocks != null) {
                blocks.gameObject.SetActive(!defaultState);
            }
            // destroy the token
            Destroy(this.gameObject);
        }
    }
}
