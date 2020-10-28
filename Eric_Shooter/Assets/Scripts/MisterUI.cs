using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MisterUI : MonoBehaviour
{
    //STATS TEXT
    public Text textScore;
    public Text textHealth;
    public Text textArmor;
    public Text textAmmo;

    public Text textRestartGallery;

    //STATS NUMBERS
    [HideInInspector]
    public int score;
    [HideInInspector]
    public int health;
    [HideInInspector]
    public int armor;
    [HideInInspector]
    public int ammo;


    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        textScore.enabled = false;
        textRestartGallery.enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (textScore.enabled)
        {
            textScore.text = "Score: " + score.ToString();
        }
    }

    public void SumScore (int sum)
    {
        score = score + sum;
    }

    public void UIStatsChange ()
    {
        textAmmo.text = ammo.ToString();
        textHealth.text = health.ToString();
        textArmor.text = armor.ToString();
    }
}
