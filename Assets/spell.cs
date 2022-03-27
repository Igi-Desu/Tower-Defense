using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : BaseProjectile
{
    public mpspell mspell;
    public void Start()
    {
        Debug.Log("AAAAAAAAAAAAAAAAAAA");
        dmg = mspell.dmg;
        speed = mspell.speed;
       
    }
}
