using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour {

	float shakeAmount = 0;
	public float freezeFrameTime = 0.1f;

	public void Shakes(float amt, float lenght)
	{
		shakeAmount = amt;
		InvokeRepeating ("BeginShake", 0, 0.01f);
		Invoke ("StopShake", lenght);
	}

	public void FreezeFrame()
	{
		StartCoroutine (FreezeFrame (freezeFrameTime));
	}

	void BeginShake()
	{
		if (shakeAmount > 0) {
			Vector3 camPos = transform.position;

			float offSetX = Random.value * shakeAmount * 2 - shakeAmount;
			float offSetY = Random.value * shakeAmount * 2 - shakeAmount;
		
			camPos.x = offSetX;
			camPos.y = offSetY;

			transform.position = camPos;
		}
	}

	void StopShake()
	{
		CancelInvoke ("BeginShake");
		transform.position = Vector3.zero;
	}

	private IEnumerator FreezeFrame(float time)
	{
		Time.timeScale = 0.0f;
		yield return new WaitForSecondsRealtime (time);
		Time.timeScale = 1.0f;
	}
}