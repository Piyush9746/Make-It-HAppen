using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    private bool muted = false;


    // Start is called before the first frame update
    void Start()
    {
        
            if (!PlayerPrefs.HasKey("muted"))

            {
                PlayerPrefs.SetInt("muted", 0);
                Load();
            }
            else
            {
                Load();
            }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }
   
   public void OnButtonPress()
    {
        if (muted== false)
        {
            muted = true;
            AudioListener.pause = true;
            
        }

        else
        {
            muted= false;
            AudioListener.pause = false;    
        }
        save();
        UpdateButtonIcon();
        
    }


    private void UpdateButtonIcon  ()
        
    {
        if (muted == false)
        {
            soundOnIcon.enabled = true;
            soundOffIcon.enabled = false;
        }
        else

        { 
            soundOnIcon.enabled = false;
            soundOffIcon.enabled = true;        
        }
    }

    private void Load()

    {
        muted = PlayerPrefs.GetInt("muted") == 1;

    }
    private void save()
    {
        PlayerPrefs.SetInt("muted",muted ? 1 : 0); 
    }
}
