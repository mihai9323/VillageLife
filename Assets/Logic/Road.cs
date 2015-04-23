﻿using UnityEngine;
using System.Collections;

public class Road : MonoBehaviour {
	public Transform RoadWorldSpace;

	public void OnClick(){
		if (HubManager.interactable) {
			if (!CharacterManager.partyEmpty) {
				CharacterManager.ChangeAllActiveStateTo(Character.FightState.MovingToBattle);
				CharacterManager.MoveAllActiveHereAndChangeState (RoadWorldSpace.position,Character.FightState.Waiting,
				                                                  delegate() {
																	Debug.Log("All characters at destination callback");
																	GameData.LoadScene(GameScenes.Fight);
				                                                 });
				HubManager.HideAll ();
				HubManager.interactable = false;

			} else
				Debug.Log ("Party empty");
		}
	}

}