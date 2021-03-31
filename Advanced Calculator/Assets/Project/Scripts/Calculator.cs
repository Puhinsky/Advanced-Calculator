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
            }
        }
        for (int i = 0; i < equationSB.Length; i++)
        {
            if (equationSB[i] == '*')
            {
                Multiply multiply = new Multiply();
                int position = i;
                foreach (var operation in operations)
                {
                    if (operation.borders[0] == position + 1)
                    {
                        multiply.operations[0] = operation;
                        multiply.borders[0] = operation.borders[0];
                    }
                    if (operation.borders[1] == position - 1)
                    {
                        multiply.operations[1] = operation;
                        multiply.borders[1] = operation.borders[1];
                    }
                }
                operations.Add(multiply);
            }
        }
        foreach (var item in operations)
        {
            Debug.Log(item.GetResult());
        }
    }
}
