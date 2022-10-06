using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour
{

    public BattleUnit playerUnit;

    public TextMeshProUGUI whatHappenedText;
    [SerializeField] int lettersPerSecond;
    [SerializeField] Image actionSelectionBox;
    public TextMeshProUGUI actionSelectText;
    [SerializeField] GameObject actionSelector;

    public IEnumerator TypeDialogue(string dialogue)
    {
        whatHappenedText.text = "";
        foreach (var letter in dialogue.ToCharArray())
        {
            whatHappenedText.text += letter;
            yield return new WaitForSeconds(1f/lettersPerSecond);
        }

        yield return new WaitForSeconds(0.75f);

        actionSelectionBox.gameObject.SetActive(true);
        whatHappenedText.gameObject.SetActive(false);
        actionSelectText.gameObject.SetActive(true);

        StartCoroutine(TypeDialogueActionSelect($" What will {playerUnit.Pokemon.Base.Name} do? "));
    }

    public IEnumerator TypeDialogueActionSelect(string actionDialogue)
    {
        actionSelectText.text = "";
        foreach (var letter in actionDialogue.ToCharArray())
        {
            actionSelectText.text += letter;
            yield return new WaitForSeconds(1f/lettersPerSecond);
        }
        
        actionSelector.gameObject.SetActive(true);

    }

    public void TypeDialogueFightMenu(string actionDialogue)
    {
        whatHappenedText.gameObject.SetActive(true);
        actionSelectText.gameObject.SetActive(false);
        whatHappenedText.text = "";
        Debug.Log(actionDialogue);
        StartCoroutine(Type(actionDialogue));    
    }

    public IEnumerator Type(string actionDialogue) {
        whatHappenedText.text = "";
        foreach (var letter in actionDialogue.ToCharArray())
        {
            whatHappenedText.text += letter;
            yield return new WaitForSeconds(1f/lettersPerSecond);
        }
    }

}
