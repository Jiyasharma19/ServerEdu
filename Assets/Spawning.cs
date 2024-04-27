using Oculus.Platform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawning : MonoBehaviour
{
    public GameObject serverPrefab;
    public GameObject ServerPartPrefab;


    public Transform table;
    public Transform serverPart;


    private bool isFirstClick = true;
    private Vector3 serverSize;


    void Start()
    {
        // Calculate the size of the server model
        serverSize = new Vector3(0.6f, 0.4f, 0.08f);
    }

    public void GetTable(Transform table)
    {
        this.table = table;
        DebugHandler.Instance.Log("Got the table");
        Debug.Log("Got the table");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)||OVRInput.GetDown(OVRInput.Button.Two))
        {
            if (isFirstClick)
            {
                ServerSpawner(table);
            }
            else
            {
                ServerPartsSpawner();


            }
        }

    }

    public void ServerSpawner(Transform table)
    {
       
        Vector3 tableCenter = table.position;
        DebugHandler.Instance.Log("Position of table is " + table.position);
        DebugHandler.Instance.Log("Position of table is " + table.parent.position);
        DebugHandler.Instance.Log("Position of table is " + table.parent.parent.position);
        
        DebugHandler.Instance.Log("Table center value is " + tableCenter);
        Debug.Log("Table Center value is" + tableCenter);

        Vector3 tablePosition= new Vector3(tableCenter.x + serverPrefab.transform.localScale.x, tableCenter.y + table.localScale.y/2  + serverPrefab.transform.localScale.y / 2,tableCenter.z+serverPrefab.transform.localScale.z);
        


        GameObject obj = Instantiate(serverPrefab, tablePosition, Quaternion.identity);

        Debug.Log("server placed " + obj.transform.position);


        isFirstClick = false;
    }

    public void ServerPartsSpawner()
    {
        float spaceX = 0.1f; // Offset between each part in the Y-axis direction
        float spaceZ = -0.15f;
        // Offset between each part in the X-axis direction

        Vector3 tableRight = table.position;
        Vector3 tableCenter = table.position;
        Vector3 tableLeft = table.position;

        DebugHandler.Instance.Log("ServerSpawned");


        for (int i = 1; i <= 3; i++)
        {


            tableRight.x = tableCenter.x + serverPrefab.transform.localScale.x / 2 + spaceX + ServerPartPrefab.transform.localScale.x / 2;
            tableRight.y = tableCenter.y + table.localScale.y / 2 + ServerPartPrefab.transform.localScale.y/ 2;
            tableRight.z = tableCenter.z + ServerPartPrefab.transform.localScale.z/ 2 + spaceZ * i;
            GameObject Part = Instantiate(ServerPartPrefab, tableRight, Quaternion.identity);
            Debug.Log(Part.transform.position);
            
        }

        for (int i = 1; i < 3; i++)
        {
            tableLeft.x = tableCenter.x - serverPrefab.transform.localScale.x / 2 - spaceX - ServerPartPrefab.transform.localScale.x / 2;
            tableLeft.y = tableCenter.y + table.localScale.y/ 2 + ServerPartPrefab.transform.localScale.y/ 2;
            tableLeft.z = tableCenter.z + ServerPartPrefab.transform.localScale.z / 2 + spaceZ * i;
            GameObject Part1= Instantiate(ServerPartPrefab, tableLeft, Quaternion.identity);
            Debug.Log(Part1.transform.position);

        }


        isFirstClick = true;

    }
        
    
}
