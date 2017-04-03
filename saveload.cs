using UnityEngine;					//allows us to use dynamic lists in C#
using System.Collections;
using System.Collections.Generic;			//allows us to use OS's serialization capabilities within script
using System.Runtime.Serialization.Formatters.Binary;	//allows us to use Binary formatter
using System.IO;					//(Input.Output) allows us to write+read from comp or mobile device

public static class SaveLoad {

	public static List<Game> savedGame = new List<Game>();


//The savedGame would call the storynode class? presumably, but I used this variable name for a draft



public static void Save() {
	if (savedGame.Count() <= 3) {
		savedGame.Add(Game.current);
	}
	else {
        savedGames = Game.current;			//This might need to be changed, not quite sure how to phrase if/else statements
	}			
	BinaryFormatter bf = new BinaryFormatter()							//handles serialization
	FileStream file = File.Create(Path.Combine(Application.persistentDataPath, "savedGame.gd"));	//creates new savedgame file
	bf.Serialize(file, SaveLoad.savedGame);						
	file.Close();
}



public static void Load() {
	if (File.Exists(Path.Combine(Application.persistentDataPath, "savedGame.gd"))) {		//will load file if it exists
	BinaryFormatter bf = new BinaryFormatter();
	FileStream file = File.Open(Application.persistentDataPath + "/savedGame.gd", FileMode.Open);
	SaveLoad.savedGame = (List<Game>)bf.Deserialize(file);						//finds the file at the location we specified above and deserializes it
	file.Close();
	}

}
}