using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject _openBackpackFlap;

    [SerializeField]
    private GameObject _backpackFlap;

    private Vector3 _flapClosePosition;

    private Quaternion _flapCloseRotation;

    private void Awake()
    {
        _openBackpackFlap.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        EventService.OnBackpackOpen += OpenBackPack;
        EventService.OnBackpackClose += CloseBackPack;
    }

    private void OnDisable()
    {
        EventService.OnBackpackOpen -= OpenBackPack;
        EventService.OnBackpackClose -= CloseBackPack;
    }

    private void OpenBackPack(float animationTime)
    {
        _flapClosePosition = _backpackFlap.transform.position;
        _flapCloseRotation = _backpackFlap.transform.rotation;
        StartCoroutine(BackpackOpenAnimationRoutine(animationTime));
    }

    private void CloseBackPack(float animationTime)
    {
        StartCoroutine(BackpackCloseAnimationRoutine(animationTime));
    }

    IEnumerator BackpackOpenAnimationRoutine(float animationTime)
    {
        _backpackFlap.transform.DOMove(_openBackpackFlap.transform.position, animationTime);
        _backpackFlap.transform.DORotateQuaternion(_openBackpackFlap.transform.rotation, animationTime);
        yield return new WaitForSeconds(0);
    }

    IEnumerator BackpackCloseAnimationRoutine(float animationTime)
    {
        _backpackFlap.transform.DOMove(_flapClosePosition, animationTime);
        _backpackFlap.transform.DORotateQuaternion(_flapCloseRotation, animationTime);
        yield return new WaitForSeconds(0);
    }

}
