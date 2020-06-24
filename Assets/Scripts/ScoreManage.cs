using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManage : MonoBehaviour
{

    public float ptsperSecond;
    public Text scoreText;
    public Text hiScoreText;

    public float Score;
    private float HiScore;

    public bool isScoreIncreasing;
    // Start is called before the first frame update
    void Start()
    {
        isScoreIncreasing=true;
        if(PlayerPrefs.HasKey("HiScore"))
            HiScore = PlayerPrefs.GetFloat("HiScore");
    }

    // Update is called once per frame
    void Update()
    {
        if(isScoreIncreasing)
            Score+= ptsperSecond * Time.deltaTime;
        if(Score>HiScore)
        {
            HiScore = Score;
            PlayerPrefs.SetFloat("HiScore",HiScore);
        }

        scoreText.text = Mathf.Round(Score).ToString();
        hiScoreText.text = Mathf.Round(HiScore).ToString();
    }
}
