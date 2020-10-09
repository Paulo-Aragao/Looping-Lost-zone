using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMain : MonoBehaviour
{   
    private static AudioMain _instance;
    public static AudioMain Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioMain>();
            }
            return _instance;
            
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
