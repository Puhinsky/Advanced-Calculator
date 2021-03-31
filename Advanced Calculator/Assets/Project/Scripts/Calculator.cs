using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Calculator
{
    List<Operation> operations = new List<Operation>();

    public void Decide(string equation)
    {
        equation += "$";
        StringBuilder equationSB = new StringBuilder(equation);

        for (int i = 0; i < equationSB.Length; i++)
        {
            if (char.IsDigit(equationSB[i]))
            {
                Constant constant = new Constant();
                constant.borders[0] = i;
                string value = "";
                while (char.IsDigit(equationSB[i]))
                {
                    value += equationSB[i];
                    i++;
                }
                i--;
                double.TryParse(value, out constant.value);
                constant.borders[1] = i;
                operations.Add(constant);
                Debug.Log("Borders " + constant.borders[0] + " " + constant.borders[1]);
            }
        }
        for (int i = 0; i < equationSB.Length; i++)
        {
            if (equationSB[i] == '*')
            {
                Multiply multiply = new Multiply();
                SetOperator(multiply, i);
            }
            if (equationSB[i] == '/')
            {
                Divide divide = new Divide();
                SetOperator(divide, i);
            }
        }
        for (int i = 0; i < equationSB.Length; i++)
        {
            if (equationSB[i] == '+')
            {
                Add add = new Add();
                SetOperator(add, i);
            }
            if (equationSB[i] == '-')
            {
                Substract substract = new Substract();
                SetOperator(substract, i);
            }
        }
        foreach (var item in operations)
        {
            Debug.Log(item.GetResult());
        }
    }

    private void SetOperator(Operator _operator, int position)
    {
        Debug.Log("Position " + position);
        foreach (var operation in operations)
        {
            if (operation.borders[1] == position - 1)
            {
                _operator.operations[0] = operation;
                _operator.borders[0] = operation.borders[0];
                operation.borders[0] = -1;
                operation.borders[1] = -1;
            }
            if (operation.borders[0] == position + 1)
            {
                _operator.operations[1] = operation;
                _operator.borders[1] = operation.borders[1];
                operation.borders[0] = -1;
                operation.borders[1] = -1;
            }
        }
        operations.Add(_operator);
    }
}
