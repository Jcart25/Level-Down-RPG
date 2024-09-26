using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceMenuSelect : MonoBehaviour
{
    public GameObject ChoiceMenu;
    public GameObject ChoiceIcon;
    public Transform Choicepos1, Choicepos2, Choicepos3;
    public float PlayerChoice = 1;
    public PlayerAttack PA;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveIcon();

        if (PlayerChoice == 1)
        {
            ChoiceIcon.transform.position = Choicepos1.position;

            if(Input.GetKeyDown(KeyCode.Space))
            {
                ChoiceMenu.SetActive(false);
                PA.SwordAttack = true;
            }
        }

        if (PlayerChoice == 2)
        {
            ChoiceIcon.transform.position = Choicepos2.position;
        }

        if (PlayerChoice == 3)
        {
            ChoiceIcon.transform.position = Choicepos3.position;
        }

    }

    public void MoveIcon()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerChoice -= 1;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerChoice += 1;
        }

        if(PlayerChoice > 3)
        {
            PlayerChoice = 1;
        }

        if (PlayerChoice < 1)
        {
            PlayerChoice = 3;
        }
    }
}
