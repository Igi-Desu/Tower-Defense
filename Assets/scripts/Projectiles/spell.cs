public class spell : BaseProjectile
{
    public mpspell mspell;
    public void Start()
    {
        dmg = mspell.dmg;
        speed = mspell.speed;
    }
    public override void oncol(){}
}
