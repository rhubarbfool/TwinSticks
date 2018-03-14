using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_UNLOCK_KEY = "level_unlocked_";

	public static void SetMasterVolume(float volume){
		if (volume >= 0.0f && volume <= 1.0f) {
			PlayerPrefs.SetFloat (MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError("Volume out of range");
		}
	}
	public static float GetMasterVolume(){
		float volume = 	PlayerPrefs.GetFloat (MASTER_VOLUME_KEY);
		return volume;
	}

	public static void SetDifficulty(float difficulty){
		if (difficulty >= 1.0 && difficulty <= 3.0) {
			PlayerPrefs.SetFloat (DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError("Difficulty out of range");
		}
	}
	public static float GetDifficulty(){
		float difficulty = 	PlayerPrefs.GetFloat (DIFFICULTY_KEY);
		return difficulty;
	}

	public static void LevelUnlock(int level){
		if (level >= 1 && level <= SceneManager.sceneCountInBuildSettings -1) {
			PlayerPrefs.SetInt (LEVEL_UNLOCK_KEY + level.ToString (), 1);
		} else {
			Debug.LogError("Level out of range");
		}
	}
	public static bool IsLevelUnlocked( int level){
		bool levelUnlocked = false;

		if (level < 1 || level > SceneManager.sceneCountInBuildSettings - 1) {
			Debug.LogError("Asked for level out of range");
		}
		else if (PlayerPrefs.GetInt (LEVEL_UNLOCK_KEY + level.ToString ()) == 1) {
			levelUnlocked = true;
		}

		return levelUnlocked;
	}

}
