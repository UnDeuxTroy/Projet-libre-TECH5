using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MainMenuButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    private Button button;
    private Image icon;
    private AudioSource sound;

	// Use this for initialization
	void Start () {
        button = this.GetComponent<Button>();
        icon = transform.GetChild(1).GetComponent<Image>();
        icon.enabled = false;
        sound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPointerEnter(PointerEventData eventData)
    {
        icon.enabled = true;
        sound.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        icon.enabled = false;
    }
}
