using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Movie")]
public class Movie : ScriptableObject
{
    public string[] title = new string[(int)AppLenguage.MAX_LENGUAGES];
    public int year;
    public string[] sinopsis = new string[(int)AppLenguage.MAX_LENGUAGES];
    public Sprite countryFlag, cover;

    public Actor[] staff;
}
