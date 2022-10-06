using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    public PokemonBase Base { get; set; }
    public int Level { get; set; }

    public int HP { get; set; }
    public List<Move> Moves { get; set; }

    public Pokemon(PokemonBase pBase, int pLevel)
    {
        Base = pBase;
        Level = pLevel;
        HP = MaxHp;

        
        //generates moves
        Moves = new List<Move>();
        foreach(var move in Base.LearnableMoves)
        {
            if(move.Level <= Level)
                Moves.Add(new Move(move.Base));
            
            if(Moves.Count >= 4)
                break;
        }
    }

    public int MaxHp
    {
        get { return Mathf.FloorToInt((Base.MaxHp * 2 * Level) / 100f) + Level + 10; }
        //go back to modify for IVs later
        // https://bulbapedia.bulbagarden.net/wiki/Stat#Individual_values
    }

    public int Attack
    {
        get { return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5; }
    }

    public int Defense
    {
        get { return Mathf.FloorToInt((Base.Defense * Level) / 100f) + 5; }
    }

    public int SpecialAttack
    {
        get { return Mathf.FloorToInt((Base.SpecialAttack * Level) / 100f) + 5; }
    }

    public int SpecialDefense
    {
        get { return Mathf.FloorToInt((Base.SpecialDefense * Level) / 100f) + 5; }
    }

    public int Speed
    {
        get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 5; }
    }


    //evolution function
    //public Evolution CheckForEvolution()
    //{
        //return Base.EvolutionList.FirstOrDefault(e => e.RequiredLevel == Level);
    //}

    //public void Evolve(Evolution evolution)
    //{
        //Base = evolution.EvolvesInto;
        //CalculateStats();
    //}

    //note for now, "Attack" should consider physical or special, same with Defense.
    public bool TakeDamage(Move move, Pokemon attacker)
    {
        float modifiers = Random.Range(0.85f, 1f);
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.Base.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);
        Debug.Log($"Damage for {move.Base.Name} is {damage}");
        HP -= damage;
        if(HP <= 0)
        {
            HP = 0;
            return true;
        }

        //specifies the pokemon did not faint/die
        return false;
    }

}
