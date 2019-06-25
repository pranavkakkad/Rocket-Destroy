using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rocket : MonoBehaviour {

		public int time;
		public int noEnemy;
		
	
		// Update is called once per frame
	void Update () {
	//	transform.Rotate(new Vector3(0,0,45)*Time.deltaTime);	
	}

	//Generate prefab
	//move prefab left to right and check whether point is scored or not
	void OnTriggerEnter2D(Collider2D other){
		// if(other.gameObject.CompareTag("PickUp")){
		// 	other.gameObject.SetActive(false);
		// 	count=count+1;
			
		//}
	}
}
