﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrivingPlanes : MonoBehaviour
{
    [SerializeField]
    private TurnArrivals[] turns;

    public PlaneSO[] GetArrivals(int turn)
    {
        return turns[turn].arrivals;
    }
}


[System.Serializable]
public class TurnArrivals
{
    public PlaneSO[] arrivals;
}