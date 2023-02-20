using UMA.CharacterSystem;
using UMA;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class UMACreatorManager : MonoBehaviour
{
    public DynamicCharacterAvatar Avatar;
    public string saveString;

    public void SaveCharacterAndGoToLauncher()
    {
        SaveUMAToPlayerPrefs();
        SceneManager.LoadScene("Launcher");
    } 

    public void SaveUMAToPlayerPrefs()
    {
        saveString = Avatar.GetCurrentRecipe();
        
        // Save the avatar to the player prefs
        PlayerPrefs.SetString("AvatarSaveString", saveString);
        
        //check if the avatar is saved
        if (PlayerPrefs.HasKey("AvatarSaveString"))
        {
            Debug.Log("Avatar saved");
        }
    }
}
