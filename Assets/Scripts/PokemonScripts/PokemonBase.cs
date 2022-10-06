using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/CreateNewPokemon")]

public class PokemonBase : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] int pokedexNumber;

    [TextArea]
    [SerializeField] string description;
    

    [Header("Pokemon Sprites")]
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;
    [SerializeField] Sprite shinyFrontSrpite;
    [SerializeField] Sprite shinyBackSprite;
    [SerializeField] Sprite partyIcon1;
    [SerializeField] Sprite partyIcon2;

    [SerializeField] PokemonType type1;
    [SerializeField] PokemonType type2;


    [Header("Pokemon Base Stats")]
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int specialAttack;
    [SerializeField] int specialDefense;
    [SerializeField] int speed;
    [SerializeField] int baseStatTotal;

    [Header("Pokemon Abilities")]

    //ability1
    //ability2
    //hiddenAbility


    //megaEvolution

    [Header("Miscellaneous Stats")]
    [SerializeField] private float catchRate;
    [SerializeField] private float xpUponDefeat;
    [SerializeField] private float weight;
    [SerializeField] private float hatchTime;
    //levelRate
    [SerializeField] private float genderRate;
    [SerializeField] private float pokemonSellRate;
    //[SerializeField] private Audio pokemonCry;
    [SerializeField] private int generation;
    


    //encounterRates
    //[SerializeField] bool encounterable = false;
    //[SerializeField] bool encounterRate1 = false;
    //[SerializeField] bool encounterRate4 = false;
    //[SerializeField] bool encounterRate5 = false;
    //[SerializeField] bool encounterRate10 = false;
    //[SerializeField] bool encounterRate20 = false;
    //[SerializeField] bool encounterRate30 = false;
    //[SerializeField] bool encounterRate50 = false;

    [Header("Encounter Rooms")]
    [SerializeField] PokemonEncounterType encounterType1;
    [SerializeField] PokemonEncounterType encounterType2;
    [SerializeField] PokemonEncounterType encounterType3;
    [SerializeField] PokemonEncounterType encounterType4;


    [SerializeField] List<Evolution> evolutionList;
    [SerializeField] List<LearnableMoves> learnableMoves;



    //setting properties
    public string Name 
    {
        get{ return name; } 
    }

    public string Description
    {
        get{ return description; }
    }

    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }

    public Sprite BackSprite
    {
        get { return backSprite; }
    }

    public Sprite PartyIcon1
    {
        get { return partyIcon1; }
    }

    public Sprite PartyIcon2
    {
        get { return partyIcon2; }
    }

    public PokemonType Type1
    {
        get { return type1; }
    }

    public PokemonType Type2
    {
        get{ return type2; }
    }

    public int MaxHp
    {
        get{ return maxHp;}
    }

    public int Attack
    {
        get{ return attack;}
    }

    public int Defense
    {
        get{ return defense;}
    }

    public int SpecialAttack
    {
        get{ return specialAttack;}
    }

    public int SpecialDefense
    {
        get{ return specialDefense;}
    }

    public int Speed
    {
        get{ return speed;}
    }

    public int BaseStatTotal
    {
        get{ return baseStatTotal;}
    }

    public List<Evolution> EvolutionList => evolutionList;

    public List<LearnableMoves> LearnableMoves
    {
        get { return learnableMoves; }
    }

}

[System.Serializable]
public class LearnableMoves
{
    [SerializeField] MoveBase moveBase; 
    [SerializeField] int level;

    public MoveBase Base
    {
        get { return moveBase; }
    }

    public int Level
    {
        get { return level; }
    }
}

public enum PokemonType
{
    None,
    Normal,
    Fire,
    Water,
    Grass,
    Electric,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dark,
    Dragon,
    Steel,
    Fairy
}

[System.Serializable]
public class Evolution
{
    [SerializeField] PokemonBase evolvesInto;
    [SerializeField] int requiredLevel;

    public PokemonBase EvolvesInto => evolvesInto;
    public int RequiredLevel => requiredLevel;
}

public enum PokemonEncounterType
{
    NotEncounterable,
    None,
    EarlyGame1,
    EarlyGame2,
    EarlyGame3,
    MidGame1,
    MidGame2,
    MidGame3,
    LateGame1,
    LateGame2,
    LateGame3
}


