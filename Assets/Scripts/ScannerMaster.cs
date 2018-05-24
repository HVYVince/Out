using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerMaster : MonoBehaviour, IInputClickHandler {
    public Material horizontalMaterial;
    public Material verticalMaterial;
    public Material otherMaterial;

    private SpatialMappingManager mappingManager;
    private SurfaceMeshesToPlanes planesMaker;
    private RemoveSurfaceVertices verticesRemover;
    private List<GameObject> horizontalObjects;
    private List<GameObject> verticalObjects;
    private List<GameObject> otherObjects;

    public virtual void OnInputClicked(InputClickedEventData eventData)
    {
        mappingManager.StopObserver();
        planesMaker.MakePlanes();
    }

    public void removeVertices(object source, System.EventArgs args)
    {
        horizontalObjects = SurfaceMeshesToPlanes.Instance.GetActivePlanes(PlaneTypes.Table | PlaneTypes.Floor | PlaneTypes.Ceiling);
        verticalObjects = SurfaceMeshesToPlanes.Instance.GetActivePlanes(PlaneTypes.Wall);
        otherObjects = SurfaceMeshesToPlanes.Instance.GetActivePlanes(PlaneTypes.Unknown);
        if (RemoveSurfaceVertices.Instance.enabled)
            RemoveSurfaceVertices.Instance.RemoveSurfaceVerticesWithinBounds(SurfaceMeshesToPlanes.Instance.ActivePlanes);
    }


    public void planesReady(object source, System.EventArgs args)
    {
        foreach (GameObject obj in horizontalObjects)
            obj.GetComponent<Renderer>().material = horizontalMaterial;
        foreach (GameObject obj in verticalObjects)
            obj.GetComponent<Renderer>().material = verticalMaterial;
        foreach (GameObject obj in otherObjects)
            obj.GetComponent<Renderer>().material = otherMaterial;
        mappingManager.DrawVisualMeshes = false;
    }
    
    void Awake ()
    {
        mappingManager = GetComponentInChildren<SpatialMappingManager>();
        planesMaker = GetComponentInChildren<SurfaceMeshesToPlanes>();
        verticesRemover = GetComponentInChildren<RemoveSurfaceVertices>();
        horizontalObjects = new List<GameObject>();
        verticalObjects = new List<GameObject>();
        otherObjects = new List<GameObject>();
    }

    void Start()
    {
        SurfaceMeshesToPlanes.Instance.MakePlanesComplete += removeVertices;
        RemoveSurfaceVertices.Instance.RemoveVerticesComplete += planesReady;
        InputManager.Instance.PushFallbackInputHandler(gameObject);
        mappingManager.CleanupObserver();
        mappingManager.StartObserver();
    }
    
    void Update ()
    {
        return;
	}
}
