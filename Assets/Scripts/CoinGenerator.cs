using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public ObjectPooler coinPooler;

    public void spawnCoins(Vector3 position, float groundWidth){
        int random = Random.Range(1,100);
        if(random<65)return;
        float y = Random.Range(0,4);
        int numOfCoins = (int)Random.Range(3f,groundWidth);
        int ry = Random.Range(0,4);
      
        for(int i=0; i<numOfCoins; i++){

            GameObject coin = coinPooler.getPoolObj();
            
            coin.transform.position = new Vector3(position.x - (groundWidth/2 - 2) +i,position.y+2+ry,0);
            coin.SetActive(true);
          
        }
           
    }
}
