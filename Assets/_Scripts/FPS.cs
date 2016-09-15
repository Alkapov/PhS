using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour {


	private float fpsUpdateInterval = 0.5f;
	private float fpsAccum = 0;
	private int fpsFrames = 0;
	private float fpsTimeLeft;
	private string fpsString;
	
//----------------------------------------------------------------------------------------
	void Start () {
		
		fpsTimeLeft = fpsUpdateInterval;
		
		Time.timeScale = 1.0f;
	}
	
//----------------------------------------------------------------------------------------
	void Update () {
	
		float deltaTime = Time.deltaTime;

		fpsTimeLeft -= deltaTime;
		fpsAccum += Time.timeScale/deltaTime;
		fpsFrames ++;
    
		if (fpsTimeLeft <= 0){
			float fps = fpsAccum/fpsFrames;
			fpsString = System.String.Format("{0:F2} FPS",fps);
	
			fpsTimeLeft = fpsUpdateInterval;
			fpsAccum = 0;
			fpsFrames = 0;
    	}
	}

//--------------------------------------------	
	void OnGUI() {

		GUI.Box(new Rect (5, 5, 100, 23), fpsString);
	}
}
