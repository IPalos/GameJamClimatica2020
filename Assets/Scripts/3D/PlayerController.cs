using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public static PlayerController player;

    private Rigidbody rb;
    public float j_time;

    [Range (.1f, 100f)]
    public float speed;

    // public static Vector3 currentPlanet;

    public GameObject planet;

    public float gravity;
    [SerializeField] private float jumpForce;

    //Estados del personaje
    public static bool isGrounded;
    string readyforconversation;

    public DialogueManager dialogueManager;
    private bool dialogueStarted;


    private Transform readyToBuild;
    public Inventory inventory;

    // Start is called before the first frame update
    void Awake () {
        rb = GetComponent<Rigidbody> ();
        dialogueStarted = false;
    }

    // Update is called once per frame
    void Update () {
        MoveCharacter ();

        if (Input.GetButtonDown ("Fire1")) {
            if (readyforconversation != null) {
                if (!dialogueStarted) {
                    dialogueManager.StartDialogue (readyforconversation);
                    dialogueStarted = true;
                } else {
                    dialogueStarted = dialogueManager.NextDialog ();
                }
            }
            if(readyToBuild!= null){
                Debug.Log("Bob construye!");
                if (readyToBuild.childCount==0){
                    inventory.PlaceBuilding(0,readyToBuild);
                }
                else{
                    inventory.RemoveBuilding(readyToBuild);
                }
            }

        }

    }

    private void MoveCharacter () {
        RaycastHit hit;

        if (Physics.Raycast (transform.position, planet.transform.position - transform.position, out hit)) {
            // Find the line from the gun to the point that was clicked.
            Vector3 incomingVec = hit.point - transform.position;

            // Use the point's normal to calculate the reflection vector.
            Vector3 reflectVec = Vector3.Reflect (incomingVec, hit.normal);

            // Draw lines to show the incoming "beam" and the reflection.
            Debug.DrawLine (transform.position, hit.point, Color.red);
            Debug.DrawRay (hit.point, reflectVec, Color.green);

            transform.up = reflectVec;

            rb.velocity = transform.forward * speed * Input.GetAxis ("Vertical") + transform.right * speed * Input.GetAxis ("Horizontal");
            rb.AddForce (transform.up * -1 * gravity);

        }

        if (Input.GetButton ("Jump") && isGrounded) {
            StartCoroutine (Jump (j_time));

        }

        if (Input.GetButtonDown ("Jump") && isGrounded) {
            StartCoroutine (Jump (j_time));
        }
    }

    IEnumerator Jump (float time) {
        float startTime = Time.time;
        while (Time.time < startTime + time) {
            rb.AddForce (transform.up * jumpForce / time);
            yield return null;
        }
    }

    private void OnTriggerStay (Collider other) {
        if (other.gameObject.tag == "NPC") {
            readyforconversation = other.gameObject.name;
        }
        if (other.gameObject.tag == "slot") {
            readyToBuild = other.transform;
        }
    }

    private void OnTriggerExit (Collider other) {
        readyforconversation = null;
        dialogueManager.ExitDialog ();
        dialogueStarted = false;
    }

    private void OnCollisionExit (Collision other) {
        if (other.gameObject.tag == "planet") {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter (Collision other) {
        if (other.gameObject.tag == "planet") {
            Debug.Log ("Is grounded");
            isGrounded = true;
        }
    }

}