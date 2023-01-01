using UnityEngine;
using UnityEngine.UI;
public class CastleHP : MonoBehaviour
{
    [SerializeField] Slider bar;
    [SerializeField] GameManager gm;
    const int maxhp = 500;
    int hp = maxhp;
    void Start()
    {

        bar.maxValue = maxhp;
        bar.value = hp;
    }

    void take_dmg(int dmg)
    {
        hp -= dmg;
        bar.value = hp;
        if (hp <= 0)
        {
            gm.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "EnemyProjectile")
        {
            enemyprojectile e = collision.GetComponent<enemyprojectile>();
            take_dmg(e.dmg);
            Destroy(collision.gameObject);
        }
        if (collision.transform.tag == "SuicideEnemy")
        {
            int dmg = collision.GetComponent<SuicideEnemy>().dmg;
            take_dmg(dmg);
            Destroy(collision.gameObject);
        }
    }

}
