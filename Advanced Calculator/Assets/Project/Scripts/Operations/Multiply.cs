using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiply : Operator
{
    protected override double GetTempResult()
    {
        return operations[0].GetResult() * operations[1].GetResult();
    }
}
