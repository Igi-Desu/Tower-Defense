using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Base_Enemy : MonoBehaviour
{
    protected int basehp;
    protected int hp;
    [SerializeField]GameObject Hp_Bar_Prefab;
    GameObject Hp_Bar;
    [SerializeField]GameObject deathAnimation;
    [SerializeField] GameManager gamemanagerr;
    public void Start()
    {
        gamemanagerr = GameObject.Find("GameManager").GetComponent<GameManager>();
        Hp_Bar = Instantiate(Hp_Bar_Prefab, new Vector3(transform.position.x-0.5f,transform.position.y+0.75f,transform.position.z),transform.rotation);
        //Hp_Bar.transform.position = new Vector3(-0.5f, 0.75f, 0);
        Hp_Bar.transform.parent = gameObject.transform;
    }
    protected void Take_Dmg(int dmg)
    {
        hp -= dmg;
        Update_Hp_Bar();
        if (hp <= 0)
        {
            Destroy(Hp_Bar);
            Destroy(gameObject);
        }
    }
    void Update_Hp_Bar()
    {

        Hp_Bar.transform.localScale = new Vector3((float)hp / basehp, Hp_Bar.transform.lossyScale.y, 1);
    }
    private void OnDestroy()
    {
        gamemanagerr.increasekillcount();
        Vector3 loc = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        Instantiate(deathAnimation,loc,deathAnimation.transform.rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Projectile")
        {
            Take_Dmg(collision.transform.GetComponent<BaseProjectile>().dmg);
            BaseProjectile b = collision.transform.GetComponent<BaseProjectile>();
            b.oncol();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Projectile")
        {
            Take_Dmg(collision.transform.GetComponent<BaseProjectile>().dmg);
            BaseProjectile b = collision.transform.GetComponent<BaseProjectile>();
            b.oncol();
        }
    }
}
