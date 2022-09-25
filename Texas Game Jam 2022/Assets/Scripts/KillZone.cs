using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Collider2D coll;
    private GameStateManager gameStateManager;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponentInChildren<Collider2D>();
        gameStateManager = GameObject.Find("GameStateManager").GetComponent<GameStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // if the player is touching the kill zone, reload the current scene
        if (coll.IsTouching(GameObject.Find("Player").GetComponent<Collider2D>())) {
            gameStateManager.reloadCurrentScene();
        }
    }
}
