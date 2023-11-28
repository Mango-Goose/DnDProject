using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionHookup : MonoBehaviour
{
    [SerializeField] CharacterDetailScriptableObj[] classes;
    [SerializeField] GameObject[] classButtons;

    [SerializeField] Text className;
    [SerializeField] public Text classDescription;
    int classIndex;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EditTextComponent(GameObject buttonPressed)
    {
        classIndex = FindClass(buttonPressed);
        className.text = classes[classIndex].className;
        classDescription.text = "Hit Dice: 1d" + classes[classIndex].hitDie + "\n" + "Base Hit Points: " + classes[classIndex].baseHitPoints;

    }

    public void SetPlayerClass()
    {
        PlayerPrefs.SetInt("PlayerClass", classIndex);
    }
    private int FindClass(GameObject buttonPressed)
    {
        int i = 0;
        foreach (GameObject button in classButtons)
        {
            print(i);
            if (button == buttonPressed)
            {
                break;
            }
            else
            {
                i += 1;
            }
        }
        return i;
    }
}
