using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField]
    Color buttonColor;

    Material material;

    public float buttonSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.color = buttonColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Coroutine coroutine;
    internal void Activate()
    {
        if (isAnimating) return;

        Debug.Log(gameObject.name + " has been pressed");

        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(ChangeObjColor(GetComponent<Renderer>().material));

        if (buttonPressed != null) buttonPressed(this);
    }

    bool isAnimating = false;
    internal Action<Button> buttonPressed;

    private IEnumerator ChangeObjColor(Material material)
    {
        isAnimating = true;
        LeanTween.cancel(gameObject);
        //Tween our color change
        LeanTween.moveLocalZ(gameObject, 0.2f, 0.5f);
        LeanTween.color(gameObject, Color.black, 0.5f).setEase(LeanTweenType.easeInOutSine);

        //material.color = Color.black;
        yield return new WaitForSeconds(1.5f);

        //Tween our color change
        LeanTween.moveLocalZ(gameObject, 0, 0.5f);
        LeanTween.color(gameObject, buttonColor, 0.5f).setEase(LeanTweenType.easeInOutSine);

        //material.color = buttonColor;
        isAnimating = false;
    }
}
