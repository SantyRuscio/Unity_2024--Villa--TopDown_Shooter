using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    GameObject Player;
    bool followPlayer = true;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (followPlayer == true)
        {
            camFollowPlayer();
        }
    }

    public void setFollowPlayer(bool val)
    {
        followPlayer = val;
    }

    void camFollowPlayer()
    {
        Vector3 newPos = new Vector3(Player.transform.position.x, Player.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }
}

