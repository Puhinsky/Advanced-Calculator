using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Divide : Operator
{
    protected override double GetTempResult()
    {
        return operations[0].GetResult() / operations[1].GetResult();
    }
}
