using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPManager : MonoBehaviour {
    void FixedUpdate () {
        bigBrain.energy+=(bigBrain.energy_ps/60.0f);
        bigBrain.pollution+=(bigBrain.pollution_ps/60.0f);
    }
}