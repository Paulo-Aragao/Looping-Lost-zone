using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyButton : MonoBehaviour
{
    void Update()
    {
        if(Input.anyKeyDown){
            UIController.Instance.Restart();
        }   
    }
}
