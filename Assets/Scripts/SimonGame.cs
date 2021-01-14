using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonGame : MonoBehaviour
{
    [SerializeField]
    Simon simonPlayer;
    [SerializeField]
    Player player;
    [SerializeField]
    List<Button> buttons = new List<Button>();

    //If this is 0 then it's Simon's turn, if it's 1 then it's the player's turn
    int turn = 0;

    int numberOfPresses = 2;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Button b in buttons)
        {
            b.buttonPressed += HandleButtonPressed;
        }
    }

    private void HandleButtonPressed(Button obj)
    {
        Debug.Log("<color=green>SimonGame here, a button was pressed: " + obj.name + "</color>");

        if (turn == 0)
        {
            simonsTurn.Add(obj.name);
        }
    }

    List<string> simonsTurn = new List<string>();

    // Update is called once per frame
    void Update()
    {
        //It's Simon's turn
        if (turn == 0)
        {
            if (simonsTurn.Count == numberOfPresses)
            {
                Debug.Log("<color=green>SimonGame here! Simon has finished his turn:" + simonsSelection() + "</color>");
                turn = 1;
            }
        }

        //It's player's turn
        if (turn == 1)
        {

        }
    }

    private string simonsSelection()
    {
        string simonsSelectionString = "";
        foreach (string s in simonsTurn)
        {
            simonsSelectionString += s + ", ";
        }

        return simonsSelectionString;
    }
}
