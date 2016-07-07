using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimePlayed : MonoBehaviour {
	Text timer;

	float time;
	float timeStamp=0;
	float updateTime = 0.01f;
	// Use this for initialization
	void Start () {
		timer = gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		time = Time.time;
		if (time >= timeStamp+updateTime) {
			timeStamp = time;
			int min = (int)((time / 60) % 60);
			int sek = (int)(time % 60);
			int hundreth = (int)(time * 100 % 100);
			timer.text = (min<10 ? "0"+min : ""+min) +":"+(sek<10 ? "0"+sek : ""+sek) + ":" +(hundreth<10 ? "0"+hundreth : ""+hundreth);
			//Debug.Log (time);
		}
	}


}
