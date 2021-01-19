using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    Color buttonColor;

    Material material;
    AudioSource audio;

    public event Action<Button> buttonPressed;
    public float buttonSpeed = 0.1f;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.color = buttonColor;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Coroutine coroutine;
    internal void Activate()
    {
        //The button is animating so it cannot be pressed again
        if (isAnimating) return;

        Debug.Log(gameObject.name + " has been pressed");

        //Stop any coroutine that's happening before we start a new one
        if (coroutine != null) StopCoroutine(coroutine);

        audio.Play();
        Invoke("StopPlayingAudio", 0.2f);
        
        //Start a new coroutine to animate the button
        coroutine = StartCoroutine(ChangeObjColor(GetComponent<Renderer>().material));

        //Fire off event to let anyone hooked up to this button know that it has been pressed
        if (buttonPressed != null) buttonPressed(this);
    }

    void StopPlayingAudio()
    {
        audio.Stop();
    }

    bool isAnimating = false;
    

    private IEnumerator ChangeObjColor(Material material)
    {
        isAnimating = true;
        LeanTween.cancel(gameObject);
        //Tween our color change
        LeanTween.moveLocalZ(gameObject, 0.2f, buttonSpeed);
        //LeanTween.color(gameObject, Color.black, 0.5f).setEase(LeanTweenType.easeInOutSine);

        //material.color = Color.black;
        yield return new WaitForSeconds(buttonSpeed);

        //Tween our color change
        LeanTween.moveLocalZ(gameObject, 0, buttonSpeed);
        //LeanTween.color(gameObject, buttonColor, 0.5f).setEase(LeanTweenType.easeInOutSine);

        //material.color = buttonColor;
        isAnimating = false;
    }
}
