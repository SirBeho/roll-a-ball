using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class boton_in : MonoBehaviour
{
	public Button BTNpreserLV;

	public AudioClip boton;
	private AudioSource sonido;
	// Start is called before the first frame update
	void Start()
	{
		BTNpreserLV.onClick.AddListener(LVpreservativos);
		sonido = GetComponent<AudioSource>();
	}

	void LVpreservativos()
	{

		SceneManager.LoadScene("juego");
		sonido.PlayOneShot(boton, 1.0f);
	}

}
