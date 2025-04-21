using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MeilleurScoreTemps : MonoBehaviour
{
    public float meilleurScore = 0f;
    public TextMeshProUGUI textMeilleurScore;

    private MiniJeu _jeu;

    private void Start()
    {
        _jeu = GetComponent<MiniJeu>();

        meilleurScore = PlayerPrefs.GetFloat("meilleurScore", 0f);
        textMeilleurScore.text = "Meilleur score : " + meilleurScore.ToString("00.00");
    }

    private void Update()
    {
        if(_jeu.pointageTemps > meilleurScore)
        {
            meilleurScore = _jeu.pointageTemps;

            PlayerPrefs.SetFloat("meilleurScore", meilleurScore);
            textMeilleurScore.text = "Meilleur score "+DateTime.Now.ToString("g")+" : " + meilleurScore.ToString("00.00");
        }
    }
}
