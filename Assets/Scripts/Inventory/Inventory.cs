using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject[] inventory;

    public void PlaceBuilding (int index, Transform slot) {
        Building building=inventory[index].GetComponent<Building>();
        if (bigBrain.energy >= building.energy_cost) {
            Instantiate (inventory[index], slot.position,slot.rotation, slot);
            bigBrain.energy_ps += building.energy_ps;
            bigBrain.pollution_ps += building.pollution_ps;
            bigBrain.energy -= building.energy_cost;
        }

    }

    public void RemoveBuilding (Transform slot) {
        Building building = slot.GetChild(0).GetComponent<Building>();
        if (bigBrain.energy >= building.energy_cost) {
            bigBrain.energy_ps -= building.energy_ps;
            bigBrain.pollution_ps -= building.pollution_ps;
            bigBrain.energy -=building.energy_cost;
            Destroy(building.gameObject);
        }

    }

}