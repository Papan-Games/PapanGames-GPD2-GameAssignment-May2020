using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {

	public float speed;

	void FixedUpdate() 
	{
		// Rotate the object around its local Y axis at 1 degree per second
		transform.Rotate(Vector3.up * speed * Time.fixedDeltaTime);
		transform.Rotate(Vector3.left * speed * Time.fixedDeltaTime);
	}
}
