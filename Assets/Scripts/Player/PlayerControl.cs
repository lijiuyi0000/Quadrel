﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameWork;

public class PlayerControl : MonoBehaviour {

	private bool isDead = false;
	private int x = 3,z = 2;
	private GameColor playerPosColor;
	private MapManager mapManager;
	void Start () {
		playerPosColor = ColorManager.Instance ().SelectColor (ColorManager.ScenesType.MONDAY);
		mapManager =  MapManager.Instance();
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			CameraManager.Instance ().startFollow = true;
			SetPlayerPosition ();
		}
		PlayerControll ();
	}

	void PlayerControll(){
		if(Input.GetKeyDown(KeyCode.A)){
			GoLeft ();
		}
		if(Input.GetKeyDown(KeyCode.D)){
			GoRight();
		}
	}

	void GoLeft(){
		if (!isDead) {
			if (x != 0) {
				z++;
			}
			if (z % 2 == 1 && x != 0) {
				x--;
			}
		}
		SetPlayerPosition ();
	}

	void GoRight(){
		if (!isDead) {
			if (x != 4||z % 2 != 1) {
				z++;
			}
			if (z % 2 == 0 && x != 4) {
				x++;
			}
		}
		SetPlayerPosition ();
	}

	void SetPlayerPosition(){
		Transform playerPos =  mapManager.GetMapList()[z] [x].GetComponent<Transform> ();
		MeshRenderer tilePlane = playerPos.Find ("tile_plane").GetComponent<MeshRenderer> ();
		if (z % 2 == 0)
			tilePlane.material.color = playerPosColor.colorOfMeshRenderOne;
		else
			tilePlane.material.color = playerPosColor.colorOfMeshRenderTwo;
		gameObject.transform.position = playerPos.position + new Vector3 (0, 0.254f / 2, 0);
	}
		
}
