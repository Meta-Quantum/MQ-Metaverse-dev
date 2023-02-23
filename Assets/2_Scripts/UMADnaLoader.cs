using UMA.CharacterSystem;
using UnityEngine;

public class UMADnaLoader : MonoBehaviour
{
    public DynamicCharacterAvatar Avatar;
    
    public void LoadDnaToCharacter()
    {
        // Load the avatar from the player prefs
        var saveString = PlayerPrefs.GetString("AvatarSaveString");
        if (string.IsNullOrEmpty(saveString))
        {
            Debug.LogError("No avatar saved");
            return;   
        }
            
        Avatar.LoadFromRecipeString(saveString);
    }
}
