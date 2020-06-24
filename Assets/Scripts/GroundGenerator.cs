using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public Transform groundpt;
    public Transform minHieghtpt;
    public Transform maxHieghtpt;

    private float MinY;
    private float MaxY;

    public float minGap;
    public float maxGap;


    public ObjectPooler[] grndpooler;
    private float[] groundWidths;

    private CoinGenerator coingenerator;
    // Start is called before the first frame update
    void Start()
    {
        MinY=minHieghtpt.position.y;
        MaxY=maxHieghtpt.position.y;
        groundWidths = new float[grndpooler.Length];
        for(int i=0; i<grndpooler.Length; i++){
            groundWidths[i] = grndpooler[i].poolObj.GetComponent<BoxCollider2D>().size.x;
        }
        coingenerator = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < groundpt.position.x){
            int rand = Random.Range(0, grndpooler.Length);
            float dist = groundWidths[rand]/2;

            float gap=Random.Range(minGap,maxGap);

            float ht = Random.Range(MinY,MaxY);
            transform.position = new Vector3(transform.position.x +dist+gap, ht,-transform.position.z);

            GameObject ground = grndpooler[rand].getPoolObj();
            ground.SetActive(true);
            ground.transform.position =transform.position;

            coingenerator.spawnCoins(transform.position,groundWidths[rand]); 

            transform.position = new Vector3(transform.position.x +dist, transform.position.y,-transform.position.z);
        }
    }
}
