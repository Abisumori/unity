using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
	//жизнь костра
	public float burningTime = 15;
	//согревание костра
	public float heatDissipation = 0.1f;

	//Костёр гаснет спустя время
	void Update()
	{
		lifeTime -= Time.deltaTime;
		if (lifeTime <= 0)
		{
			gameObject.SetActive(false);
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.GetComponent<Temperature>() != null)
		{
			Temperature temperature = other.GetComponent<Temperature>();
			// греем игрока, если температура ниже нужной
			if (temperature.temperature < temperature.normalTemperature)
			{
				temperature.temperatureCurrent += heatDissipation * Time.deltaTime;
			}
		}
	}
}

