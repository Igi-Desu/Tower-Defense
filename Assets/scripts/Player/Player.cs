using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
public class Player : MonoBehaviour
{
    public enum PlayerState { Idle = 0, Jumping = 1, Falling = 2 };
    public static PlayerState playerState;
    [SerializeField] GameObject Arrow;
    [SerializeField] GameObject magicProjectile;
    Rigidbody2D rb;
    public const int maxmp = 100;
    public int mp;
    bool jump;
    float bowload;
    float bowspeed=3;
    [SerializeField] [Range(0, 550)] float jumpforce;
    float magiccd;
    const float mptimerbase = 0.2f;
    float mptimer;
    //jaki guzik ma spacja?
    const float magiccdbase = 0.5f;
    public int arrowamount = 5;
    const int maxbowload = 5;
    [SerializeField] UiText arrowamounttext;
    SpriteRenderer bowBarSprite;
    [SerializeField] GameObject bowLoadBar;
    [SerializeField] ManaBar MpBar;
    [SerializeField] Image currentSpellSpriteUi;
    //gameobject must be a derived of spell class
    public GameObject[] spells = new GameObject[2];
    int currentspell = 0;
    public bool cutscene = false;
    PlayableDirector cutscenedirector;
    private void Start()
    {
        cutscenedirector = GameObject.Find("timeline").GetComponent<PlayableDirector>();
        currentSpellSpriteUi.sprite = spells[currentspell].GetComponent<SpriteRenderer>().sprite;
        MpBar.SetMax(maxmp);
        MpBar.ResizeBar(maxmp);
        mp = maxmp;
        magiccd = magiccdbase;
        playerState = PlayerState.Idle;
        bowBarSprite = bowLoadBar.GetComponent<SpriteRenderer>();
        bowload = 0;
        bowLoadBar.transform.localScale = new Vector2(0,bowLoadBar.transform.lossyScale.y);
        rb = GetComponent<Rigidbody2D>();
        arrowamounttext.text = arrowamount.ToString();
    }
    void Update()
    {
        if (cutscene)
        {
            if (cutscenedirector.state != PlayState.Playing)
            {
                cutscene = false;
            }
            return;
        }
        //check for inputs
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentspell++;
            if (currentspell == spells.Length)
            {
                currentspell = 0;
            }
            currentSpellSpriteUi.sprite = spells[currentspell].GetComponent<SpriteRenderer>().sprite;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        else
        {
            jump = false;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            //load bow and change bar color depending on load level
            bowload += Time.deltaTime*bowspeed;
            bowload = (bowload > maxbowload) ? maxbowload : bowload;
            bowLoadBar.transform.localScale = new Vector2(bowload / maxbowload, bowLoadBar.transform.lossyScale.y);
            if (bowLoadBar.transform.localScale.x < 0.333) { bowBarSprite.color = Color.green; }
            else if (bowLoadBar.transform.localScale.x < 0.666) { bowBarSprite.color = Color.yellow; }
            else { bowBarSprite.color = Color.red; }
        }
        else if (Input.GetKeyUp(KeyCode.Q) && bowload > 0.5f && arrowamount != 0)
        {
            bowLoadBar.transform.localScale = new Vector2(0, bowLoadBar.transform.lossyScale.y);
            shot();
            bowload = 0;
            arrowamount--;
            arrowamounttext.text = arrowamount.ToString();
        }
        else if (Input.GetKey(KeyCode.E) && magiccd < 0&&mp>= spells[currentspell].GetComponent<spell>().mspell.manacost)
        {
            shotmagic();
        }
        else
        {
            bowload = 0;
            bowLoadBar.transform.localScale = new Vector2(bowload / maxbowload, bowLoadBar.transform.localScale.y);
        }
        movement(jump, Vector2.zero);
        if (rb.velocity.y > 0.1)
        {
            playerState = PlayerState.Jumping;
        }
        else if (rb.velocity.y < 0.1)
        {
            playerState = PlayerState.Falling;
        }
        else
        {
            playerState = PlayerState.Idle;
        }
        magiccd -= Time.deltaTime;
        mptimer -= Time.deltaTime;
        if (mptimer < 0 && mp <= maxmp)
        {
            mp++;
            mptimer = mptimerbase;
            MpBar.ResizeBar(mp);
        }
    }
    void movement(bool jump, Vector2 movement)
    {
        if (jump && rb.velocity.y == 0)
        {
            rb.velocity = Vector2.up * jumpforce;
        }
    }
    float get_closest_pixel(float value)
    {
        value *= 16;
        value = Mathf.Round(value);
        return value / 16;
    }
    public void givearrows(int number)
    {
        arrowamount += number;
        arrowamounttext.text = arrowamount.ToString();
    }
    void shot()
    {
        GameObject arrow;
        arrow = Instantiate(Arrow, new Vector3(get_closest_pixel(transform.position.x), get_closest_pixel(transform.position.y)), transform.rotation);
        arrow.GetComponent<Arrow>().dmg = Mathf.RoundToInt(bowload * 1.25f);
        arrow.GetComponent<Arrow>().speed = arrow.GetComponent<Arrow>().dmg * 2.5f;
    }
    void shotmagic()
    {
        magiccd = magiccdbase;
        mp -= spells[currentspell].GetComponent<spell>().mspell.manacost;
        MpBar.ResizeBar(mp);
        Instantiate(spells[currentspell], new Vector3(get_closest_pixel(transform.position.x), get_closest_pixel(transform.position.y)), transform.rotation);
    }
}
