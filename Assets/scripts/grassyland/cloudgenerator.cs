using UnityEngine;

public class cloudgenerator : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 0;
    [SerializeField]GameObject Cloud;
    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            Instantiate(Cloud);
            timer = Random.Range(2, 5);
        }
        timer -= Time.deltaTime;
    }
}
