using UnityEngine;

public class smolice : spell
{
    [SerializeField] GameObject deathAnimation;
    float lifetime = 0.5f;
    void Update()
    {
        // Move the object upward in world space 1 unit/second.
        transform.Translate(Vector3.right *speed* Time.deltaTime);
        if (transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        Vector3 loc = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        Instantiate(deathAnimation, loc, new Quaternion());
    }
}
