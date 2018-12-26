using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlightManager : MonoBehaviour
{
    public GameObject PointOfOrigin;
    public GameObject Direction;
    public GameObject PlaneGameObject;
    public Slider SliderHere;
    private XWingMovement movement;
    private bool sliderActive = false;
    public GameObject Splosion;

    // Use this for initialization
    void Start()
    {
     //   Direction = PointOfOrigin.transform.Find("SelectDirection").gameObject;
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
        //movement.LastPosition = PlaneGameObject.transform.position;
        //movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        //movement.BankSegnorLoop(speed, false);
       // string res = "" + 3 + speed;
       // GameController.inst.LocalPlayer.Move = int.Parse(res);
    }


    public void TurnPlaneLeft(float speed)
    {
        //movement.LastPosition = PlaneGameObject.transform.position;
        //movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        //movement.Turn(speed, false);
        string res = "" + 1 + speed;
        GameController.inst.LocalPlayer.Move = int.Parse(res);
    }

    public void TurnPlaneRight(float speed)
    {
        //movement.LastPosition = PlaneGameObject.transform.position;
        //movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        //movement.Turn(speed, true);
        string res = "" + 5 + speed;
        GameController.inst.LocalPlayer.Move = int.Parse(res);

    }

    public void BankPlaneLeft(float speed)
    {
        //movement.LastPosition = PlaneGameObject.transform.position;
        //movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        //movement.Bank(speed, false);
        string res = "" + 2 + speed;
        GameController.inst.LocalPlayer.Move = int.Parse(res);
    }

    public void BankPlaneRight(float speed)
    {
        //movement.LastPosition = PlaneGameObject.transform.position;
        //movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        //movement.Bank(speed, true);
        string res = "" + 4 + speed;
        GameController.inst.LocalPlayer.Move = int.Parse(res);

    }

    public void FlyPlaneStraight(float speed)
    {
        /*
        movement.LastPosition = PlaneGameObject.transform.position;
        movement.LastRotation = PlaneGameObject.transform.eulerAngles;
        movement.Straight(speed);
    */
        string res = "" + 3 + speed;
        GameController.inst.LocalPlayer.Move = int.Parse(res);
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
