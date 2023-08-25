using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{

	[SerializeField] public float steerSpeed = 280f;
	[SerializeField] public float moveSpeed = 5f;

	[SerializeField] public float maxSpeed = 50f;

	[SerializeField] public float minSpeed = 20f;





	float steerAmount;

	float startAngularDrag;
	float startOrthoSize;

	void CameraFunctions()
	{


		if (moveSpeed > startOrthoSize)
		{
			Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5f, Time.deltaTime * 0.5f);
		}
		else
		{
			Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, startOrthoSize, Time.deltaTime * 0.5f);
		}

		Camera.main.transform.position = (Camera.main.transform.position - new Vector3(transform.position.x, transform.position.y, -10f)) * Time.deltaTime * 10f;
	}




	void Start()
	{
		startOrthoSize = Camera.main.orthographicSize;
		startAngularDrag = GetComponent<Rigidbody2D>().angularDrag;
	}



	void Update()
	{
		float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
		float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
		transform.Rotate(0, 0, -steerAmount);
		transform.Translate(0, moveAmount, 0);
	}

}