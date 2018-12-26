using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class FlightManager : MonoBehaviour
{
    public GameObject PointOfOrigin;
    public GameObject Direction;
    public GameObject PlaneGameObject;
    public Slider SliderHere;
    private XWingMovement movement;
    private bool sliderActive = false;
    public GameObject Splosion;
    int currentTurnNumber = 0;
    public bool Ready = false;
    public bool GameStarted = false;
    public List<string> DeadPlayers = new List<string>();


    public List<PlayerInfo> playerList = new List<PlayerInfo>();
    public static FlightManager inst;

    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        Direction = PointOfOrigin.transform.Find("SelectDirection").gameObject;
        StartCoroutine("CheckIfPlayersReady");
    }

    public void RemovePlayer(string name) {
        try
        {
        playerList.Remove(playerList.Find(x => x.name == name));

        }
        catch (System.Exception)
        {
            Debug.Log("Couldn't remove " + name);
        }
    }

    //Telemarketing svendborg
    //

    IEnumerator CheckIfPlayersReady()
    {
        Debug.Log("starting checkifplayerready");
        bool res = false;
        while (res == false)
        {

            if (playerList.Count > 0)
            {
                res = true;
                foreach (PlayerInfo item in playerList)
                {
                    if (item.turn == currentTurnNumber)
                    {

                        if (item.move == 0 | item.move == 999)
                        {
                            res = false;
                        }
                    }
                    else
                    {
                        res = false;
                    }
                    Ready = res;
                }
            }
            if (GameStarted && Ready)
            {

               StartCoroutine("TakeTurn");
            }
            else
            {
                res = false;
            }
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Exiting check if player ready");
    }

    public void StartGame() {
        GameStarted = true;

    }
    public IEnumerator TakeTurn()
    {
        Ready = false;
        List<PlayerInfo> currentTurnPlayerList = new List<PlayerInfo>();

        for (int i = 0; i < playerList.Count; i++)
        {
            PlayerInfo pl = new PlayerInfo();
            pl.move = playerList[i].move;
            playerList[i].move = 999;
            pl.name = playerList[i].name;
            pl.team = playerList[i].team;
            pl.turn = playerList[i].turn;
            currentTurnPlayerList.Add(pl);
        }

        List<PlayerInfo> randomPlayerlist = new List<PlayerInfo>();
        for (int i = currentTurnPlayerList.Count-1; i >= 0; i--)
        {
            int rnd = Random.Range(0,currentTurnPlayerList.Count);
            randomPlayerlist.Add(currentTurnPlayerList[rnd]);
            currentTurnPlayerList.RemoveAt(rnd);
        }
        // indsæt den randomiserede liste ovenfor i denne foreach løkke.
        // ----------------------- Her er der ikke testet endnu. ------------------------------------------------
        foreach (PlayerInfo item in randomPlayerlist)
        {
            
            int maneuver = int.Parse(item.move.ToString()[0].ToString());
            int speed = int.Parse(item.move.ToString()[1].ToString());
            //  Debug.Log(item.name + " makes maneuver "+ maneuver + " at speed " + speed);
            GameObject plane = null;
            try
            {
                //plane = ConnectionManager.inst.SpawnedPlayers.transform.Find(item.name).gameObject;
                plane = GameObject.Find(item.name);
            }
            catch (System.Exception)
            {

            }
            if (plane == null)
            {
                Debug.Log("Can't find plane for some reason...");
            }
            SetupManeuver(plane);
            switch (maneuver)
            {
                case 1:
                    TurnPlaneLeft((float)speed);
                    yield return new WaitForSeconds(2);
                    break;

                case 2:
                    BankPlaneLeft((float)speed);
                    yield return new WaitForSeconds(2);
                    break;

                case 3:
                    FlyPlaneStraight((float)speed);
                    yield return new WaitForSeconds(2);
                    break;

                case 4:
                    BankPlaneRight((float)speed);
                    yield return new WaitForSeconds(2);
                    break;

                case 5:
                    TurnPlaneRight((float)speed);
                    yield return new WaitForSeconds(2);
                    break;

                default:
                    Debug.Log("Not valid action");
                    break;
            }
        }

        //Skyd på hinanden i omvendt rækkefølge.
        for (int i = randomPlayerlist.Count-1; i>= 0; i--)
        {
            CallPlaneAndChildren();
            PlaneGameObject.GetComponent<Inventory>().ToggleAim();
            yield return new WaitForSeconds(0.5f);
            PlaneGameObject = GameObject.Find(randomPlayerlist[i].name);
            yield return new WaitForSeconds(0.5f);
            PlaneGameObject.GetComponent<Inventory>().ToggleAim();

        }


        currentTurnNumber++;
        ConnectionManager.inst.PostNewTurn(currentTurnNumber);
        StartCoroutine("CheckIfPlayersReady");
    }

    public void SetupManeuver(GameObject plane) {
        movement = plane.GetComponent<XWingMovement>();
        PlaneGameObject = plane;
    }



    public void StartSetDirection(GameObject plane)
    {
        if (PlaneGameObject != null)
        {
            PlaneGameObject.GetComponent<Inventory>().Deactivate();
        }

        PlaneGameObject = plane;
        Direction.gameObject.SetActive(true);
        movement = PlaneGameObject.GetComponent<XWingMovement>();
        PointOfOrigin.transform.position = Input.mousePosition;
        SliderHere.GetComponent<SliderScr>().SetPlane(plane);
        PlaneGameObject.GetComponent<Inventory>().Activate();
    }

    public void RevertLastMove()
    {
        if (PlaneGameObject != null && movement != null)
        {
            PlaneGameObject.transform.position = movement.LastPosition;
            PlaneGameObject.transform.eulerAngles = movement.LastRotation;
        }
    }

    public void ToggleSlider()
    {
        if (sliderActive)
        {
            SliderHere.gameObject.SetActive(false);
            sliderActive = false;
        }
        else
        {
            SliderHere.gameObject.SetActive(true);
            sliderActive = true;

        }

    }



    public void DoABarrelRoll(bool right)
    {
        movement.BarrelRoll(right);
    }

    public void ToggleAim()
    {
        PlaneGameObject.GetComponent<Inventory>().ToggleAim();
    }

    public void TurnPlaneRightTallonRoll(float speed)
    {
        movement.TurnTallonRoll(speed, true);
    }

    public void TurnPlaneLeftTallonRoll(float speed)
    {
        movement.LastPosition = PlaneGameObject.transform.position;
        movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        movement.TurnTallonRoll(speed, false);
    }

    public void BankPlaneRightSegnorLoop(float speed)
    {

        movement.LastPosition = PlaneGameObject.transform.position;
        movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        movement.BankSegnorLoop(speed, true);
    }

    public void BankPlaneLeftSegnorLoop(float speed)
    {
        movement.LastPosition = PlaneGameObject.transform.position;
        movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        movement.BankSegnorLoop(speed, false);
    }


    public void TurnPlaneLeft(float speed)
    {
        movement.LastPosition = PlaneGameObject.transform.position;
        movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        movement.Turn(speed, false);
    }

    public void TurnPlaneRight(float speed)
    {
        movement.LastPosition = PlaneGameObject.transform.position;
        movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        movement.Turn(speed, true);

    }

    public void BankPlaneLeft(float speed)
    {
        movement.LastPosition = PlaneGameObject.transform.position;
        movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        movement.Bank(speed, false);
    }

    public void BankPlaneRight(float speed)
    {
        movement.LastPosition = PlaneGameObject.transform.position;
        movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        movement.Bank(speed, true);


    }

    public void FlyPlaneStraight(float speed)
    {
        movement.LastPosition = PlaneGameObject.transform.position;
        movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        movement.Straight(speed);
    }

    public void FlyPlaneStraightKoiogran(float speed)
    {
        movement.LastPosition = PlaneGameObject.transform.position;
        movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        movement.StraightKoiogran(speed);
    }

    public void CallPlaneAndChildren()
    {
        PlaneGameObject.BroadcastMessage("TestRangeNear");
        //   PlaneGameObject.BroadcastMessage("FadeInOut");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("r"))
        {
            ToggleSlider();
        }
        if (Input.GetKeyUp("z"))
        {
            RevertLastMove();
        }
        if (Input.GetKeyUp("q"))
        {
            if (PlaneGameObject != null)
            {
                Splosion.transform.position = PlaneGameObject.transform.position;
                Splosion.GetComponent<AnimationScript>().StartAnimBoom();
                Destroy(PlaneGameObject);
                PlaneGameObject = null;

            }
        }
    }
}
