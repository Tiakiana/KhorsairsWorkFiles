using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player  {
    public int id;
    public string name;
    public float score;


    public override string ToString()
    {
        return "" + id + "\n " + name + ": " + score;

    }
}
