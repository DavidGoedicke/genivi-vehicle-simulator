﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalCameraManager : MonoBehaviour {
    private Transform DriverCam;
    // Use this for initialization
    void Start()
    {
        DriverCam = RetrunActiveCamera();
    }

    // Update is called once per frame
    void Update() {
        if (DriverCam !=null && DriverCam.gameObject.activeInHierarchy) { 
      //  transform.position = DriverCam.position;
       // transform.rotation = DriverCam.rotation;
        }else
        {
            DriverCam = RetrunActiveCamera();
        }

        //Debug.LogError("Am I still ACtive");
    }

    Transform RetrunActiveCamera()
    {
        foreach (DriverCamera dc in GameObject.FindObjectsOfType<DriverCamera>())
        {
            if (dc.gameObject.activeInHierarchy)
            {
               return dc.transform;
            }
        }
        return null;
    }
    public void updateMask( int mask)
    {
        foreach(Camera ca in GetComponentsInChildren<Camera>())
          ca.cullingMask = mask;

    }
    public void DestroThis()
    {
        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            t.gameObject.SetActive(false);
            Destroy(t.gameObject, 0.5f);
        }
        transform.gameObject.SetActive(false);
        Destroy(this);
    }
   
}
