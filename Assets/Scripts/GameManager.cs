using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance;

    [SerializeField] TextMeshProUGUI score, worldDmg;
    [SerializeField] GameObject scoreBg, character;
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
        else if (intScore >= 1000 && intScore < 10000)
        {
            score.text = "" + intScore;
        }

    }

    public void IncreaseScore(int damage, int life)
    {
        if (life > 0)
        {
            score.GetComponent<Animator>().SetTrigger("Scoring");
            scoreBg.GetComponent<Animator>().SetTrigger("Scoring");
            worldDmg.color = new Color(255, 0, 0, 255);
        }
        else
        {
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
