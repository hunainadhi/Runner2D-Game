using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroungGenerator : MonoBehaviour
{
    public Transform groundpt;
    public Transform minHieghtpt;
    public Transform maxHieghtpt;

    private float MinY;
    private float MaxY;
    public ObjectPooler[] grndpooler;
    private float[] groundWidths;
    // Start is called before the first frame update
    void Start()
    {
        groundWidths = new float[grndpooler.Length];
        for(int i=0; i<grndpooler.Length; i++){
            groundWidths[i] = grndpooler[i].poolObj.GetComponent<BoxCollider2D>().size.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < groundpt.position.x){
            int rand = Random.Range(0, grndpooler.Length);
            float dist = groundWidths[rand]/2;

            transform.position = new Vector3(transform.position.x +dist, transform.position.y,-transform.position.z);

            GameObject ground = grndpooler[rand].getPoolObj();
            ground.SetActive(true);
            ground.transform.position =transform.position;

             transform.position = new Vector3(transform.position.x +dist, transform.position.y,-transform.position.z);
        }
    }
}
