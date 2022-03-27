using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magicprojectileice : spell
{
    // Start is called before the first frame update
    [SerializeField] GameObject deathAnimation;
    [SerializeField]GameObject smoliceproj;
    float lifetime = 1f;

    // Update is called once per frame
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
