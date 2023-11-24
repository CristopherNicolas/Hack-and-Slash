using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
	public Sprite spritePistol, spriteBomba;
    public Image hpFillImage,cdConejo;
    public static UISystem instance;
    public TMP_Text balasCountText;
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        ActualizarMarcador();
    }
    void ActualizarMarcador()
    {
        //para lanzar bombas player
        hpFillImage.fillAmount = (Player.instance.hp / Player.instance.maxHP) ;
        
        //para lanzar bombas player
        //hpFillImage.fillAmount = (Conejo.instance.cd / Conejo.instance.maxCD) / 100;

        //cdConejo.fillAmount = (Conejo.instance.cd / Conejo.instance.maxCD) / 100;

    }

}
