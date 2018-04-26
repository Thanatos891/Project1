using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coroutine : MonoBehaviour {

	public Text timerText;
	//delegate for updating current timer. 
	public delegate void assMunch(float x);
	//delegate for end of timer. 
	public delegate void slurp();
	//bool to see if timer is active. 
	public bool isRunning = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
	public void StartTimer()
	{
		StopAllCoroutines ();

		//function you write inside of another function. 
		//function below updates the text timer as time passes. 
		assMunch lambda = (float z) => {
			timerText.text = z.ToString ("X");
		};
		StartCoroutine(Countdown(4,UpdateText,StopTimer));
		isRunning = true;

	}
	void UpdateText(float y)
	{
		//format text in project to only have 2 decimal places.
		timerText.text = y.ToString("#.00");
	}
	public void PauseTimer()
	{
		isRunning = false;
	
	}
	void StopTimer()
	{
		//set final timer text to 0;
		timerText.text = "0";
	}
	public void ResumeTimer()
	{
		isRunning = true;
	}

	//timer for counting down. 
	//counts down using a while loop, then subtracts actual time from float. 
	IEnumerator Countdown(float timer,assMunch munchMunch,slurp glurp)
	{
		while (timer > 0) {
			yield return null;
			//checking to see if the timer isn't running
			while(!isRunning) 
				{
				//do nothing. 
				yield return null;
				}
			//if timer is running, reduce timer by Time.DeltaTime.
			timer = timer - Time.deltaTime;
			munchMunch (timer);
		}
		glurp();
	}
	public void PrintSomething()
	{
		Debug.Log ("Tiddies");
	}
}
