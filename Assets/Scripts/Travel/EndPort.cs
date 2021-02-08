﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class EndPort : MonoBehaviour
{
    public Slider loadingBar;

    // Called when loading new game scene
	public void LoadNewLevel () {
		StartCoroutine(LoadAsynchronously("Story"));
	}

	// Load Bar synching animation
	IEnumerator LoadAsynchronously (string sceneName){ 
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

		while (!operation.isDone){
			float progress = Mathf.Clamp01(operation.progress / .9f);
			
			loadingBar.value = progress;

			yield return null;
		}
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.GetComponent<ShipMovement>().movementSpeed = 0;
            collider.gameObject.GetComponent<Thrusters>().Stop();
            LoadNewLevel();
        }
    }
}
