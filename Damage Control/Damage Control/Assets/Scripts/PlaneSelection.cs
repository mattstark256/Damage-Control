using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(GameController), typeof(AirportManager))]
public class PlaneSelection : MonoBehaviour
{
    private GameController gameController;
    private AirportManager airportManager;

    [SerializeField]
    private float planeClickRadius = 50f;
    [SerializeField]
    private Button endTurnButton;
    [SerializeField]
    private SelectedIcon selectedIconPrefab;

    private List<Plane> selectedPlanes = new List<Plane>();


    private void Awake()
    {
        gameController = GetComponent<GameController>();
        airportManager = GetComponent<AirportManager>();
    }


    void Update()
    {
        if (!gameController.TransitionInProgress)
        {
            Plane plane = GetPlaneNearPointer();
            if (plane != null)
            {
                // TODO add some kind of hover indicator
                if (Input.GetButtonDown("Fire1"))
                {
                    if (plane.isSelected)
                    {
                        DeselectPlane(plane);
                    }
                    else
                    {
                        SelectPlane(plane);
                    }
                }
            }
        }
    }


    public void DeselectAll()
    {
        while (selectedPlanes.Count>0)
        {
            DeselectPlane(selectedPlanes[0]);
        }
    }


    private Plane GetPlaneNearPointer()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return null; }
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        foreach (Plane plane in gameController.planes)
        {
            if (plane.country.IsHostile) continue;
            float distanceFromPointer = Vector3.Distance(plane.transform.position, mousePosition);
            if (distanceFromPointer < planeClickRadius)
            {
                return plane;
            }
        }
        return null;
    }


    private void SelectPlane(Plane plane)
    {
        plane.isSelected = true;
        selectedPlanes.Add(plane);
        SelectedIcon newIcon = Instantiate(selectedIconPrefab);
        newIcon.transform.SetParent(plane.transform, false);
        UpdateEndTurnButton();
    }


    private void DeselectPlane(Plane plane)
    {
        plane.isSelected = false;
        selectedPlanes.Remove(plane);
        SelectedIcon iconToDestroy = plane.GetComponentInChildren<SelectedIcon>();
        if (iconToDestroy == null) { Debug.Log("Selected icon is missing, this should not have happened"); return; }
        Destroy(iconToDestroy.gameObject);
        UpdateEndTurnButton();
    }


    public void UpdateEndTurnButton()
    {
        endTurnButton.interactable = 
            selectedPlanes.Count == airportManager.GetAvailableAirportCount() ||
            selectedPlanes.Count < airportManager.GetAvailableAirportCount() &&
            selectedPlanes.Count == NumberOfPlanesThatCouldLand();

        // Debug.Log(NumberOfPlanesThatCouldLand());
        //Debug.Log("available runways: "+gameController.GetAvailableAirportCount());
    }

    private int NumberOfPlanesThatCouldLand()
    {
        int i = 0;
        foreach(Plane plane in gameController.planes)
        {
            if (!plane.country.IsHostile) { i++; }
        }
        return i;
    }
}
