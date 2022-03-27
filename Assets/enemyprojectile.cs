using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyprojectile : BaseProjectile
{
    [SerializeField]GameObject deathanim;
    private void Start()
    {
        speed = 2;
        dmg = 30;
    }
    void Update()
    {
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
     //   Debug.Log(-1.0f / 28 * Mathf.Pow((-3 + 8), 2) + 3);
     Vector3 v= new Vector3(transform.position.x, -4.0f / 25 * Mathf.Pow((transform.position.x + 8), 2) + 3, transform.position.z);
        transform.position = v;
        //policz pochodna i styczn¹ XD
        //derivative -8/25(x+8)^2
        //
        float a = Vector2.Angle(new Vector2(0, 1), new Vector2(1, -8.0f / 25 * Mathf.Pow(transform.position.x + 8, 2)));
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -a+90));
      //  Debug.Log(a);
    }
    private void OnDestroy()
    {
        Instantiate(deathanim, transform.position, deathanim.transform.rotation);
    }
}
