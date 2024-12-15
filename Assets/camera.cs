using UnityEngine;

public class camera : MonoBehaviour
{
    public Camera defaultCamera;  // Reference to the default camera
    public Camera mapViewCamera;  // Reference to the map view camera

    private bool isMapView = false; // Tracks whether the map view is active

    void Start()
    {
        // Ensure only the default camera is active at the start
        if (defaultCamera != null) defaultCamera.enabled = true;
        if (mapViewCamera != null) mapViewCamera.enabled = false;
    }

    void Update()
    {
        // Check if the "M" key is pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleCameraView();
        }
    }

    void ToggleCameraView()
    {
        // Toggle the camera states
        isMapView = !isMapView;

        if (defaultCamera != null) defaultCamera.enabled = !isMapView;
        if (mapViewCamera != null) mapViewCamera.enabled = isMapView;

        Debug.Log(isMapView ? "Switched to Map View Camera" : "Switched to Default Camera");
    }
}
