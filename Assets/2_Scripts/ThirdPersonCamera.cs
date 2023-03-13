using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
	[SerializeField] private Camera myCamera;
	
	public Camera GetCamera() {
		return myCamera;
	}
}
