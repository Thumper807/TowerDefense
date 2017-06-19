using UnityEngine;
using System.Collections;

public class BuildingManager : MonoBehaviour {

    public GameObject SelectedTower;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SelectedTowerType(GameObject prefab)
    {
        SelectedTower = prefab;
    }
}
