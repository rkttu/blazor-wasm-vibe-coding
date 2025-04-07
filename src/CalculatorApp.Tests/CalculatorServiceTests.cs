using CalculatorApp.Services;
using Xunit;

namespace CalculatorApp.Tests;

public class CalculatorServiceTests
{
    private readonly CalculatorService _calculatorService;

    public CalculatorServiceTests()
    {
        _calculatorService = new CalculatorService();
    }

    [Fact]
    public void Add_ShouldReturnCorrectResult()
    {
        // Arrange
        double firstNumber = 10;
        double secondNumber = 5;

        // Act
        double result = _calculatorService.Calculate(firstNumber, secondNumber, Operation.Add);

        // Assert
        Assert.Equal(15, result);
        Assert.Empty(_calculatorService.ErrorMessage);
    }

    [Fact]
    public void Subtract_ShouldReturnCorrectResult()
    {
        // Arrange
        double firstNumber = 10;
        double secondNumber = 5;

        // Act
        double result = _calculatorService.Calculate(firstNumber, secondNumber, Operation.Subtract);

        // Assert
        Assert.Equal(5, result);
        Assert.Empty(_calculatorService.ErrorMessage);
    }

    [Fact]
    public void Multiply_ShouldReturnCorrectResult()
    {
        // Arrange
        double firstNumber = 10;
        double secondNumber = 5;

        // Act
        double result = _calculatorService.Calculate(firstNumber, secondNumber, Operation.Multiply);

        // Assert
        Assert.Equal(50, result);
        Assert.Empty(_calculatorService.ErrorMessage);
    }

    [Fact]
    public void Divide_ShouldReturnCorrectResult()
    {
        // Arrange
        double firstNumber = 10;
        double secondNumber = 5;

        // Act
        double result = _calculatorService.Calculate(firstNumber, secondNumber, Operation.Divide);

        // Assert
        Assert.Equal(2, result);
        Assert.Empty(_calculatorService.ErrorMessage);
    }

    [Fact]
    public void Divide_ByZero_ShouldSetErrorMessage()
    {
        // Arrange
        double firstNumber = 10;
        double secondNumber = 0;

        // Act
        double result = _calculatorService.Calculate(firstNumber, secondNumber, Operation.Divide);

        // Assert
        Assert.Equal(0, result);
        Assert.Equal("0으로 나눌 수 없습니다.", _calculatorService.ErrorMessage);
    }

    [Theory]
    [InlineData(2, 3, 5)]     // 2 + 3 = 5
    [InlineData(-5, 5, 0)]    // -5 + 5 = 0
    [InlineData(0, 0, 0)]     // 0 + 0 = 0
    [InlineData(2.5, 3.5, 6)] // 2.5 + 3.5 = 6
    public void Add_WithVariousInputs_ShouldReturnCorrectResult(double first, double second, double expected)
    {
        // Act
        double result = _calculatorService.Calculate(first, second, Operation.Add);

        // Assert
        Assert.Equal(expected, result);
        Assert.Empty(_calculatorService.ErrorMessage);
    }

    [Theory]
    [InlineData(5, 3, 2)]       // 5 - 3 = 2
    [InlineData(-5, -3, -2)]    // -5 - (-3) = -2
    [InlineData(0, 0, 0)]       // 0 - 0 = 0
    [InlineData(5.5, 2.5, 3)]   // 5.5 - 2.5 = 3
    public void Subtract_WithVariousInputs_ShouldReturnCorrectResult(double first, double second, double expected)
    {
        // Act
        double result = _calculatorService.Calculate(first, second, Operation.Subtract);

        // Assert
        Assert.Equal(expected, result);
        Assert.Empty(_calculatorService.ErrorMessage);
    }
}