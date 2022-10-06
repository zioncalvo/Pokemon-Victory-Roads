using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHud : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] HPBar hpBar;

    Pokemon _pokemon;

    public void SetData(Pokemon pokemon)
    {
        _pokemon = pokemon;

        nameText.text = pokemon.Base.Name;
        levelText.text = " " + pokemon.Level;
        hpBar.SetHP((float)pokemon.HP / pokemon.MaxHp);
    }

    public IEnumerator UpdateHP()
    {
       yield return hpBar.AnimateHPBar((float)_pokemon.HP / _pokemon.MaxHp);
    }
}
