using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour
{
	public Health health;
	public int playerDamage = 2;
	public float temperature = 36.6f;
	public float normalTemperature = 36.6f;
	public float criticalTemperature = 34f;
	public float coldSpeed = 0.05f;
	float freezeDamageTimer = 1;
	public float freezeDamageDelay = 2;

	void Update()
	{
		// Температура падает с заданной скоростью
		temperature -= coldSpeed * Time.deltaTime;

		// когда температура упала ниже критической, игрок получает урон
		if (temperature <= criticalTemperature)
		{
			if (freezeDamageTimer <= 0)
			{
				health.TakeDamage(playerDamage);
				freezeDamageTimer += freezeDamageDelay;
			}
			else
			{
				freezeDamageTimer -= Time.deltaTime;
			}
		}
	}
}
