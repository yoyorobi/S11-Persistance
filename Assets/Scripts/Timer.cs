using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _textTemps;

    [SerializeField] private float _tempsEcoule;
    [SerializeField] private Image _cercle;

    private float _tempReset = 10;
    private float _chrono = 0;



    //------------------------------------------------------------------------

    void Start()
    {
        _tempsEcoule = 0;
        _textTemps.text = "0";
    }

    //------------------------------------------------------------------------


    void Update()
    {
        Decompte();
    }

    //------------------------------------------------------------------------
    void Decompte()
    {
        _tempsEcoule += Time.deltaTime;
        int _secondes = Mathf.FloorToInt(_tempsEcoule % 60);
        int _minutes = Mathf.FloorToInt(_tempsEcoule / 60);

        
         _chrono  +=  Time.deltaTime * 10;
         int affiche = Mathf.FloorToInt(_chrono % 60);
       
        if (affiche >= 10)
        {
        _chrono = 0;
         _cercle.fillAmount += 0.025f;
        }

        _textTemps.text = string.Format("{0:00}", affiche);

        //------------------------------------------------------------------------
    }
}
