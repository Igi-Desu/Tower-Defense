using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firespell : spell
{
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        if (transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
    }
}
