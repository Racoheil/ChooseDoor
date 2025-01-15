using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsPanelService : MonoBehaviour
{
    private DoorButton _selectedDoorButton;

    public DoorButton SelectedDoorButton { get; set; }


    public static DoorsPanelService s_instance;

    private void Awake()
    {
        s_instance = this;
    }
}
