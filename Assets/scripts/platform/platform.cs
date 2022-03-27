using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    private PlatformEffector2D effector;
    // Start is called before the first frame update
    void Start()
    {
        effector = gameObject.GetComponent<PlatformEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.playerState==Player.PlayerState.Jumping)
        {
            effector.rotationalOffset = 0;
        }
        else if (Input.GetKey(KeyCode.S)&&Player.playerState!=Player.PlayerState.Jumping)
        {
            effector.rotationalOffset = 180;
        }
    }
}
