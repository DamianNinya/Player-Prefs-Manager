
# PlayerPrefsManager

This script simplifies managing PlayerPrefs in Unity. It allows you to save and load integers, floats, and strings without repetitive boilerplate code. The script uses a singleton pattern so you only need one persistent instance across your scenes.

To set it up, simply attach the PlayerPrefsManager script to a GameObject in your initial scene. It will persist across scene loads.

### Saving Data

Call the method to save data, passing in a key and a value:

```csharp
// Save an integer
PlayerPrefsManager.Instance.SavePreferenceT("PlayerScore", 150);

// Save a float
PlayerPrefsManager.Instance.SavePreferenceT("PlayerSpeed", 5.5f);

// Save a string
PlayerPrefsManager.Instance.SavePreferenceT("PlayerName", "AceGamer");
```

### Loading Data

Retrieve your saved values by calling the load method, specifying a key and a default value:

```csharp
// Load an integer
int score = PlayerPrefsManager.Instance.LoadPreferenceT("PlayerScore", 0);

// Load a float
float speed = PlayerPrefsManager.Instance.LoadPreferenceT("PlayerSpeed", 1.0f);

// Load a string
string name = PlayerPrefsManager.Instance.LoadPreferenceT("PlayerName", "DefaultName");
```

### Saving Enums

You can also save enum states by converting them to an integer before saving.

Define your enum:

```csharp
public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver
}
```

**Saving the enum:**

```csharp
GameState currentState = GameState.Playing;
PlayerPrefsManager.Instance.SavePreferenceT("GameState", (int)currentState);
```

**Loading the enum:**

```csharp
int savedStateValue = PlayerPrefsManager.Instance.LoadPreferenceT("GameState", (int)GameState.MainMenu);
GameState loadedState = (GameState)savedStateValue;

// Check the loaded state
if (loadedState == GameState.Playing)
{
    Debug.Log("The game is in the 'Playing' state.");
}
```

## Additional Operations

- **Check if a Key Exists:**  
  Verify whether a preference key is already stored.

  ```csharp
  bool hasScore = PlayerPrefsManager.Instance.KeyExists("PlayerScore");
  ```

- **Clear All Preferences:**  
  This method removes all saved preferences managed by the PlayerPrefsManager.

  ```csharp
  PlayerPrefsManager.Instance.ClearAllPreferences();
  ```

- **Get or Set Default Preference:**  
  This method checks if a key exists. If it does, it returns the saved value; otherwise, it saves the default value provided and returns that.

  ```csharp
  int level = PlayerPrefsManager.Instance.GetPreferenceOrDefaultT("PlayerLevel", 1);
  ```

## Saving Changes Manually

Although the script automatically saves changes after each operation, you can force a save at any time:

```csharp
PlayerPrefsManager.Instance.SaveAllPreferences();
```
