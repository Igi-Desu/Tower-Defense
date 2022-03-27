using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowgiver : MonoBehaviour
{
    float timer;
    const float timerbase=5;
    Player p;

    void Start()
    {
        timer = timerbase;
        p = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = timerbase;
            p.givearrows(1);
        }
    }
}
