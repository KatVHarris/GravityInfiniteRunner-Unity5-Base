using UnityEngine;
using System.Collections;
// Use this for initialization
public class GUITest : MonoBehaviour {
    
    public string scoreGUI; 

    void OnGUI () {
        // Make a background box
        GUI.Box(new Rect(10,10,200,150), "Loader Menu");
    
        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if(GUI.Button(new Rect(20,70,80,20), "Level 1")) {
            Application.LoadLevel(1);
        }
    
        //Need to make a label referencing scoreGUI 
        //Then I need to go to GameController and have it reference scoreGUi.TEXT...
        //Or create a method that changes scoreGUI and then the ONGUI should update accordingly. 

        // Make the second button.
        if(GUI.Button(new Rect(20,100,80,20), "Level 2")) {
            Application.LoadLevel(2);
        }
    }
}

