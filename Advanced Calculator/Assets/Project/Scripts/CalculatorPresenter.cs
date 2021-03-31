using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CalculatorPresenter : MonoBehaviour
{
    public string equation = "12*15+61";
    [SerializeField] private TMP_Text resultText;

    private Calculator calculator = new Calculator();

    public void Decide()
    {
        calculator.Decide(equation, this);
    }

    public void Decide(string value)
    {
        calculator.Decide(value, this);
    }

    public void ShowResult(double result)
    {
        resultText.text = result.ToString();
    }

    private void Start()
    {
        //Decide();
    }
}
