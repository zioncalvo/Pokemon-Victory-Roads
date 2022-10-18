using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokemonLoadManager : MonoBehaviour
{

    [SerializeField] BattleUnit enemyBattleUnit;
    static public PokemonBase enemyPokemon;

    // Start is called before the first frame update
    void Start()
    {
        enemyBattleUnit._base = enemyPokemon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
