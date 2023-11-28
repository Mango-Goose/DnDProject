using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetClassTextInGame : MonoBehaviour
{
    int playerClassIndex;
    [SerializeField] CharacterDetailScriptableObj[] classes;

    [SerializeField] Text classDisplay;
    // Start is called before the first frame update
    void Start()
    {
        playerClassIndex = PlayerPrefs.GetInt("PlayerClass");
        classDisplay.text = classes[playerClassIndex].className;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
