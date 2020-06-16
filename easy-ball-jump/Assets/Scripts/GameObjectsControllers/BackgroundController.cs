using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Helpers;
using UnityEngine;

public class BackgroundController : MonoSingleton<BackgroundController>
{
    Tween colorTween, emissionTween, offsetTween;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Material mat = gameObject.GetComponent<Renderer>().material;

        // COLOR
        //colorTween = mat.DOColor(toColor, 1).SetLoops(-1, LoopType.Yoyo).Pause();

        // OFFSET
        // In this case we set the loop to Incremental and the ease to Linear, because it's cooler
        offsetTween = mat.DOOffset(new Vector2(1, 1), 5).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental).Pause();
        offsetTween.TogglePause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
