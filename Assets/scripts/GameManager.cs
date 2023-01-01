using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]PlayableDirector director;
    [SerializeField]PlayableAsset[] cutscenes;
    [SerializeField]enemyspawnerlv1 enemyspawner;
    [SerializeField]UiText level;
    [SerializeField]UiText killamount;
    [SerializeField]Color[] colors;
    [SerializeField]UnityEngine.Rendering.Universal.Light2D globalLight;
    [SerializeField] Player player;
    [SerializeField] Canvas GameOverCanvas;
    bool endlessmode;
    int killcount;
    int totalkillcount;
    void Start()
    {
        GameOverCanvas.enabled = false;
        endlessmode = false;
        level.text = (enemyspawner.level+1).ToString();
        killcount = 0;
        totalkillcount = 0;
        killamount.text = totalkillcount.ToString();
    }
    public void increasekillcount()
    {
        killcount++;
        totalkillcount++;
        killamount.text = totalkillcount.ToString();
        if (endlessmode)
        {
            return;
        }
        if (killcount == enemyspawner.maxenemies[enemyspawner.level])
        {
            killcount = 0;
            PlayCutscene(0);
        }
    }
    // Update is called once per frame
    public void PlayCutscene(int number)
    {
        player.cutscene = true;
        director.playableAsset = cutscenes[number];
        director.Play();
        if (number == 0)
        {
            StartCoroutine(waitforx(5));
            //here 
            //=============================================================================================
            //
            StartCoroutine(smoothcolor(colors[enemyspawner.level]));
       //     globalLight.color = colors[enemyspawner.level];
        }
        else if (number == 1)
        {

            StartCoroutine(GiveArrowsafterx(3));
        }
    }
    Color VectToColor(Vector3 v)
    {
        return new Color(v.x, v.y, v.z);
    }
    Vector3 ColorToVect(Color c)
    {
        return new Vector3(c.r, c.g, c.b);
    }
    IEnumerator smoothcolor(Color c)
    {
        yield return new WaitForSeconds(0.3f);
        Vector3 dest = ColorToVect(c);
        Vector3 from = ColorToVect(globalLight.color);
        from = Vector3.MoveTowards(from, dest, 0.05f);
        globalLight.color = VectToColor(from);
        if (from != dest)
        {
            StartCoroutine(smoothcolor(c));
        }
    }
    public void cutscene0()
    {

    }
    public void cutscene1()
    {
        
    } 
    public void cutscene2()
    {

    }
    IEnumerator waitforx(float x)
    {
        yield return new WaitForSeconds(x);
        PlayCutscene(1);
        enemyspawner.level++;
        if (enemyspawner.level == enemyspawner.maxlevel)
        {
            level.text = "Endless Mode";
            endlessmode = true;
            Instantiate(Resources.Load<GameObject>("arrowgiver"));
            StartCoroutine(darkenscreen());
        }
        else
        {
            level.text = (enemyspawner.level + 1).ToString();
        }
      
        enemyspawner.enemiesspawned = 0;
    }
    IEnumerator darkenscreen()
    {
        yield return new WaitForSeconds(0.2f);
        globalLight.intensity -= 0.005f;
        if (globalLight.intensity > 0.4)
        {
            StartCoroutine(darkenscreen());
        }
    }
    IEnumerator GiveArrowsafterx(float x)
    {
        yield return new WaitForSeconds(x);
        player.givearrows(10);
    }
    public void GameOver()
    {
        GameOverCanvas.enabled = true;
        Time.timeScale = 0;
        
    }
}
