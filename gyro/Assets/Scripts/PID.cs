using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PID
{
	private float P;
	private float I;
	private float D;

	private float prevErr;
	private float sumErr;

	public PID(float P, float I, float D)
	{
		this.P = P;
		this.I = I;
		this.D = D;
	}

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
