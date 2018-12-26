using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo {
    public string Name = "place Holden";
    public int Team = 999;
    public int Move = 999;
    public int Turn = 0;

    public override string ToString()
    {
        return Name + ": \nTeam: " + Team + "\nMove: " + Move;
    }

}
