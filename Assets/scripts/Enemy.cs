using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

		public int time;
		public int noEnemy;
		//public Text CountText;
		public Text WinText;
		private int movementSpeed;
		public GameObject coins;
		private int y;
		private List<GameObject> pos;
		private float distance;
	private int t=0;

	
	void Start(){
		pos= new List<GameObject>();
		InvokeRepeating("GeneratePrefab", 0f, time);
		WinText.text="";
	}
		
	void Update () {
		move(noEnemy);
		
	}
	

	//Generate prefab
	void GeneratePrefab(){
		int t = time;
		int Enemy = noEnemy;
		for(int i=0;i<Enemy;i++){
			y=Random.Range(-5,12);
			//offset.Add(y);
			pos.Add(Instantiate(coins,new Vector3(-16,y,0),Quaternion.identity));
		}
		
		

	}
	//move prefab left to right and check whether it reached last and destroy
	void move(int Enemy){
		List<GameObject> destryableEnemies = new List<GameObject>();
		// int distance = Mathf.Abs(-16)
		// int count = noEnemy;
		for(int i=0;i<pos.Count;i++){
			movementSpeed=Random.Range(1,10);
			//pos[i].transform.position += Vector3.right * Time.deltaTime * movementSpeed;
			pos[i].transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
			//Debug.Log(pos[i].transform.position.x);
			
			distance  = Mathf.Abs(-16-pos[i].transform.position.x);
			if(distance>29.5){
				destryableEnemies.Add(pos[i]);
				// pos.Remove(pos[i]);
				WinText.text = "YOU LOOSE!!";
				Time.timeScale = 0;
			}
		}

		foreach (GameObject item in destryableEnemies)
		{
				pos.Remove(item);
				noEnemy--;
				Destroy(item);			
		}
	}

	


	
}
