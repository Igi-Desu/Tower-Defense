using UnityEngine;

public abstract class BaseProjectile : MonoBehaviour
{
    public float speed;
    public int dmg;
    abstract public void oncol();
}
