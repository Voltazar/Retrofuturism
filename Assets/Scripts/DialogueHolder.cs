using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dMAn;
    public string[] dLines;

    // Use this for initialization
    void Start () {
        dMAn = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player"){
            if(Input.GetKeyUp(KeyCode.Space)){
                //dMAn.ShowBox(dialogue);
                if(!dMAn.dialogActive){
                    dMAn.dLines = dLines;
                    dMAn.currentLine = 0;
                    dMAn.ShowDialogue();
                }
            }
        }
    }
}
