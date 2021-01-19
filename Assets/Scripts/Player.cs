using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera cam; //Rreference for main camera
    Ray ray; // Reference for our mouse/finger/fire press position

    public bool isOurTurn = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; //Unity gives us the current camera
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOurTurn) return;

        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Someone pressed the fire button!");
            ray = cam.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 3f);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag.Equals("Button"))
                {
                    Button button = hit.transform.GetComponent<Button>();
                    Debug.Log("<color=green>We hit an object!</color> " + hit.transform.gameObject.name);
                    button.Activate();
                }
            }  
        }
    }

   
}
