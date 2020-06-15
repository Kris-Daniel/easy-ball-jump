using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Platforms;
using UnityEngine;

public class PlatformVerticalController : PlatformController
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        transform.DOMove(new Vector3(0,2.5f,0), 2).SetRelative().SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
