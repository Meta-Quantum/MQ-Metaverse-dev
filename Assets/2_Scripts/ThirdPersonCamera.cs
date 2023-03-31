using GameCreator.Runtime.Cameras;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
	[SerializeField] private Camera myCamera;
	private ShotCamera shotCamera;
	
	private void Awake() {
		shotCamera = GetComponent<ShotCamera>();
	}
	
	public Camera GetCamera() {
		return myCamera;
	}
	
	public void UpdateCameraStatus(bool status) {
		shotCamera.enabled = status;
	}
}
