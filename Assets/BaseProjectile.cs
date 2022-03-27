using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] [Range(0, 1000)] public float speed = 5f;
    public int dmg = 2;
    virtual public void oncol()
    {
        Debug.Log("hmmm");
    }
}
