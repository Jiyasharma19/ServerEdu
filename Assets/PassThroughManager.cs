using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PassThroughManager : MonoBehaviour
{
    //public OVRPassthroughLayer passthrough;

    public OVRManager manager;
    public OVRSceneManager sceneManager;
    public Transform parent;
    public bool gameobjectFound=false;
    public Spawning spawning;

    private MeshRenderer[] renderers;

    private bool isPassthrough = true;

    public OVRInput.Button button;
    public OVRInput.Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        sceneManager.InitialAnchorParent = parent;

        sceneManager.SceneModelLoadedSuccessfully += GetRenderers;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            TogglePassthrough();
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            TogglePassthrough();

        }

        
    }

    public void GetRenderers()
    {
        gameobjectFound = true;

        renderers = parent.GetComponentsInChildren<MeshRenderer>();
        
    }

    public void TogglePassthrough()
    {
        if(!isPassthrough)
        {
            EnablePassthrough();
        }

        else
        {
            DisablePassthrough();
        }
    }

    public void EnablePassthrough()
    {
        manager.isInsightPassthroughEnabled = true;

        if (renderers.Length > 0)
        {
            foreach (var renderer in renderers)
            {
                if (renderer.gameObject.CompareTag("CompareTag"))
                {
                    renderer.enabled = true;
                    spawning.GetTable(renderer.transform);

                }
                else
                {
                    renderer.enabled = false;
                }
            }
            
        }


        isPassthrough = true;
    }
     
    public void DisablePassthrough()
    {
        manager.isInsightPassthroughEnabled = false;

        if(renderers.Length > 0 )
        {
            foreach (var renderer in renderers)
            {
                renderer.enabled= true;
            }
        }
        
        isPassthrough= false;
    }
}
