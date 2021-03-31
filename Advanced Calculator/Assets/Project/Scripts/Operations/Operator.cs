using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Operator : Operation
{
    public Operation[] operations = new Operation[2];

    public override double GetResult()
    {
        for (int i = 0; i < 2; i++)
        {
            if(operations[i] == null)
            {
                operations[i] = new Constant(); 
            }
        }
        return GetTempResult();
    }

    protected abstract double GetTempResult();
}
