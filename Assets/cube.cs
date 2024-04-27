using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class TablePlacer : MonoBehaviour
{
    public GameObject tableModel;
    private Transform headsetTransform;

    void Start()
    {
        OVRCameraRig ovrCameraRig = FindObjectOfType<OVRCameraRig>();
        if (ovrCameraRig != null)
        {
            headsetTransform = ovrCameraRig.centerEyeAnchor;
        }
        else
        {
            Debug.LogError("OVRCameraRig not found in the scene.");
        }
    }

    void Update()
    {
        if (headsetTransform != null)
        {
            // Update the position of the table model to match the position of the headset
            tableModel.transform.position = headsetTransform.position + headsetTransform.forward * 2.0f;
            tableModel.transform.rotation = Quaternion.LookRotation(-headsetTransform.forward, headsetTransform.up);
        }
    }
}


