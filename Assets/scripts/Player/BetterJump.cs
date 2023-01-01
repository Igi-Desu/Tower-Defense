using UnityEngine;

public class BetterJump : MonoBehaviour
{
    public float fallmultiplier = 2.5f;
    public float lowjumpmultiplier = 2f;
    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallmultiplier - 1) * Time.deltaTime;
        }else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowjumpmultiplier - 1) * Time.deltaTime;
        }
    }
}
