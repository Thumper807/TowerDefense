using UnityEngine;
using System.Collections;

public class TowerSpot : MonoBehaviour {

    void OnMouseUp()
    {
        BuildingManager bm = GameObject.FindObjectOfType<BuildingManager>();

        if (bm.SelectedTower != null)
        {
            ScoreManager sm = GameObject.FindObjectOfType<ScoreManager>();
            if (sm.money < bm.SelectedTower.GetComponent<tower>().cost)
            {
                Debug.Log("Not Enough Money.");
                return;
            }

            sm.money -= bm.SelectedTower.GetComponent<tower>().cost;

            Instantiate(bm.SelectedTower, this.transform.parent.position, this.transform.parent.rotation);
            Destroy(this.transform.parent.gameObject);
        }
    }
}
