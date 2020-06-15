using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlatformHorizontalController : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        transform.DOMove(new Vector3(11,0,0), 2).SetRelative().SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}
