using Assets.Scripts;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorCombo : MonoBehaviour
{
    public static ContadorCombo Instance;
    public int comboQuantityCount = 0;
    public float timeToDecreasseCombo=3;
    public float devilTriggerCount;
    public bool dt1,dt2,dt3;
    TMP_Text text;
    //private void Update()
    //{
    //    // to test:
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        AddToCount(1);
    //    }
    //}
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        Instance = this;
    }
    public void AddToCount(int qantity)
    {   
        comboQuantityCount+= qantity;
        devilTriggerCount+= qantity;
        if (devilTriggerCount == 10) dt1 = true;
        else if(devilTriggerCount == 17) dt2 = true;
        else if(devilTriggerCount >= 25 ) dt3 = true;
        text.text = $"{comboQuantityCount} combo!";
        text.DOColor(new Color(1, 1, 1, 1), .1f);
        float shakeCoeficient = comboQuantityCount * .05f;
        text.rectTransform.DOShakeScale(.3f,shakeCoeficient)
            .OnComplete(()=> text.rectTransform.DOScale(Vector3.one, .15f));
    }
    private IEnumerator Start()
    {
        while (true)
        {
            while (comboQuantityCount > 0)
            {
                int actulCount = comboQuantityCount;
                yield return new WaitForSeconds(timeToDecreasseCombo);
                if (actulCount < comboQuantityCount) continue;
                else ResetCounter();
            }
            yield return new WaitUntil(() => comboQuantityCount > 0);
        }
    }
    void ResetCounter()
    {
        text.DOColor(new Color(1, 1, 1, 0), timeToDecreasseCombo);
        comboQuantityCount = 0;
        //resetear devil trigger
    }
    public void StartDevilTrigger() => StartCoroutine(DevilTrigger());
    IEnumerator DevilTrigger()
    {
        float duration=0;
        if(dt1) duration = 5;
        else if(dt2) duration = 10;
        else if(dt3) duration = 25;
        dt1 = false; dt2 = false; dt3 = false;
            
        
        // activar filtro de pantalla
        // buff habilidades, hp
        // buff velocidad 
        yield return new WaitForSeconds(duration);
        // sacar : 
        // activar filtro de pantalla
        // buff habilidades, hp
        // buff velocidad 
    }

}
