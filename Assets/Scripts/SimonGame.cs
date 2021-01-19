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

        simonPlayer.TakeTurn(numberOfPresses);
        turnTaken = true;
    }

    public int playerButtonPress = 0;

    private void HandleButtonPressed(Button obj)
    {
        Debug.Log("<color=green>SimonGame here, a button was pressed: " + obj.name + "</color>");

        if (turn == 0)
        {
            simonsTurn.Add(obj.name);
        }

        if (turn == 1)
        {
            if (playerButtonPress == numberOfPresses - 1) 
            {
                Debug.Log("Great job! You successfully repeated Simon's pattern!");
                numberOfPresses++;
                Invoke("SwitchTurn", 2f);
                
                return;
            }
            
            if (simonsTurn[playerButtonPress].Equals(obj.name)) 
            {
                Debug.Log(("You hit thhe right button!")); 
            } 
            
            else
            {
                Debug.Log("You hit the wrong button! Game Over!");
                numberOfPresses = 2;
                Invoke("SwitchTurn", 2f);
                return;
            }
            playerButtonPress++;
        }
    }

    void SwitchTurn()
    {
        turn = 0;
        player.isOurTurn = false;
        turnTaken = false;
        playerButtonPress = 0;
        simonsTurn.Clear();
    }

    List<string> simonsTurn = new List<string>();
    bool turnTaken = false;

    // Update is called once per frame
    void Update()
    {
        //It's Simon's turn
        if (turn == 0 && !turnTaken)
        {
            simonPlayer.TakeTurn(numberOfPresses);
            turnTaken = true;
        }
        else if (turn == 0 && turnTaken)
        { 
            if (simonsTurn.Count == numberOfPresses)
            {
                Debug.Log("<color=green>SimonGame here! Simon has finished his turn:" + simonsSelection() + ", now it's your turn to play!</color>");
                player.isOurTurn = true;
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
        
        {
           simonsSelectionString += simonsSelectionString + ", ";
        }

        return simonsSelectionString;
    }
}
