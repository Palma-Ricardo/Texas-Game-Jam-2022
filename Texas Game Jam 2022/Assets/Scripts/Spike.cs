using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Collider2D coll;
    public bool alwaysActive = false;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponentInChildren<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("LevelController").GetComponent<LevelController>().isNegated && !alwaysActive) {
            coll.enabled = false;
        } else {
            coll.enabled = true;
        }

        if (coll.enabled && coll.IsTouching(GameObject.Find("Player").GetComponent<BoxCollider2D>())) {
            GameObject.Find("GameStateManager").GetComponent<GameStateManager>().reloadCurrentScene();
        }
    }
}
