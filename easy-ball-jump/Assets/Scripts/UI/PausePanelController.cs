using System.Collections;
using System.Collections.Generic;
using Helpers;
using UnityEngine;

public class PausePanelController : MonoSingleton<PausePanelController> {
    Dictionary<string, GameObject> _childMenus = new Dictionary<string, GameObject>();
    string _currentChildMenu;
    
    void Start() {
        //set pivot to center
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        
        // hide all child menus
        foreach (Transform child in transform) {
            _childMenus.Add(child.name, child.gameObject);
            child.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
    }

    public void Show(string childMenuName) {
        gameObject.SetActive(true);
        if (_childMenus.ContainsKey(childMenuName)) {
            _childMenus[childMenuName].SetActive(true);
            _currentChildMenu = childMenuName;
            RectTransform childRect =  _childMenus[childMenuName].GetComponent<RectTransform>();
            childRect.pivot = new Vector2(0.5f, 0.5f);
        }
        else {
            Debug.Log("Menu: " + childMenuName + " was not found in PausePanel.");
        }
    }
    public void Hide() {
        gameObject.SetActive(false);
        _childMenus[_currentChildMenu].SetActive(false);
    }
}
