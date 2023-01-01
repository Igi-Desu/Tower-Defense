using UnityEngine;

public class magicprojectileice : spell
{
    [SerializeField] GameObject deathAnimation;
    [SerializeField]GameObject smoliceproj;
    float lifetime = 1f;

    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        if (transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            split();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player") 
        {
            split();
            Destroy(gameObject);
        }
    }
    void split()
    {
        //create 4 projectiles in 4 directions
        Instantiate(smoliceproj, gameObject.transform.position,Quaternion.Euler(new Vector3(0,0,45)));
        Instantiate(smoliceproj, gameObject.transform.position,Quaternion.Euler(new Vector3(0,0,135)));
        Instantiate(smoliceproj, gameObject.transform.position,Quaternion.Euler(new Vector3(0,0,-45)));
        Instantiate(smoliceproj, gameObject.transform.position,Quaternion.Euler(new Vector3(0,0,-135)));
    }
    private void OnDestroy()
    {
        Vector3 loc = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        Instantiate(deathAnimation, loc, new Quaternion());
    }
}
