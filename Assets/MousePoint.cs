using UnityEngine;
using System.Collections;

public class MousePoint : MonoBehaviour {


//	// Update is called once per frame
//	void FixedUpdate () {
//		
//		Vector3 mousePos = Input.mousePosition;
//		mousePos.z = -(transform.position.x - Camera.mainCamera.transform.position.x);
//		Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
//
//		transform.LookAt (worldPos);
//	}

	Vector3 mouse_pos, object_pos;
	float angle;

	void FixedUpdate() {
		mouse_pos = Input.mousePosition;
		mouse_pos.z = 5.23f; // the distance between camera and obejct
		object_pos = Camera.main.WorldToScreenPoint(transform.position);
		mouse_pos.x = mouse_pos.x - object_pos.x;
		mouse_pos.y = mouse_pos.y - object_pos.y;
		angle = Mathf.Atan2 (mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0,0,angle);
	}
}
