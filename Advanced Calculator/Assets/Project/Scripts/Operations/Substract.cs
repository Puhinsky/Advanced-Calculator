﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Substract : Operator
{
    public override double GetResult()
    {
        return operations[0].GetResult() - operations[1].GetResult();
    }
}