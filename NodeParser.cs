using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

//Import the Character class
using Character;
using EventHandler;



/* Created 3/20/17 by Katie R., much of NodeParser written
 * Edited 3/22/17 by Katie R., changes to parameters in Character
 * Edited 3/24/17 by Katie R., worked with update method some more, removed charCode and replaced with variable npcDisplay accessible by entire class
 * 
 * */

public class NodeParser : MonoBehaviour {

    ArrayList fullScene = new ArrayList();
    Character npcDisplay;
    int lineNum = 0;
    
       
    // Use this for initialization
    void Start () {
        //Gets the current scene to which the GameObject applies
        Scene currentScene = SceneManager.GetActiveScene();
        //Gets the name/extension of the Scene object
        string sceneExtension = currentScene.name.Split('_')[1];
        //File path for the text dialogue
        string filePath = "Assets/Dialogue/Dialogue_" + sceneExtension + ".txt";

        //Stream reader to read from the text input file
        FileStream textLocation = new FileStream(filePath, FileMode.Open);
        StreamReader lineByLine = new StreamReader(textLocation);
                
        //Reads the file and stores all the dialogue/fields
        while (lineByLine.Peek() >= 0)
        {
            fullScene.Add(lineByLine.ReadLine());
        }
        
        lineByLine.Close();
        
    }


	
	// Update is called once per frame
    // Check if player has left-clicked
	void Update () {
        
         if click, {
            npcDisplay.Clear();
            lineNum += 1;
         }
        if (lineNum < fullScene.Count) {
            PrintWordsToScreen(lineNum);
            if (npcDisplay.GetName() == "PlayerPrompt") {
                //switch case with choices a,b,c, etc.
                string optionLetter = //event handler to get what letter they're pressing;
                switch (optionLetter) {
                    case "a":
                    //transition based on a
                    
                    case "b":
                    //transition
                    case "c":
                    //transition
                    default:
                    //do nothing? what default? loop back until it's picked
                }

            }
        }
          
          





    }

    // Method to display dialogue/prompts in the text box on-screen
    public void PrintWordsToScreen(int lineNumber) {
        //Gets the current line
        string currentLine = (string)fullScene[lineNumber];
        //reads from the fields
        string[] fields = currentLine.Split('|');
        
        //Look through file for character name/expression - (name, expression, side of the screen)
        npcDisplay = new Character(fields[0], fields[1], fields[2]);
        npcDisplay.Display();
        //text box - put dialogue here ; Katie R. will figure this part out 
             
    }

}
