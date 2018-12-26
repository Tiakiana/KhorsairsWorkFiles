using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PlayerInfo {
    public string name = "place Holden";
    public int team = 999;
    public int move = 999;
    public int turn = 0;

    public override string ToString()
    {
        return name + ": \nTeam: " + team + "\nMove: " + move;
    }

}
