using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    [SerializeField] TextMeshProUGUI score, worldDmg;
    [SerializeField] GameObject scoreBg, character, groupEnemies;
    GameObject[] enemies;
    
    int intScore;

    private void Awake()
    {
        Instance = this; 
    }
    void Start()
    {
        
    }


    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length <= 0 )
        {
            Instantiate(groupEnemies, new Vector3(24.9454727f, 1.18700004f, 15.3873024f), transform.rotation) ;
        }
        if (intScore < 10)
        {
            score.text = "000" + intScore;
        }
        else if (intScore >= 10 && intScore < 100) 
        {
            score.text = "00" + intScore;
        }
        else if (intScore >= 100 && intScore < 1000)
        {
            score.text = "0" + intScore;
        }
        else if (intScore >= 1000 )
        {
            score.text = "" + intScore;
        }


    }

    public void IncreaseScore(int damage, int life)
    {
        if (life > 0)
        {
            SoundEffects.instance.PlaySFX(SoundEffects.SoundFX.score);
            score.GetComponent<Animator>().SetTrigger("Scoring");
            scoreBg.GetComponent<Animator>().SetTrigger("Scoring");
            worldDmg.color = new Color(255, 0, 0, 255);
        }
        else
        {
            SoundEffects.instance.PlaySFX(SoundEffects.SoundFX.bigScore);
            worldDmg.color =  Color.yellow;
        }
        
        intScore += damage;
        worldDmg.fontSize = 6 * damage / 35;
        worldDmg.text = ""+damage;
        Invoke("UnshowDamage", 0.7f);
    }

    public void Killing()
    {
        intScore += 150;
        
        score.GetComponent<Animator>().SetTrigger("BigScore");
        scoreBg.GetComponent<Animator>().SetTrigger("BigScore");
        character.GetComponent<Animator>().SetTrigger("Killing");
    }
    void UnshowDamage()
    {
        worldDmg.text = string.Empty;
    }
}
