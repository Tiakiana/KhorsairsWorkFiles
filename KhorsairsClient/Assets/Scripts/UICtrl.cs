using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICtrl : MonoBehaviour {
    int selectedTeam = 1;
    public InputField nameInput;
    public ToggleGroup ManeuverToggleGroup;
    public ToggleGroup SpeedToggleGroup;
    public Text txt;
    public Button SendRequest;
	void Start () {
        StartCoroutine("UpdateTxt");	
	}

    IEnumerator UpdateTxt() {
        while (true)
        {
            txt.text = GameController.inst.LocalPlayer.ToString();
            if (GameController.inst.LocalPlayer.Move != 999)
            {
                SendRequest.interactable = true;
            }
            else
            {
                SendRequest.interactable = false;
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void SelectTeam(int i) {
        selectedTeam = i;
    }

    public void MakePlayerInfo() {
        PlayerInfo pl = new PlayerInfo();
        pl.Name = nameInput.text;
        pl.Team = selectedTeam;
        Debug.Log("Player: " + pl.Name + " At team: " + pl.Team);
        GameController.inst.LocalPlayer = pl;
        GameController.inst.PostMove();
    }
    
	
}
