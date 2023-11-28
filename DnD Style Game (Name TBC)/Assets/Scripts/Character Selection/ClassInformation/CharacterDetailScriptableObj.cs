using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//for looking at the class bonuses + assigning stats in the game based off of it
[CreateAssetMenu(fileName = "ClassInformation", menuName = "ScriptableObjects/CharacterDetails", order = 1)]
public class CharacterDetailScriptableObj : ScriptableObject { 
    public string className;

    public int hitDie;
    public int baseHitPoints;

}
