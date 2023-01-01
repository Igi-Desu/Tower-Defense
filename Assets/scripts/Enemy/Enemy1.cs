using UnityEngine;

public class Enemy1 : Base_Enemy
{
    // Start is called before the first frame update
    bool arrived = false;
    Vector2 destination = new Vector2(-3, -1);
    float speed = 3f;
    const float shottimerbase = 3;
    float shottimer = shottimerbase;
    [SerializeField]GameObject projectile;
    new void Start()
    {
        hp = 10;
        basehp = 10;
        base.Start();  
    }

    // Update is called once per frame
    void Update()
    {
        if (!arrived)
        {
            transform.position=Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            if ((Vector2)transform.position == destination)
            {
                arrived = true;
            }
        }
        else
        {
            shottimer -= Time.deltaTime;
            if (shottimer <= 0)
            {
                shot();
                shottimer = shottimerbase;
            }
        }
    }
    void shot()
    {
        Instantiate(projectile, transform.position,projectile.transform.rotation);
    }
}
