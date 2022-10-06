using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHud playerHud;
    [SerializeField] BattleHud enemyHud;
    [SerializeField] DialogueBox dialogueBox;
    public PlayerFightMenu fightMenu;
    public ActionMenu actionMenu;

    private void Start()
    {
       StartCoroutine(SetupBattle());
       fightMenu.PerformPlayerMove += PerformPlayerMove;
    }

    private void Update()
    {

    }

    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHud.SetData(playerUnit.Pokemon);
        enemyHud.SetData(enemyUnit.Pokemon);

        dialogueBox.playerUnit = playerUnit;
        fightMenu.playerUnit = playerUnit;

        yield return(dialogueBox.TypeDialogue($" A wild {enemyUnit.Pokemon.Base.Name} appeared! "));
    }

    void PerformPlayerMove(float x, float y)
    {

        Move moveUsed = null;

        if (fightMenu.playerMoves.Count != 0) 
        {
            // Move 1
            if(x == 0f && y == 0f)
            {
                dialogueBox.TypeDialogueFightMenu($" {playerUnit.Pokemon.Base.Name} used {fightMenu.playerMoves[0].Base.Name}! ");
                moveUsed = fightMenu.playerMoves[0];
            }
            // Move 2
            if(x == 1f && y == 0f)
            {
               dialogueBox.TypeDialogueFightMenu($" {playerUnit.Pokemon.Base.Name} used {fightMenu.playerMoves[1].Base.Name}! ");
               moveUsed = fightMenu.playerMoves[1];
            }
            // Move 3
            if(x == 0f && y == 1f)
            {
                dialogueBox.TypeDialogueFightMenu($" {playerUnit.Pokemon.Base.Name} used {fightMenu.playerMoves[2].Base.Name}! ");
                moveUsed = fightMenu.playerMoves[2];
            }
            // Move 4
            if(x == 1f && y == 1f)
            {
                dialogueBox.TypeDialogueFightMenu($" {playerUnit.Pokemon.Base.Name} used {fightMenu.playerMoves[3].Base.Name}! ");
                moveUsed = fightMenu.playerMoves[3];
            }
        }
        //new WaitForSeconds(1.5f);
        fightMenu.gameObject.SetActive(false);
        StartCoroutine(UseMoveUsed(moveUsed));
    }

    IEnumerator UseMoveUsed(Move moveUsed)
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log($"Before the attack: {enemyUnit.Pokemon.Base.Name} has {enemyUnit.Pokemon.HP}/{enemyUnit.Pokemon.MaxHp}");
        bool isEnemyPokemonFainted = enemyUnit.Pokemon.TakeDamage(moveUsed, playerUnit.Pokemon);
        yield return enemyHud.UpdateHP();
        Debug.Log(isEnemyPokemonFainted);
        Debug.Log($"After: {enemyUnit.Pokemon.Base.Name} has {enemyUnit.Pokemon.HP}/{enemyUnit.Pokemon.MaxHp}");

        if(isEnemyPokemonFainted)
        {
            yield return dialogueBox.Type($" {enemyUnit.Pokemon.Base.Name} Fainted! ");
            Invoke("EndBattle", 2f);
        }
        else
        {
            //note that this is not how I want to go about AI for now... mianly talkign about different types of AI
            //call AIScript attatched?
            //Make seperate AI Script?
            AIMove();
            yield return new WaitForSeconds(1.5f);
            yield return playerHud.UpdateHP();
        }

    }

    void AIMove()
    {
        var enemyMove = GetRandomMove(enemyUnit.Pokemon);
        Debug.Log($"Before: {playerUnit.Pokemon.Base.Name} has {playerUnit.Pokemon.HP}/{playerUnit.Pokemon.MaxHp}");
        bool isPlayerPokemonFainted = (playerUnit.Pokemon.TakeDamage(enemyMove, enemyUnit.Pokemon));
        dialogueBox.TypeDialogueFightMenu($" {enemyUnit.Pokemon.Base.Name} used {enemyMove.Base.Name} ! ");
        if(isPlayerPokemonFainted)
        {
            dialogueBox.TypeDialogue($" {playerUnit.Pokemon.Base.Name} Fainted! ");
        }
        else
        {
            Invoke("NextTurn", 1.5f);
        }
        Debug.Log($"After: {playerUnit.Pokemon.Base.Name} has {playerUnit.Pokemon.HP}/{playerUnit.Pokemon.MaxHp}");

    }

    Move GetRandomMove(Pokemon pokemon) 
    {
        int r = Random.Range(0, pokemon.Moves.Count);
        Debug.Log(pokemon.Moves[r].Base.Name.ToString());
        return pokemon.Moves[r];
    }

    void NextTurn() 
    {
        actionMenu.gameObject.SetActive(true);
        dialogueBox.actionSelectText.gameObject.SetActive(true);
        dialogueBox.whatHappenedText.gameObject.SetActive(false);
    }

    void EndBattle()
    {
        SceneManager.LoadScene("TestBase");
    }
}
