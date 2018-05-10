using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerMaster : MonoBehaviour, IInputClickHandler {//, IInputHandler {
    private SpatialMappingManager mappingManager;
    private SurfaceMeshesToPlanes planesMaker;

    public virtual void OnInputClicked(InputClickedEventData eventData)
    {
        Debug.Log("CLICKED INPUT");
        mappingManager.StopObserver();
        planesMaker.MakePlanes();
    }

   /* public void OnInputDown(InputEventData eventData)
    {
        Debug.Log("CLICKED DOWN INPUT");
        return;
    }

    public void OnInputUp(InputEventData eventData)
    {
        Debug.Log("CLICKED UP INPUT");
        mappingManager.StopObserver();
        planesMaker.MakePlanes();
    }*/

    // Use this for initialization
    void Awake ()
    {
        Debug.Log("LAUNCHED");
        mappingManager = GetComponentInChildren<SpatialMappingManager>();
        planesMaker = GetComponentInChildren<SurfaceMeshesToPlanes>();
        //InputManager.Instance.AddGlobalListener(gameObject);
    }

    void Start()
    {
        Debug.Log("START");
        InputManager.Instance.PushFallbackInputHandler(gameObject);
        mappingManager.StartObserver();
    }

        // Update is called once per frame
    void Update ()
    {
        return;
	}
}
