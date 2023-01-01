using UnityEngine;

public class FlyingSkullAI : SuicideEnemy
{
    float speed;
    float waittime;
    bool waiting,rage;
    float x, y, offset;
    new void Start()
    {
        hp = 10;
        basehp = 10;
        x = transform.position.x;
        offset = Random.Range(-10f, 10f);
        y = transform.position.y;
        speed = 2;
        dmg = 100;
        waittime = 2;
        waiting = false;
        rage = false;
        base.Start();
    }
    void Update()
    {
        //move in parabolic motion
        x -= speed * Time.deltaTime;
        if (!rage)
        {
            transform.position = new Vector3(x, y + 0.5f*Mathf.Sin(offset+x / 4));
        }
        else
        {
            transform.position = new Vector3(x,transform.position.y);
        }
        //if we reach certain position start waiting
        if (transform.position.x <= -3)
        {
            waiting = true;
            speed = 0;
        }
        if (waiting)
        {
            waittime -= Time.deltaTime;
            //after waiting go into rage state and fly directly at castle
            if (waittime < 0)
            {
                waiting = false;
                rage = true;
                speed = 4;
                GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
}
