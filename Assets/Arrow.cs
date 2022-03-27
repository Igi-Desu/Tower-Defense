using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : BaseProjectile
{
    // Start is called before the first frame update
    int piercing = 2;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0,0) * Time.deltaTime;
        if (transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
    }
    override public void oncol()
    {
        piercing--;
        Debug.Log("piercing ; " + piercing);
        if (piercing == 0)
        {
            Destroy(gameObject);
        }
    }
    //not piercing
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.transform.tag != "Player")
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
