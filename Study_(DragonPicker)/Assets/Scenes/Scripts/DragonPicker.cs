using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DragonPicker : MonoBehaviour
{
    public GameObject energyShieldPrefab;
    public int numEnergyShield = 3;
    public float energyShieldBottomY = -6.0f;
    public float energyShieldRadius = 1.5f;
    public List<GameObject> shieldList;

    // Start is called before the first frame update
    void Start()
    {
        for (int i =1; i <= numEnergyShield; i++)
        {
            GameObject tShieldGo = Instantiate<GameObject>(energyShieldPrefab);
            tShieldGo.transform.position = new Vector3(0, energyShieldBottomY, 0);
            tShieldGo.transform.localScale = new Vector3(1 * i, 1 * i, 1 * i);
            shieldList.Add(tShieldGo);
        }
    }

    // Update is called once per frame 
    void Update()
    {
        
    }

    public void DragonEggDestroyd()
    {
        GameObject[] tDragonEggArray = GameObject.FindGameObjectsWithTag("Dragon_Egg");
        foreach (GameObject tGO in tDragonEggArray)
        {
            Destroy(tGO);
        }
        int shieldIndex = shieldList.Count - 1;
        GameObject tShieldGo = shieldList[shieldIndex];
        shieldList.RemoveAt(shieldIndex);
        Destroy(tShieldGo);

        if (shieldList.Count == 0)
        {
            SceneManager.LoadScene("_0Scene");
        }
    }
}
