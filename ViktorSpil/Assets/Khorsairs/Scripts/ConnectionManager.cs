using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ConnectionManager : MonoBehaviour
{
    public string WEB_URL;
    public GameObject SpawnedPlayers;

    public GameObject PlanePrefab;
    public GameObject SpawnPointsTeam1;
    public GameObject SpawnPointsTeam2;
    int spawnnumberteam1 = 0;
    int spawnnumberteam2 = 0;
    public static ConnectionManager inst;
    
    // Use this for initialization
    private void Awake()
    {
        inst = this;
    }
    void Start()
    {

        //  StartCoroutine(RestfulClientScr.Inst.Post(WEB_URL, new PostObject { currentturn = 34 }));
        StartCoroutine("CheckForMoves");

    }


    IEnumerator CheckForMoves()
    {
        while (true)
        {
            StartCoroutine(RestfulClientScr.Inst.Get(WEB_URL));
            if (FlightManager.inst.GameStarted == false)
            {
                CheckAndSpawnPlayer();
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void CheckAndSpawnPlayer()
    {
        foreach (PlayerInfo player in FlightManager.inst.playerList)
        {
            if (SpawnedPlayers.transform.Find(player.name) == null)
            {
                GameObject play = Instantiate(PlanePrefab, SpawnedPlayers.transform) as GameObject;
                play.name = player.name;
                if (player.team == 1)
                {
                    play.transform.position = SpawnPointsTeam1.transform.GetChild(spawnnumberteam1).transform.position;
                    play.transform.rotation = SpawnPointsTeam1.transform.GetChild(spawnnumberteam1).transform.rotation;
                    spawnnumberteam1++;
                }
                else
                {
                    play.transform.position = SpawnPointsTeam2.transform.GetChild(spawnnumberteam2).transform.position;
                    play.transform.rotation = SpawnPointsTeam2.transform.GetChild(spawnnumberteam2).transform.rotation;
                    spawnnumberteam2++;
                }
            }
        }
    }

    public void PostNewTurn(int turnnumber)
    {
        StartCoroutine(RestfulClientScr.Inst.Post(WEB_URL, new PostObject() { currentturn = turnnumber }));
    }

    public void GetPlayerActions()
    {
        StartCoroutine(RestfulClientScr.Inst.Get(WEB_URL));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
