using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour {

	public float Tempo;

	float count;

	void Update () 
	{
		count += 1f * Time.deltaTime;

		if (count > Tempo) 
		{
			Destroy (gameObject);
		}
	}
}
