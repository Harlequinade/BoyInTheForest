using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

    private float distance;
    private GameObject player;
    //private Light light;

    private void Start()
    {
        //light=GetComponent<Light>();
        //light.enabled = false;
        player = GameObject.Find("player");
    }

    
    public virtual void Interaction()
    {

    }

}
