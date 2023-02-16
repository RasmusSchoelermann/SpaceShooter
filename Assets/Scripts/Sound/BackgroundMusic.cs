using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] backgrounMusic = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        if(backgrounMusic.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
