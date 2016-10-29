﻿using UnityEngine;
using System.Collections;

public class CurrentCoinsBoard : MonoBehaviour {
	private int[] Coins = new int[2];

	private int[,] oldPos = new int[2,2];
	private int[,] newPos = new int[2,2];

	// Use this for initialization
	void Start() {
		oldPos[0,0] = 0;
		oldPos[0,1] = 0;

		oldPos[1,0] = 0;
		oldPos[1,1] = 1;
		Debug.Log("CCB Start");
		Debug.Log("OldPos1 Values: " + oldPos[0, 0] + " | " + oldPos[0, 1]);
		Debug.Log("OldPos2 Values: " + oldPos[1, 0] + " | " + oldPos[1, 1]);

		setNewPos(oldPos);

		Debug.Log("OldPos1 Values: " + oldPos[0, 0] + " | " + oldPos[0, 1]);
		Debug.Log("OldPos2 Values: " + oldPos[1, 0] + " | " + oldPos[1, 1]);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow))
			MoveRight();

		if (Input.GetKeyDown(KeyCode.LeftArrow))
			MoveLeft();

		if (Input.GetKeyDown(KeyCode.UpArrow))
			MoveRotate();

	public void setCoins(int[] Coins) {
		Debug.Log("Coin Values: " + Coins[0] + " | "+ Coins[1]);
		this.Coins[0] = Coins[0];
		this.Coins[1] = Coins[1];
	}

	public void setNewPos(int[,] Pos) {
		this.newPos[0, 0] = Pos[0, 0];
		this.newPos[0, 1] = Pos[0, 1];
		this.newPos[1, 0] = Pos[1, 0];
		this.newPos[1, 1] = Pos[1, 1];
	}

	public void setOldPos(int[,] Pos) {
		this.oldPos[0, 0] = Pos[0, 0];
		this.oldPos[0, 1] = Pos[0, 1];
		this.oldPos[1, 0] = Pos[1, 0];
		this.oldPos[1, 1] = Pos[1, 1];
	}

	public void UpdateCurrentCoins() {
		Debug.Log("NewPos1 Values: " + newPos[0, 0] + " | " + newPos[0, 1]);
		Debug.Log("NewPos2 Values: " + newPos[1, 0] + " | " + newPos[1, 1]);

		Debug.Log("Update: OldPos1 Values: " + oldPos[0, 0] + " | " + oldPos[0, 1]);
		Debug.Log("Update: OldPos2 Values: " + oldPos[1, 0] + " | " + oldPos[1, 1]);

		GameObject OldCoin0 = GameObject.Find("/Current/Coin" + oldPos[0,0] + oldPos[0,1]);
		GameObject OldCoin1 = GameObject.Find("/Current/Coin" + oldPos[1,0] + oldPos[1,1]);

		GameObject NewCoin0 = GameObject.Find("/Current/Coin" + newPos[0,0] + newPos[0,1]);
		GameObject NewCoin1 = GameObject.Find("/Current/Coin" + newPos[1,0] + newPos[1,1]);

		OldCoin1.GetComponent<Coin>().Value = 0;
		OldCoin0.GetComponent<Coin>().Value = 0;
		Debug.Log("Coin Values: " + Coins[0] + " | " + Coins[1]);
		NewCoin0.GetComponent<Coin>().Value = Coins[0];
		NewCoin1.GetComponent<Coin>().Value = Coins[1];

		setOldPos(newPos);
	}

	public void MoveLeft() {
		newPos[0, 1]--;
		newPos[1, 1]--;
		UpdateCurrentCoins();
	}

	public void MoveRight() {
		newPos[0, 1]++;
		newPos[1, 1]++;
		UpdateCurrentCoins();
	}

	public void MoveRotate() {

	}


}
