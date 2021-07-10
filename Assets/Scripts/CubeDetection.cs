using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDetection : MonoBehaviour
{
    [Tooltip("这是一个接口，判断是否过关")]
    public bool isWinning;
    
    // Start is called before the first frame update
    public void Start()
    {
        isWinning = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("White") || collision.gameObject.CompareTag("Black"))
        {  //成功，接过关UI
            //Debug.Log("iswinning:"+isWinning);
            isWinning = true;
            //Debug.Log("iswinning:"+isWinning);
            
        }
        
    }
}