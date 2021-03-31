using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiply : Operation
{
    public Operation[] operations = new Operation[2];

    public override double GetResult()
    {
        return operations[0].GetResult() * operations[1].GetResult();
    }
}
