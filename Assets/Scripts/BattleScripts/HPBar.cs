using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;

    public void SetHP(float hpNormalized)
    {
        health.transform.localScale = new Vector3(hpNormalized, 1f);
    }

    public IEnumerator AnimateHPBar(float newHP)
    {
        float curHP = health.transform.localScale.x;
        float changeAmount = curHP - newHP;

        //loop to keep making it go down till damage is fully done
        while(curHP - newHP > Mathf.Epsilon)
        {
            curHP -= changeAmount * Time.deltaTime;
            health.transform.localScale = new Vector3(curHP, 1f);
            yield return null;
        }
        health.transform.localScale = new Vector3(newHP, 1f);
    }

}