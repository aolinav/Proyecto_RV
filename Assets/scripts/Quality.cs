using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quality : MonoBehaviour
{
    
    public TMP_Dropdown dropdown;
    public int quality;
    
    void Start()
    {
        //PlayerPrefbs es una forma de guardar datos en el juego. Predefinido numero 3 (Valor alto)
        quality = PlayerPrefs.GetInt("numeroDeCalidad",3);
        dropdown.value = quality;
        AjustarCalidad();
    }

    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        quality = dropdown.value;
    }


}
