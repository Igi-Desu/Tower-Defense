using UnityEngine;
public class Base_Enemy : MonoBehaviour
{
    protected int basehp;
    protected int hp;
    [SerializeField]GameObject hpBarPrefab;
    GameObject HpBar;
    [SerializeField]GameObject deathAnimation;
    [SerializeField] GameManager gameManager;
    public void Start()
    {
        //get components and create hp bar
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        HpBar = Instantiate(hpBarPrefab, new Vector3(transform.position.x-0.5f,transform.position.y+0.75f,transform.position.z),transform.rotation);
        HpBar.transform.parent = gameObject.transform;
    }

    protected void Take_Dmg(int dmg)
    {
        //update hp bar when enemy take dmg
        hp -= dmg;
        Update_Hp_Bar();
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Update_Hp_Bar()
    {
        HpBar.transform.localScale = new Vector3((float)hp / basehp, HpBar.transform.lossyScale.y, 1);
    }
    private void OnDestroy()
    {
        gameManager.increasekillcount();
        Vector3 loc = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10);
        Instantiate(deathAnimation,loc,deathAnimation.transform.rotation);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Projectile")
        {
            //get dmg of the projectile and lower hp by it's amount
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
