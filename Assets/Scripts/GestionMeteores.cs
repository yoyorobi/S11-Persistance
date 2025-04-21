using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionMeteores : MonoBehaviour
{
    [SerializeField] GameObject prefabMeteore;
    [SerializeField] private float delai;
    [SerializeField] private float interval;

    void Start()
    {
        InvokeRepeating("CreerMeteore", delai, interval);   
    }

    void CreerMeteore()
    {
        Instantiate(prefabMeteore, transform.position, Quaternion.Euler(0, 0, Random.value * 360f));
    }
}
