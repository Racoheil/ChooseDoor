using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftHolder : MonoBehaviour
{
    private Image _giftRenderer;

    private Vector3 _startingPosition;

    private Vector3 _previousPosition;
    private void Awake()
    {
        _giftRenderer = GetComponent<Image>();
        this.gameObject.SetActive(false);
        _startingPosition = this.transform.position;
    }

    public void ChangeGiftSprite(Sprite gift)
        => _giftRenderer.sprite = gift;

    public void ActivateObject()
    {
        this.gameObject.SetActive(true);
    }

    public void DeActivateObject()
    {
        this.gameObject.SetActive(false);
    }

    public void MoveGiftHolder(Vector3 newPosition)
    {
        // Vector3 newPosition = new Vector3(door.transform.position.x, _giftHolderView.transform.position.y, _giftHolderView.transform.position.z);
        //Vector3 newPosition2 = new Vector3(newPosition.x, _startingPosition.y, _startingPosition.z);
        this.transform.position = newPosition;
        // this.transform.localPosition = newPosition;
    }

    public void MoveGiftHolderToDoor(Vector3 newPosition)
    {
        // Vector3 newPosition = new Vector3(door.transform.position.x, _giftHolderView.transform.position.y, _giftHolderView.transform.position.z);
        this.transform.position = new Vector3(newPosition.x, _startingPosition.y, _startingPosition.z);
      //  this.transform.position = newPosition;
        // this.transform.localPosition = newPosition;
    }

    public void ReturnToStartingPosition()
    {
        this.transform.position = _startingPosition;
  
    }  
    public void ReturnToPreviousPosition()
    {
       this.transform.DOMove(_previousPosition, 0.5f);
    }
    public void ZoomOutGiftHolder()
    {
        this.transform.DOScale(1f, 0.5f);
    }
    public void ZoomInGiftHolder(float addingValueZ)
    {
        float zoomDuration = 0.15f;
        _previousPosition = this.transform.position;
        Vector3 newPosition = new Vector3(_startingPosition.x,0, _startingPosition.z);
       // MoveGiftHolder(newPosition);
        this.transform.DOMove(newPosition, zoomDuration);
        this.transform.DOScale(2f, zoomDuration);
    }

    
}
