using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prefabCollide : MonoBehaviour {

	public Text CountText;
	private Rigidbody rb2d;
	private int count=0;


	void  Awake(){
		CountText = GetComponent<Text> ();
		
	}


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody>();
		// GameObject text = new GameObject("CountText");
		// Text myText = ngo.AddComponent<Text>();
    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.gameObject.CompareTag("rocket")){
			other.gameObject.SetActive(false);
			gameObject.SetActive(false);
			count=count+1;
			//SetCountText();
		}
	}
	void SetCountText(){
		CountText.text="Count: "+ count.ToString();
		
	}
}
