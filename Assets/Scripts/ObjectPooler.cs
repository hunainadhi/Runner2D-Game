using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject poolObj;
    public int noOfObj;
    private List<GameObject> gameObjs;
    // Start is called before the first frame update
    void Start()
    {
        gameObjs = new List<GameObject>();
        for(int i=0; i<noOfObj; i++){
            GameObject gameObj = Instantiate(poolObj);
            gameObj.SetActive(false);
            gameObjs.Add(gameObj);
        }
    }
    public GameObject getPoolObj(){
            foreach(GameObject gameObjt in gameObjs){
                if(!gameObjt.activeInHierarchy)
                    return gameObjt;
            }
            GameObject gameObj = Instantiate(poolObj);
            gameObj.SetActive(false);
            gameObjs.Add(gameObj);
            return gameObj;
        }

}
