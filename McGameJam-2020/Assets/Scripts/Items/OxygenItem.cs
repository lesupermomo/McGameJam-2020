﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenItem : Interactable
{
    public override void Interact()
    {
        PlayerManager.instance.oxLevel += 10;
        base.Interact();
    }
}