using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DependentCompilation : MonoBehaviour {


    public GameObject panelWIN;
    public GameObject panelWEBGL;

    public Button button;
  void Start () {

    #if UNITY_STANDALONE_WIN
    panelWIN.SetActive(true);
    panelWEBGL.SetActive(false);

       
    #endif

    #if UNITY_WEBGL
    panelWIN.SetActive(false);
    panelWEBGL.SetActive(true);
    button.gameObject.SetActive(false);
    #endif

  }          
}
