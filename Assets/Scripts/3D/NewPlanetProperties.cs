using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlanetProperties : MonoBehaviour{

    //Kr*r=m
    //F = km/r

    [Range(1f,100f)]
    public float mass;
    private Transform orbit;

    [Range(1f,100f)]
    public static float konstant;



    // Start is called before the first frame update
    void Awake(){
        konstant = 4f;
        // orbit = transform.GetChild(0);
        // orbit.localScale = Vector3.one*Mathf.Sqrt(mass)*3/2;
        transform.localScale=Vector3.one*(Mathf.Sqrt(mass)*10)/2;
    }

    // private void OnCollisionEnter(Collision other) {
    //     CubeController.isGrounded = true;
    //     // CubeController.player
    //     CubeController.currentPlanet = transform.position;
    // }

    // private void OnCollisionExit(Collision other) {
    //     CubeController.isGrounded =false;
    // }

}
