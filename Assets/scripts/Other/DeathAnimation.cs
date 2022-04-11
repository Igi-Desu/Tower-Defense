using System.Collections;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(Death());
    }

   IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
