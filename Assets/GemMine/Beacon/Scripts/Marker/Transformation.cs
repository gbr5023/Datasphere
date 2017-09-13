using UnityEngine;

public class Transformation : MonoBehaviour {

	private float speed = 60.0f;  //This will determine max rotation speed, you can adjust in the inspector
	private float zoomSpeed = 30.0f;

    public Transform cam;  //Drag the camera object here

    void Update()
    {
        //If you want to prevent rotation, just don't call this method
		//TransformObject();

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		transform.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);

		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.back * speed * Time.deltaTime;
		}

        //RotateObject();
    }

    void TransformObject()
    {
        transform.Rotate(cam.up, -Input.GetAxis("Mouse X") * speed,
                                         Space.World);
        transform.Rotate(cam.right, Input.GetAxis("Mouse Y") * speed,
                                      Space.World);
    }

}
