using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildPokemon : MonoBehaviour
{

    [SerializeField] private PokemonBase pokemonBase;

    // Start is called before the first frame update
    void Start()
    {

        GenerateRandomPokemon();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateRandomPokemon() {
        Object[] pokemonBases = Resources.LoadAll("Pokemon", typeof(PokemonBase));
        PokemonBase chosenPokemon = pokemonBases[Random.Range(0, 9)] as PokemonBase;
        Debug.Log(chosenPokemon.Name);
        Debug.Log(chosenPokemon.FrontSprite);
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = chosenPokemon.FrontSprite;

        PokemonLoadManager.enemyPokemon = chosenPokemon;
    }
}
