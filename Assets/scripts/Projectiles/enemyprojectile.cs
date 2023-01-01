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
        //make parabolic motion
        transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
        Vector3 v= new Vector3(transform.position.x, -4.0f / 25 * Mathf.Pow((transform.position.x + 8), 2) + 3, transform.position.z);
        transform.position = v;
        float a = Vector2.Angle(new Vector2(0, 1), new Vector2(1, -8.0f / 25 * Mathf.Pow(transform.position.x + 8, 2)));
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -a+90));
    }
    private void OnDestroy()
    {
        Instantiate(deathanim, transform.position, deathanim.transform.rotation);
    }
    public override void oncol(){}
}
