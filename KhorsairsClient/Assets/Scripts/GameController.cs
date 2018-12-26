using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController inst;
    public string WEB_URL = "";
    public PlayerInfo LocalPlayer = new PlayerInfo();
    private void Start()
    {
        //   StartCoroutine(RestfulClientScr.Inst.Post(WEB_URL, new PostObject() { currentturn = 1}));
    }

    public void PostMove()
    {
        
            StartCoroutine(RestfulClientScr.Inst.Post(WEB_URL, LocalPlayer));
            LocalPlayer.Move = 999;
       


    }

    public void PutMove()
    {
        if (LocalPlayer.Move != 999)
        {
            StartCoroutine(RestfulClientScr.Inst.Put(WEB_URL + "/" + GameController.inst.LocalPlayer.Name, GameController.inst.LocalPlayer));
            LocalPlayer.Move = 999;
        }
    }


    private void Awake()
    {
        inst = this;
    }

    private void Update()
    {

    }

}
