using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player player;
    public ScoreManage scoreManager;
    public AudioSource BackgroundSound;
    public AudioSource DeathSound;

    private Vector3 playerStartingPoint;
    private Vector3 groundGenerationStartPoint;

    public GroundGenerator groundGenerator;

    public GameObject LargeGround;
    public GameObject MediumGround;

    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        playerStartingPoint = player.transform.position;
        groundGenerationStartPoint = groundGenerator.transform.position;
        gameOverScreen.SetActive(false);

    }
    public void Restart(){
        GroundDestroyer[] destroyer = FindObjectsOfType<GroundDestroyer>();
        for(int i=0; i< destroyer.Length; i++){
            destroyer[i].gameObject.SetActive(false);
        }
        LargeGround.SetActive(true);
        MediumGround.SetActive(true);
        player.transform.position = playerStartingPoint;    
        groundGenerator.transform.position = groundGenerationStartPoint;    
        gameOverScreen.SetActive(false);
        player.gameObject.SetActive(true);
        scoreManager.isScoreIncreasing=true;
        BackgroundSound.Play();
        scoreManager.Score= 0;
    }
    public void GameOver(){
        player.gameObject.SetActive(false);
        gameOverScreen.SetActive(true);
        scoreManager.isScoreIncreasing=false;
        BackgroundSound.Stop();
        DeathSound.Play();
    }
    public void Quit(){
        Application.Quit();
    }
    
}
