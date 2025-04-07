using System;

namespace CalculatorApp.Services
{
    public enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide
    }

    public class CalculatorService
    {
        public string ErrorMessage { get; private set; } = string.Empty;

        public double Calculate(double firstNumber, double secondNumber, Operation operation)
        {
            ErrorMessage = string.Empty;
            double result = 0;

            try
            {
                switch (operation)
                {
                    case Operation.Add:
                        result = firstNumber + secondNumber;
                        break;
                    case Operation.Subtract:
                        result = firstNumber - secondNumber;
                        break;
                    case Operation.Multiply:
                        result = firstNumber * secondNumber;
                        break;
                    case Operation.Divide:
                        if (secondNumber == 0)
                        {
                            ErrorMessage = "0으로 나눌 수 없습니다.";
                            return 0;
                        }
                        result = firstNumber / secondNumber;
                        break;
                    default:
                        ErrorMessage = "지원하지 않는 연산입니다.";
                        break;
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"계산 중 오류가 발생했습니다: {ex.Message}";
            }

            return result;
        }
    }
}