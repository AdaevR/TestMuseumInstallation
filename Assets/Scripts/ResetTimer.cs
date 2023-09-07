using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetTimer : MonoBehaviour
{
	[SerializeField] private float _timeToReset = 30f;

	public bool isActive = false;

	private float _timer = 0f;

	private void Update()
	{
		if (isActive)
		{
			if (Input.touches.Length > 0)
			{
				_timer = _timeToReset;
			}
			else
			{
				_timer -= Time.deltaTime;
				if (_timer <= 0)
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
			}
		}
	}
}
