using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle,
    Move,
    Jump,
    Attack,
    Hit,
    Poisoned,
    Healed,
    Cast,
    Dead,
}
public class States
{
    public List<State> currentStates;
}
