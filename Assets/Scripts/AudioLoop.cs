using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoop : MonoBehaviour
{
    [SerializeField] private bool _main_loop = false;
    public void SetMaindLoop(bool is_main_loop){
        _main_loop = is_main_loop;
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Delete",300f);
        if(!_main_loop){
            gameObject.GetComponent<AudioSource>().volume += 0.001f;
        }
    }
    void Update()
    {
        if(!_main_loop && gameObject.GetComponent<AudioSource>().volume <0.5f){
            gameObject.GetComponent<AudioSource>().volume += 0.001f;
        }
        
    }
    private void Delete(){
        if(!_main_loop){
            Destroy(gameObject,0.1f);
        }
    }
}
