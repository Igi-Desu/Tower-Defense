using UnityEngine;

public class cloud : MonoBehaviour
{
    // Start is called before the first frame update
    float speed = 3f;
    [SerializeField]const int baseheight=3;
    // Update is called once per frame
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, baseheight+Random.Range(0,3)*0.5f,transform.position.z);
    }
    void Update()
    {
        transform.position += new Vector3( speed * Time.deltaTime, 0, 0);
        if (transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
    }
}
