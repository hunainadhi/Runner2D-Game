using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COinPicker : MonoBehaviour
{
    private AudioSource coinpicksound;

    private float Coinpts = 15f;
    private ScoreManage scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        coinpicksound = GameObject.Find("CoinPickSound").GetComponent<AudioSource>();
        scoreManager = FindObjectOfType<ScoreManage>();
    }

   void OnTriggerEnter2D(Collider2D other){
       if(other.gameObject.name == "Player"){
           gameObject.SetActive(false);
           if(coinpicksound.isPlaying){
               coinpicksound.Stop();
           }
           coinpicksound.Play();
            scoreManager.Score += Coinpts;
       }
   }
}
