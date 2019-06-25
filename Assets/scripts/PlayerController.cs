using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	//public int PrefabGenerator;
	
	private  float speed=2;
	//public Text CountText;
	private Rigidbody2D rb2d;
	// public Text WinText;
	private int count;

	public GameObject TrajectoryPointPrefeb;
	public GameObject BallPrefb;
	private GameObject ball;
	private bool isPressed, isBallThrown;
	private float power = 5;
	private int numOfTrajectoryPoints = 30;
	private List<GameObject> trajectoryPoints;
	
	
	void Start(){
		trajectoryPoints= new List<GameObject>();
		isPressed=false;
		isBallThrown=false;

		for(int i=0;i<numOfTrajectoryPoints;i++){
			GameObject dot = Instantiate(TrajectoryPointPrefeb);
			//dot.GetComponent<renderer>().enabled = false;
			dot.SetActive(false);
			trajectoryPoints.Insert(i,dot);
		}
	}
	
	void Update(){
		// if(isBallThrown){
		// 	return;
		// }

		if(Input.GetMouseButton(0)){
			isPressed=true;
			//if(!ball){
				createBall();
			//}
		}
		else if(Input.GetMouseButtonUp(0)){
			isPressed=false;
			//if(!isBallThrown){
				throwBall();
			//}
		}

		if(isPressed){
			Vector3 vel = GetForceFrom(ball.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));
			float angle = Mathf.Atan2(vel.y, vel.x) * Mathf.Rad2Deg;
			transform.eulerAngles = new Vector3(0, 0, angle);
			setTrajectoryPoints(transform.position, vel / ball.GetComponent<Rigidbody>().mass);
		}
	}

	private void createBall(){
		ball = (GameObject)Instantiate(BallPrefb);
		Vector3 pos =transform.position;
		pos.z=1;
		ball.transform.position=pos;
		ball.SetActive(false);
	}

	private void throwBall(){
		ball.SetActive(true);
		ball.GetComponent<Rigidbody>().useGravity =true;
		ball.GetComponent<Rigidbody>().AddForce(GetForceFrom(ball.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)), ForceMode.Impulse);
		isBallThrown=true;

	}

	private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos){
		//(-) indicates force oppsite direction it is dragged
		return -(new Vector2(toPos.x,toPos.y)-new Vector2(fromPos.x,fromPos.y))*power;

	}


	void setTrajectoryPoints(Vector3 pStartPosition,Vector3 pVelocity){
		float velocity =Mathf.Sqrt((pVelocity.x*pVelocity.x)+(pVelocity.y*pVelocity.y));
		float angle =Mathf.Rad2Deg*Mathf.Atan2(pVelocity.y, pVelocity.x);


		float fTime = 0;
		fTime += 0.1f;
		for (int i = 0; i < numOfTrajectoryPoints; i++){
			float dx = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
			//gravity on trajectory
			// float dy = velocity * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (Physics2D.gravity.magnitude * fTime * fTime / 2.0f);

			//straight line trajectory
			float dy = velocity * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (0 * fTime * fTime / 2.0f);
			Vector3 pos = new Vector3(pStartPosition.x + dx, pStartPosition.y + dy, 2);
			trajectoryPoints[i].transform.position = pos;
			trajectoryPoints[i].SetActive(true);
			trajectoryPoints[i].transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(pVelocity.y - (Physics.gravity.magnitude) * fTime, pVelocity.x) * Mathf.Rad2Deg);
			fTime += 0.1f;
		}
	}
}
