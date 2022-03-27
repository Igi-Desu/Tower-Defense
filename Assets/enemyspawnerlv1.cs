using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawnerlv1 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] enemies;
    public int enemiesspawned=0;
    public int[] maxenemies;
    public int maxlevel = 3;
    public int level;
    float timer = 1f;
    const float timerbase = 2f;
    [SerializeField]GameManager manager;
    // Update is called once per frame
    private void Start()
    {
        level = 0;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = timerbase;
            if (level == maxlevel)
            {
                int a = Random.Range(0, enemies.Length);
                Instantiate(enemies[a]);
                return;
            }
            if (enemiesspawned != maxenemies[level])
            {
                enemiesspawned++;
                int a = Random.Range(0, enemies.Length);
                Instantiate(enemies[a]);
            }
        }
    }
}
