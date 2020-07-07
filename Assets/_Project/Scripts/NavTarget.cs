﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTarget : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;

    private void Update()
    {
        agent.SetDestination(target.position);
    }
}