using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pen : MonoBehaviour
{
    public bool inHandOnStart;
    private Rigidbody penRigidbody;

    [SerializeField]
    private XRController RighDraw;
    [SerializeField]
    private XRController LeftDraw;
    [SerializeField]
    private XRController RightGrab;
    [SerializeField]
    private XRController LeftGrab;


    
    void Start()
    {
        penRigidbody = GetComponentInChildren<Rigidbody>();

        if (inHandOnStart && penRigidbody)
        {
            penRigidbody.isKinematic = true;
        }
    }
    
    public void SwitchDrawHand()
    {

        RighDraw.gameObject.SetActive(true);

    }

    public void SwitchGrabHand()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }


}
