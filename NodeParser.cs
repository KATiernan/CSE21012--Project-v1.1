using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;



/* Created 3/20/17 by Katie R., much of NodeParser written
 * 
 * 
 * 
 * */

public class NodeParser : MonoBehaviour {

    ArrayList fullScene = new ArrayList();
    //storing characters? not sure
    //HashSet<> npcInstances = new HashSet<>;
    
    // Use this for initialization
    void Start () {
        //Gets the current scene to which the GameObject applies
        Scene currentScene = SceneManager.GetActiveScene();
        //Gets the name/extension of the Scene object
        string sceneExtension = currentScene.name.Split('_')[1];
        //File path for the text dialogue
        string filePath = "Assets/Dialogue/Dialogue" + sceneExtension + ".txt";

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
    // Check if player has clicked left
	void Update () {

        /*
         * 
         * if click,
         * then npcDisplay.Clear();
         * lineNum += 1;
         * if lineNum < fullScene.Count
         * Character charCode = PrintWordsToScreen(lineNum);
         * 
         * if charCode is PlayerPrompt, 
         * choices a, b, c
         * switch case? 
         * then transition scene --> next scene
         * 
         * */

        



    }

    // Method to display dialogue/prompts in the text box on-screen
    void PrintWordsToScreen(int lineNumber) {
        //Gets the current line
        string currentLine = (string)fullScene[lineNumber];
        //reads from the fields
        string[] fields = currentLine.Split('|');
        
        //Look through file for character name/expression
        Character npcDisplay = new Character(fields[0], fields[1], fields[2]);
        npcDisplay.Display();
        //text box - put dialogue here  
        
        //return npcDisplay;      
    }

}
