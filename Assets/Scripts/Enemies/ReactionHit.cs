using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReactionHit : MonoBehaviour
{
    public GameObject player;

    // TO KEEP THINGS CLEANER, NOT NECESSARILY EASIER
    // TODO:
    /** ideas:
     * spawn reaction img over head (width: 150     height: 50)
     * if within range of player, then you have 3 seconds to hit
     * hits are either perfect or miss
     * FOR KEYBOARD -- tags are the shoulder and trigger buttons (space)
    **/

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Start()
    {

    }

    void Update()
    {
        CheckIfInRange();
    }

    private void CheckIfInRange()
    {
        if (transform.position.x > player.transform.position.x + 15)
        {
            gameObject.GetComponent<Image>().enabled = true;
        }
    }
}
