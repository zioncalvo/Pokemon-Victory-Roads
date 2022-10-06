using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Moves", menuName = "Moves/CreateNewMoves")]


public class MoveBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] PokemonType moveType;
    [SerializeField] int power;
    [SerializeField] int accuracy;
    [SerializeField] int maxPP;

    //setting up properties
    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public PokemonType MoveType
    {
        get { return moveType; }
    }

    public int Power
    {
        get { return power; }
    }

    public int Accuracy
    {
        get { return accuracy; }
    }

    public int MaxPP
    {
        get { return maxPP; }
    }
}
