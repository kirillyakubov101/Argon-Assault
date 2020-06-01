using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
	[SerializeField] float delayTime = 2f;
	[SerializeField] GameObject deathVFX;

	private void OnTriggerEnter(Collider other)
	{
		SetDeathSequance();
	}

	private void SetDeathSequance()
	{
		SendMessage("SetControlStatus", false);
		deathVFX.SetActive(true);
		Invoke("ReloadScene", delayTime);
	}

	private void ReloadScene()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
	}
}
