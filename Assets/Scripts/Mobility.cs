﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MoveDir { Up, Down, Left, Right }

public class Mobility : MonoBehaviour
{
    // Public Vars
    public GameObject laserPrefab;
    
     //Should be chang      ed to be a list of all possible buildings
    
    // Private Vars
    private bool moving = false;
    private bool posMove = true;
    private int speed = 10;
    private int buttonPress = 0;
    private MoveDir dir = MoveDir.Up;
    private Vector3 pos;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(laserPrefab, pos, Quaternion.identity);
            gridManager.theGrid.placeBuilding((int)(pos.x + 6.5), (int)(pos.y + 3.5), Building.Laser, Player.PlayerOne);
            print(gridManager.theGrid.getCellInfo((int)(pos.x + 6.5), (int)(pos.y + 3.5)).toString());
        }
        buttonPress--;
        if (posMove)
        {
            pos = transform.position;
            moveTower();
        }
        if (moving)
        {
            if (transform.position == pos)
            {
                moving = false;
                posMove = true;
                moveTower();
            }
            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
        }
    }
    private void moveTower()
    {
        if (buttonPress <= 0)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if (dir != MoveDir.Up)
                {
                    buttonPress = 3;
                    dir = MoveDir.Up;
                }
                else
                {
                    posMove = false;
                    moving = true;
                    pos += Vector3.forward;
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (dir != MoveDir.Down)
                {
                    buttonPress = 3;
                    dir = MoveDir.Down;
                }
                else
                {
                    posMove = false;
                    moving = true;
                    pos += Vector3.back;
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (dir != MoveDir.Left)
                {
                    buttonPress = 3;
                    dir = MoveDir.Left;
                }
                else
                {
                    posMove = false;
                    moving = true;
                    pos += Vector3.left;
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (dir != MoveDir.Right)
                {
                    buttonPress = 3;
                    dir = MoveDir.Right;
                }
                else
                {
                    posMove = false;
                    moving = true;
                    pos += Vector3.right;
                }
            }
        }
    }
}