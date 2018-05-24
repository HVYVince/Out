using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTracks : MonoBehaviour, IInputClickHandler
{


    public virtual void OnInputClicked(InputClickedEventData eventData)
    {
        GetComponentInChildren<AudioSource>().Stop();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
