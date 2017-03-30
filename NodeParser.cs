using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


/* Created 3/20/17 by Katie R., much of NodeParser written
 * Edited 3/22/17 by Katie R., changes to parameters in Character
 * Edited 3/24/17 by Katie R., worked with update method some more, removed charCode and replaced with variable npcDisplay accessible by entire class
 * Edited 3/25/17 by Katie R., added comments for the transition methods
 * Edited 3/29/17 by Katie R., changed how we choose options to go into the next Scene
 * */

public class NodeParser : MonoBehaviour {

    ArrayList fullScene = new ArrayList();
    Character npcDisplay;
    int lineNum = 0;
    string currentText;
    
       
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
        
        if (Input.GetMouseButtonDown(0)) {
            npcDisplay.Clear();
            currentText.Remove(0, currentText.Length); //remove all the text
            lineNum += 1;
         }
        if (lineNum < fullScene.Count) {
            PrintWordsToScreen(lineNum);

            //Gets the current line
            string currentLine = (string)fullScene[lineNum];
            if (currentLine.Split('|')[0] == "PlayerPrompt") {
                //reads from the fields
                string[] options = currentLine.Split('|')[4].Split(',');
                //potential buttons to press
                string[] characters = new string[5] { "a", "b", "c", "d", "e" };

                //*****FIX THIS, USE EVENT HANDLER TO GET THE LETTER THAT HAS BEEN PRESSED
                string optionLetter = "a";//event handler to get what letter they're pressing;

                //Gets the number of option
                int optionNumber = Array.IndexOf(characters, optionLetter);
                //Get the corresponding scene
                string nextScene = "Scene_" + options[optionNumber];
                Scene next = SceneManager.GetSceneByName(nextScene);
                // transition(next);
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
        Character npcDisplay = new Character(fields[0], fields[1], fields[2]);
        npcDisplay.Display();
        //put on text box 
        GUI.Label(new Rect(100, 100, 50, 50), fields[3]);
        if (npcDisplay.GetName() == "PlayerPrompt") {
            //Array of options
            string[] options = fields[3].Split('*');
            //Array of scene extensions (to know which scene we transition to)
            string[] sceneExtensions = fields[4].Split(',');
            //number of options
            int countOpt = options.Length;
            
            //for each of the options
            for (int i = 0; i < countOpt; i++) {
                //Print the text on the screen, but slightly lower each time
                GUI.Label(new Rect(100, 100 + (20 * i), 50, 50), options[i]);
            }
        }
    }

}
