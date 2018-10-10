using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    private float seconds;
    private float minutes;
    private string secondsToShow;
	
	// Update is called once per frame
	void Update () {
        seconds += Time.deltaTime;
        minutes = Mathf.FloorToInt(seconds / 60);
        secondsToShow = Mathf.FloorToInt((seconds - minutes * 60)).ToString();
        if(secondsToShow.Length==1)
        {
            secondsToShow = "0" + secondsToShow;
        }
	}

    void OnGUI()
    {
        GUI.Box(new Rect(0, Screen.height - 25, 150, 25), "Time spent: "+Mathf.FloorToInt(minutes).ToString() + ":" + secondsToShow);
    }

}
