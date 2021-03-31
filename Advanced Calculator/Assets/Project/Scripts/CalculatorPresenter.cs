using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorPresenter : MonoBehaviour
{
    public string equation = "12*15";

    private Calculator calculator = new Calculator();

    public void Decide()
    {
        calculator.Decide(equation);
    }

    private void Start()
    {
        Decide();
    }
}
