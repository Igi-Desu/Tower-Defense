using UnityEngine;

public class Arrow : BaseProjectile
{
    //how many targets we can hit before arrow disappears 
    int piercing = 2;

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
        if (piercing == 0)
        {
            Destroy(gameObject);
        }
    }

}
