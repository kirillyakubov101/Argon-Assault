using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	private void Awake()
	{
		int amountOfObjects = FindObjectsOfType<MusicPlayer>().Length;
		if(amountOfObjects > 1)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
		}
		
	}

	private void Start()
	{
		Invoke("LoadFirstScene",3f);
	}

	private void LoadFirstScene()
	{
		SceneManager.LoadScene(1);
	}
}
