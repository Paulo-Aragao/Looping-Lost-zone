using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dive : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            Debug.Log("DiveNow");
        }
    }
    private void OnTriggerExit(Collider other) {
        
    }
}
