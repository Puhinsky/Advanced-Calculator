using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constant : Operation
{
    public double value;

    public override double GetResult()
    {
        return value;
    }
}
