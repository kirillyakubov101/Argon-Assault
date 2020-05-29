using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
	private void Awake()
	{
		DontDestroyOnLoad(this);
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
