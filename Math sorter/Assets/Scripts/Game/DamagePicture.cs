using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePicture : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //this.gameObject.SetActive(false); 
    }

    public void ActivateDamagePicture()
    {
        this.gameObject.SetActive(true);
    }
    public void DeactivateDamagePicture()
    {
        this.gameObject.SetActive(false);
    }
}
