using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    private GameObject pt;
    // Start is called before the first frame update
    void Start()
    {
        pt = GameObject.Find("DestroyPoint");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < pt.transform.position.x){
            gameObject.SetActive(false);
        }
    }
}
