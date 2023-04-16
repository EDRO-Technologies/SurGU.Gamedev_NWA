using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Connection;

public class NetworkSetup : NetworkBehaviour
{
    [SerializeField] private Transform body;

    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {
            Camera cam = Camera.main;
            cam.transform.position = new Vector3(body.position.x, body.position.y + 0.5f, body.position.z - 4.15f);
            cam.transform.SetParent(body);

            UIControllers uiControls = GameObject.Find("ControllerCanvas").GetComponent<UIControllers>();
            uiControls.playerController = GetComponent<PIDController>();        
        }
        else 
        {
            GetComponent<InputManager>().enabled = false;
        }
    }
}


