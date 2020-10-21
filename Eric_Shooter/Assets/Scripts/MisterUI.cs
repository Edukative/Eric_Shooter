using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MisterUI : MonoBehaviour
{
    public Text textScore;

    public Text textRestartGallery;

    [HideInInspector]
    public int score;

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
}
