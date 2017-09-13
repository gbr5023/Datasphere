using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    // transformation of camera
    protected Transform xFormCamera;
    // transformatino of pivot object
    protected Transform xFormParent;

    // store ongoing rotation of object in every frame
    protected Vector3 localRotation;
    protected float cameraDistance = 1000f;

    // how much camera orbits per frame
    public float mouseSensitivity = 4f;
    // how much you scroll
    public float scrollSensitivity = 2f;
    // how long it takes to reach its destination
    public float orbitSpeed = 10f;
    public float scrollSpeed = 6f;

    public bool cameraDisabled = false;
	
    // Use this for initialization
	void Start ()
    {
        this.xFormCamera = this.transform;
        this.xFormParent = this.transform.parent;	
	}
	
	// LateUpdate b/c calls camera after everything else renders
    // may cause weird behavior if just Update
	void LateUpdate ()
    {
		if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            cameraDisabled = !cameraDisabled;
        }

        if(!cameraDisabled)
        {
            // Rotation of the Camera based on Mouse coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                localRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                localRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                // clamp the y rotation to horizon and not flipping over
                localRotation.y = Mathf.Clamp(localRotation.y, 0f, 90f);
            }

            if(Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

                scrollAmount *= (this.cameraDistance * 0.3f);
                this.cameraDistance += scrollAmount * -1f;
                this.cameraDistance = Mathf.Clamp(this.cameraDistance, 1.5f, 100f);
            }
        }

        // Actual Camera Rig Transformations
        Quaternion qt = Quaternion.Euler(localRotation.y, localRotation.x, 0);
        this.xFormParent.rotation = Quaternion.Lerp(this.xFormParent.rotation, qt, Time.deltaTime * orbitSpeed);
        if(this.xFormCamera.localPosition.z != this.cameraDistance * -1f)
        {
            this.xFormCamera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this.xFormCamera.localPosition.z, this.cameraDistance * -1f, Time.deltaTime * scrollSpeed));
        }
    }
}
