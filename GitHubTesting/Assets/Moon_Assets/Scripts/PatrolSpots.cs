using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Store patrol points position in a Transform array, patrol points differ for each enemy crawler
/// Used for patrol behaviour script in crawler animator statemachinebehaviour
/// </summary>
public class PatrolSpots : MonoBehaviour
{
    public Transform[] patrolPoints;
}
