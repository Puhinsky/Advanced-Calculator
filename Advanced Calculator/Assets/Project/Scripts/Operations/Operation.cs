using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Operation : IOperationResult
{
    public int[] borders = new int[2];

    public abstract double GetResult();
}
