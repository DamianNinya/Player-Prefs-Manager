using UnityEngine;
using System.Collections.Generic;

public class PlayerPrefsManager  MonoBehaviour
{
    public static PlayerPrefsManager Instance { get; private set; }
    private Liststring preferenceKeys = new Liststring();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePreferenceT(string key, T value)
    {
        if (!preferenceKeys.Contains(key))
        {
            preferenceKeys.Add(key);
        }

        if (value is int)
        {
            PlayerPrefs.SetInt(key, (int)(object)value);
        }
        else if (value is float)
        {
            PlayerPrefs.SetFloat(key, (float)(object)value);
        }
        else if (value is string)
        {
            PlayerPrefs.SetString(key, (string)(object)value);
        }
        PlayerPrefs.Save();
    }

    public T LoadPreferenceT(string key, T defaultValue)
    {
        if (typeof(T) == typeof(int))
        {
            return (T)(object)PlayerPrefs.GetInt(key, (int)(object)defaultValue);
        }
        else if (typeof(T) == typeof(float))
        {
            return (T)(object)PlayerPrefs.GetFloat(key, (float)(object)defaultValue);
        }
        else if (typeof(T) == typeof(string))
        {
            return (T)(object)PlayerPrefs.GetString(key, (string)(object)defaultValue);
        }

        return defaultValue;
    }

    public bool KeyExists(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public void SaveAllPreferences()
    {
        PlayerPrefs.Save();
    }

    public void ClearAllPreferences()
    {
        foreach (var key in preferenceKeys)
        {
            PlayerPrefs.DeleteKey(key);
        }
        PlayerPrefs.Save();
        preferenceKeys.Clear();
    }

    public T GetPreferenceOrDefaultT(string key, T defaultValue)
    {
        if (KeyExists(key))
        {
            return LoadPreference(key, defaultValue);
        }
        else
        {
            SavePreference(key, defaultValue);
            return defaultValue;
        }
    }
}