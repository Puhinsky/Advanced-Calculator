using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputControl : MonoBehaviour
{
    [SerializeField] private TMP_Text inputField;
    [SerializeField] private string beginCaret;
    [SerializeField] private string endCaret;
    [SerializeField] private CalculatorPresenter calculator;

    private string equation = "0";
    private int caretPosition;

    private void Init()
    {

    }

    private char ValidateInput(string text, int position, char addedChar)
    {
        StringBuilder sb = new StringBuilder(text);
        Debug.Log(position);

        if (char.IsDigit(addedChar))
            return addedChar;

        if (position == 0)
        {
            if (char.IsDigit(addedChar))
                return addedChar;
        }
        else
        {
            if (isOperator(sb[position - 1]))
            {
                sb[position - 1] = '\0';
                inputField.text = sb.ToString();
                return addedChar;
            }

            if (isOperator(addedChar))
                return addedChar;
        }
        return '\0';
    }
    private bool isOperator(char _operator)
    {
        switch (_operator)
        {
            case ('+'):
                return true;
            case ('-'):
                return true;
            case ('*'):
                return true;
            case ('/'):
                return true;
            default:
                return false;
        }
    }

    public void InputSymbol(string value)
    {
        if (equation.Length <= 1 && equation.StartsWith("0"))
        {
            equation = value;
            caretPosition = 0;
        }
        else
        {
            equation = equation.Insert(caretPosition + 1, value);
            caretPosition++;
        }
        UpdateEquationPresent(caretPosition);
    }

    public void RemoveSymbol()
    {
        if (equation.Length > 1)
        {
            equation = equation.Remove(caretPosition, 1);
            caretPosition--;
            caretPosition = ClampPosition(caretPosition);
        }
        else
        {
            equation = "0";
            caretPosition = 0;
        }
        UpdateEquationPresent(caretPosition);
    }

    public void Decide()
    {
        calculator.Decide(equation);
    }

    public void ChangePosition(int direction)
    {
        caretPosition += direction;
        caretPosition = Mathf.Clamp(caretPosition, 0, equation.Length - 1);
        UpdateEquationPresent(caretPosition);
    }

    private void OnEnable()
    {
        Init();
    }

    private void Start()
    {
        ChangePosition(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            ChangePosition(-1);
        if (Input.GetKeyDown(KeyCode.RightArrow))
            ChangePosition(1);
    }

    private string AddCaret(string input, int position)
    {
        string output = input;
        output = output.Insert(position, beginCaret);
        output = output.Insert(position + beginCaret.Length + 1, endCaret);
        return output;
    }

    private void UpdateEquationPresent(int position)
    {
        string temp = AddCaret(equation, position);
        inputField.text = temp;
    }
    private int ClampPosition(int value)
    {
        return Mathf.Clamp(value, 0, equation.Length);
    }
}
