using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    GameObject player;
    bool followPlayer = true;
    public Vector3 offset = new Vector3 (0, 0, -20);
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
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
        Vector3 newPos = player.transform.position + offset;
        this.transform.position = newPos;
    }
    //test
}

