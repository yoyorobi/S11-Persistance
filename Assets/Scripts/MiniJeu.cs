using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniJeu : MonoBehaviour
{
    public float pointageTemps;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textScorePanneau;
    public TMP_InputField inputNom; 
    [SerializeField] GameObject panneauRecord;

    void Start()
    {
        //TODO supprimer apres tests
        //PlayerPrefs.DeleteAll();
        pointageTemps = 0;
    }

    private void Update()
    {
        textScore.text = pointageTemps.ToString("00.00");
    }

    public void TraiterDefaite(){
        Debug.Log("Defaite!");
        float recordActuel = PlayerPrefs.GetFloat("meilleurScore", 0f);
        if(pointageTemps >= recordActuel){
            Invoke("MontrerPanneauNouveauRecord", 3f);
        }   
    }

    void MontrerPanneauNouveauRecord(){
        //Debug.Log("Nouveau record!");
        panneauRecord.SetActive(true);
        textScorePanneau.text = textScore.text;
    }

    public void EnregisterNomRecord(){
        string nom = inputNom.text;
        PlayerPrefs.SetString("nom", nom);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
