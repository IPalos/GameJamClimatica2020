using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField] public GameObject dialogueBox;
    private DialogueManager dialogueManager;

    public Slider energySlider;
    public Slider pollutionSlider;





    // Start is called before the first frame update
    void Start () {
        dialogueBox.SetActive (false);
        dialogueManager = dialogueBox.GetComponent<DialogueManager> ();
        energySlider.minValue = bigBrain.energyMinValue;
        energySlider.maxValue = bigBrain.energyMaxValue;
        pollutionSlider.minValue = bigBrain.pollutionMinValue;
        pollutionSlider.maxValue = bigBrain.pollutionMaxValue;
    }

    private void OnGUI() {
        energySlider.value = bigBrain.energy;
        pollutionSlider.value = bigBrain.pollution;
    }

    public void OpenTextBox(){
        dialogueBox.SetActive (true);
    }

        public void CloseTextBox(){
        dialogueBox.SetActive (false);
    }

}