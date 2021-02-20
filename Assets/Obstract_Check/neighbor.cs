using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neighbor : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other);
        if(other.CompareTag("Building")){
            other.GetComponent<change>().enabled = true;
        }
    }

    void OnTrrigerExit(Collider other)
    {
        if(other.CompareTag("Building")){
            other.GetComponent<change>().enabled = false;
        }
    }
}
