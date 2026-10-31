using TMPro;
using UnityEngine;

public class PlayerNameInput : MonoBehaviour
{
    public TMP_InputField nameInput;
    public string defaultName = "Player";

    private const string NameKey = "PlayerName";

    public string PlayerName
    {
        get
        {
            string typedName = nameInput.text.Trim();

            if (typedName == "")
            {
                return defaultName;
            }

            return typedName;
        }
    }

    void Start()
    {
        nameInput.text = PlayerPrefs.GetString(NameKey, "");
        nameInput.onEndEdit.AddListener(SaveName);
    }

    void OnDestroy()
    {
        nameInput.onEndEdit.RemoveListener(SaveName);
    }

    void SaveName(string newName)
    {
        PlayerPrefs.SetString(NameKey, newName.Trim());
        PlayerPrefs.Save();
    }
}