using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PID : MonoBehaviour
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

	public float calculateForce(float current, float target)
	{

		float dt = Time.fixedDeltaTime;

		float err = target - current;
		this.sumErr += err;

		float force = this.P * err + this.I * this.sumErr * dt + this.D * (err - this.prevErr) / dt;

		this.prevErr = err;
		return force;
	}
}
