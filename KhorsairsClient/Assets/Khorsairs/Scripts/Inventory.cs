using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public GameObject Aim;
	// Use this for initialization
	void Start ()
	{
	    Aim = transform.Find("Aim").gameObject;
	}

    public void ToggleAim()
    {
        if (Aim.activeSelf)
        {
            Aim.SetActive(false);
        }
        else
        {
             Aim.SetActive(true);
        }
    }

    public void Activate()
    {
            Aim.SetActive(true);

    }

    public void Deactivate()
    {
        Aim.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
	
	}
}
