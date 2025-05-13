using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float zoomSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 30f;

    private Camera cam;

    public static bool isTopDown = false;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start()
    {
        cam = Camera.main;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }

    void Update()
    {
        HandleMovement();
        HandleZoom();
        HandleTopDownToggle();
    }

    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical"); 

        Vector3 direction = new Vector3(h, 0, v);
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            float newSize = cam.orthographic ? cam.orthographicSize - scroll * zoomSpeed : cam.fieldOfView - scroll * zoomSpeed;

            if (cam.orthographic)
                cam.orthographicSize = Mathf.Clamp(newSize, minZoom, maxZoom);
            else
                cam.fieldOfView = Mathf.Clamp(newSize, minZoom, maxZoom);
        }
    }

    void HandleTopDownToggle()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isTopDown)
            {

                originalPosition = transform.position;
                originalRotation = transform.rotation;

                transform.position = new Vector3(transform.position.x, 20f, transform.position.z);
                transform.rotation = Quaternion.Euler(90f, 0f, 0f); 
                CameraController.isTopDown = true;
            }
            else
            {
                transform.position = originalPosition;
                transform.rotation = originalRotation;
                CameraController.isTopDown = false;
            }
        }
    }
}