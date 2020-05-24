using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    [SerializeField] public Dialogue[] dialogues;
    public TextMeshProUGUI dialogText;

    private int currentNPC;
    private int currentDialog;

    public UIManager uIManager;

    private void Start () {
        dialogText = transform.GetChild (0).GetComponent<TextMeshProUGUI> ();

    }

    public void StartDialogue (string NPCName) {
        uIManager.OpenTextBox ();
        for (int i = 0; i < dialogues.Length; i++) {
            if (dialogues[i].NPCName == NPCName) {
                currentNPC = i;
                currentDialog = 0;
            }
        }
    }

    public bool NextDialog () {
        currentDialog += 1;
        Debug.Log(currentDialog);
        if (currentDialog == dialogues[currentNPC].NPCDialogues.Length) {
            uIManager.CloseTextBox ();
            return false;
        } else {
            return true;
        }
    }

    public void ExitDialog () {
        uIManager.CloseTextBox ();
        currentNPC = 0;
        currentDialog = 0;
    }

    private void OnGUI() {
        dialogText.text = dialogues[currentNPC].NPCDialogues[currentDialog];
    }

}