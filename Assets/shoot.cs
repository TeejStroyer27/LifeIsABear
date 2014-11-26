using UnityEngine;
using System.Collections;

public class shoot : MonoBehaviour {
	public float fireRate=0;
	public LayerMask whatToHit;
	public Vector3 incrementAmount;
	public Vector3 decrementAmount;
	float timeToFire=0;
    void Awake(){
		Screen.lockCursor = true;
		Screen.showCursor = false;
	}
    void Update()
    {
		//Shoot Grow
		if(fireRate==0){
				if (Input.GetMouseButtonDown(0)){
					ShootGrow();
				}
			}
			else{
				if (Input.GetMouseButton(0)&& Time.time> timeToFire){
					timeToFire=Time.time+1/fireRate;
					ShootGrow();
				}
			}
		//Shoot Shrink
		if(fireRate==0){
			if (Input.GetMouseButtonDown(1)){	
				ShootShrink();
			}
		}
		else{
			if (Input.GetMouseButton(1)&& Time.time> timeToFire){	
					timeToFire=Time.time+1/fireRate;
					ShootShrink();
			}
		}
	}	
	void ShootGrow(){
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth/2,Camera.main.pixelHeight/2,0));
		RaycastHit hit;
		if( Physics.Raycast(ray, out hit, 100))
		{
			Debug.DrawLine(ray.origin, hit.point, Color.red, 100);
			Vector3 s = hit.collider.transform.localScale;
			s.x += incrementAmount.x;
			s.y += incrementAmount.y;
			s.z += incrementAmount.z;
			hit.collider.transform.localScale = s;

		}
	}
	void ShootShrink(){
		//Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth/2,Camera.main.pixelHeight/2,0));
		RaycastHit hit;
		if( Physics.Raycast(ray, out hit, 100))
		{
			Debug.DrawLine(ray.origin, hit.point, Color.red, 100);
			Vector3 s = hit.collider.transform.localScale;
			s.x -= decrementAmount.x;
			s.y -= decrementAmount.y;
			s.z -= decrementAmount.z;
			hit.collider.transform.localScale = s;
		}
	}
	//Crosshair
	void OnGUI(){
     GUI.Box(new Rect(Screen.width/2,Screen.height/2, 10, 10), "");
	}
}