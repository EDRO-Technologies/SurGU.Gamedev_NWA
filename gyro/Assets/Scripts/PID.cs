using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PID
{
	public float P;
	public float I;
	public float D;

	private float prevErr;
	private float sumErr;

	public float CalculateForce(float current, float target)
	{
		float dt = Time.fixedDeltaTime;

		float err = target - current;
		sumErr += err;

		float force = P * err + I * sumErr * dt + D * (err - prevErr) / dt;

		prevErr = err;
		return force;
	}
}
