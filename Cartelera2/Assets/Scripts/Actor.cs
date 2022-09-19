using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Actor")]
public class Actor : ScriptableObject
{
    public string actorName = "";
    public string[] biography = new string[(int)AppLenguage.MAX_LENGUAGES];
    public Sprite countryFlag, portrait;

    public bool sex;
}
