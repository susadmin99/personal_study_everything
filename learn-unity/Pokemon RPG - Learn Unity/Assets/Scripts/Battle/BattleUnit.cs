using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    public Image unitBackImage;

    [SerializeField] PokemonBase _base;
    [SerializeField] int level;
    [SerializeField] bool isPlayerUnit;

    public Pokemon Pokemon { get; set; }

    public void Setup()
    {
        Pokemon = new Pokemon(_base, level);
        if (isPlayerUnit) 
            unitBackImage.sprite = Pokemon.Base.BackSprite; 
        else 
            unitBackImage.sprite = Pokemon.Base.FrontSprite;
    }
}
