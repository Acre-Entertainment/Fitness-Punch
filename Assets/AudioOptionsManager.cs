using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioOptionsManager : MonoBehaviour
{
    public static float musicVolume { get; private set;  }
    public static float soundEffectsVolume { get; private set; }

    //[SerializeField] private TextMeshProUGUI musicButtonText;
    //[SerializeField] private TextMeshProUGUI soundEffectsButtonText;

    public void OnMusicButtonValueChange(int value)
    {
        musicVolume = value;

        //musicButtonText.text = value.ToString();
        AudioManager.Instance.UpdateMixerVolume();
    }

    public void OnSoundEffectsButtonValueChange(int value)
    {
        soundEffectsVolume = value;

        //soundEffectsButtonText.text = value.ToString();
        AudioManager.Instance.UpdateMixerVolume();
    }

}
