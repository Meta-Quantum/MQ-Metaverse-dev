using System;
using UnityEngine;

public class MousePainter : MonoBehaviour{
	public Camera cam;
	[Space]
	public bool mouseSingleClick;
	[Space]
	public Color paintColor;
    
	public float radius = 1;
	public float strength = 1;
	public float hardness = 1;
	
	public bool isActive = false;

	private void Update(){
		if(isActive)
		{
			bool click = mouseSingleClick ? Input.GetMouseButtonDown(0) : Input.GetMouseButton(0);
 
			if (click){
				Vector3 position = Input.mousePosition;
				Ray ray = cam.ScreenPointToRay(position);
				RaycastHit hit;

				if (Physics.Raycast(ray, out hit, 100.0f)){
					Debug.DrawRay(ray.origin, hit.point - ray.origin, Color.red);
					Debug.Log("Hit " + hit.collider.name);
					transform.position = hit.point;
					Paintable p = hit.collider.GetComponent<Paintable>();
					if(p != null){
						Debug.Log("Painting " + p.name);
						PaintManager.instance.paint(p, hit.point, radius, hardness, strength, paintColor);
					}
				}
			}
		}
	}
	
	

}