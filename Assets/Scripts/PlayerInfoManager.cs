using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    public Canvas inGameInfoCanvas;
    private List<GameObject> shipHealthList = new List<GameObject>();
    public GameObject shipHealthPrefab;

    private float defaultX = -720;
    private float defaultY = 380;
    private float gap = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void updateHealth(int health)
    {  
        if (shipHealthList.Count < health)
        {
            int oldShipHealthCount = shipHealthList.Count;
            for (int i = 0; i < health; i++)
            {
                if (i < oldShipHealthCount)
                {
                    shipHealthList[i].SetActive(true);
                }
                else
                {
                    GameObject newShipHealth = Instantiate(shipHealthPrefab, inGameInfoCanvas.transform);
                    newShipHealth.transform.localPosition = new Vector3(defaultX + (float)(oldShipHealthCount + i) * gap, defaultY, 0);
                    //Debug.Log("New Ship - x: " + (defaultX + (oldShipHealthCount + i) * gap) + " - y: " + defaultY);
                    shipHealthList.Add(newShipHealth);
                }
            }
        }
        else
        {
            for (int i = 0; i < shipHealthList.Count; i++)
                if (i < health)
                    shipHealthList[i].SetActive(true);
                else
                    shipHealthList[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
