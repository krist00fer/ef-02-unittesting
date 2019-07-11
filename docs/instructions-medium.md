# Challenge Instructions - Easy

## Requirements
Create a RPN Calculator Class according to what was descibed earlier using *Test Driven Development*. The calculator should support the following operators:

### Calculator Methods

* Result - Returns the last pushed value from the stack without removing it. If no result is available, method should return 0.
* Push - Adds a value to the calculators stack
* Stack - Returns a list of values representing the current internal stack
* Pop - Removes the last pushed value from the calculators stack
* Clear - Cleans the internal state of our calculator

### Math Methods

* Add - Adds the two latest values pushed. `Push 2, Push 3 (add) -> 5`
* Sub - Subtracts the latest value pushed from the second last value pushed. `Push 5, Push 3, (sub) -> 2`
* Mul - Multiplies the two latest values pushed. `Push 2, Push 3, (mul) -> 6`
* Div - Divides the the second last value pushed by the last value pushed. `Push 5, Push 2, (div) -> 2.5`
* Sqrt - Calculates the square root of the last value pushed. `Push 9, (sqrt) -> 3`

## Instructions

You'll get a series of suggested Unit Tests to copy and implement one at a time. Do NOT jump to conclusions or try to implement a more complex solution than what is required to solve the failing Unit Tests.

Whenever a unit test introduces a new method in the calculator class, you can use Visual Studio Code to implement that method automatically. The default implementation that Visual Studio Code will give you will throw a NotImplementedException wich is perfect to have your Unit Tests fail before you implement the correct implementation.

Make sure to follow the mantra: Red->Green->Refactor to all points and never implement any code that isn't needed for a test to succeed.

I can't stress how important it is for tests to fail before you are allowed to make any changes to your implementation. Otherwise we might introduce tests that show "false positives", i.e. test that doesn't work but still signals that everything is correct.

## Before you start

Open Visual Studio Code with your solution as the root folder (`code .`). If Visual Studio suggest that you should install some additional files, then do so.

Rename the two files `/src/EF2.UnitTesting/Class1.cs` and `/src/EF2.UnitTestin.Tests/UnitTest1.cs` according to this.

   * Class1.cs -> RpnCalculator.cs
   * UnitTest1.cs -> RpnCalculator.Tests.cs

Also rename the class definitions inside those files to `RpnCalculator` and `RpnCalculatorTests`.

## Executing tests

You can always execute tests from the terminal window by executing the command `dotnet test` but there are also possibilities to execute unit tests direcly from within Visual Studio Code. Explore your options as you go and consider installing and configuring additional extensions like:

* .NET Core Test Explorer

## The Unit Tests

* Take the the first unit test and copy it into your RpnCalculator.Tests.cs.
* Fix so your solution compile
* Run the tests and make sure that at least one unit test is failing
* Fix the implementation with least amount of effort
* Test again
* If all tests are `green`then repeat from the beginning agin.

> The first Unit Tests will include all the code for the tests themselves, while as we go, the unit tests will leave more and more for you to implement, so don't expect that you can just copy past everything into your solution.

Happy Coding!

### Unit Test 1

> The first Unit Test also include code to create a private class variable and the constructor to our test class

```csharp
        private RpnCalculator calc;

        public RpnCalculatorTests()
        {
            // This constructor is called before every test is executed
            calc = new RpnCalculator();
        }

        [Fact]
        public void Result_EmptyCalc_ShouldReturnZero()
        {
            double result = calc.Result();

            result.Should().Be(0);
        }
```

### Unit Test 2
```csharp
        [Fact]
        public void Push_EmptyCalc_ShouldWork()
        {
            calc.Push(0d);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        public void Result_WithPushedValue_ShouldReturnSameValue(double v, double expectedValue)
        {
            calc.Push(v);

            double result = calc.Result();

            result.Should().Be(expectedValue);
        }
```

### Unit Test 3
```csharp
        [Fact]
        public void Stack_EmptyCalc_ShouldReturnEmtpyArray()
        {
            double[] result = calc.Stack();

            result.Should().BeEmpty();
        }
```

### Unit Test 4
```csharp
        [Theory]
        [InlineData(1, 2, 3, 1, 2, 3)]
//TODO: Add more InlineData here after you've successfully implemented a solution with only this line
        public void Stack_PushedValues_ShouldReturnAnArrayWithThePushedValues(
            double v1, double v2, double v3,
            double expectedV1, double expectedV2, double expectedV3)
        {
            calc.Push(v1);
            calc.Push(v2);
            calc.Push(v3);

            double[] result = calc.Stack();

            result.Should().BeEquivalentTo(expectedV1, expectedV2, expectedV3);
        }
```

### Unit Test 5
```csharp
        [Fact]
        public void Pop_WithPushedValue_ShouldDecrementStackSizeByOne()
        {
            calc.Push(1);
            calc.Push(2);

            calc.Pop();

            var stackLength = calc.Stack().Length;
            stackLength.Should().Be(1);
        }
```

### Unit Test 6
```csharp
        [Fact]
        public void Pop_WithEmptyCalc_ShouldThrowException()
        {
            Action act = () => calc.Pop();

            act.Should().Throw<InvalidOperationException>();
        }
```

### Unit Test 7
```csharp
        [Fact]
        public void Clear_WithPushedValues_ShouldResetStackToEmpty()
        {
            calc.Push(1);
            calc.Push(2);

            calc.Clear();

            calc.Stack().Should().BeEmpty();
        }
```

### Unit Test 8
```csharp
        [Theory]
        [InlineData(1, 2, 3)]
//TODO: Add more InlineData here after you've successfully implemented a solution with only this line
        public void Add_WithTwoPushedValues_ShouldCalculateSum(double v1, double v2, double expectedResult)
        {
            calc.Push(v1);
            calc.Push(v2);
            
            calc.Add();

            calc.Result().Should().Be(expectedResult);
        }
```

### Unit Test 9
```csharp
        [Theory]
//TODO: InlineData is completely missing here, add it
        public void Sub_WithTwoPushedValues_ShouldCalculateDifference(double v1, double v2, double expectedResult)
        {
            calc.Push(v1);
            calc.Push(v2);
            
            calc.Sub();

            calc.Result().Should().Be(expectedResult);
        }
```

### Unit Test 10
```csharp
        [Theory]
        [InlineData(2, 2, 4)]
//TODO: Add more InlineData here after you've successfully implemented a solution with only this line
        public void Mul_WithTwoPushedValues_ShouldCalculateProduct(double v1, double v2, double expectedResult)
        {
//TODO: Implement the test yourself here
        }
```

### Unit Test 11
```csharp
        [Theory]
//TODO: InlineData is completely missing here, add it
        public void Div_WithTwoPushedValues_ShouldCalculateQuotient(double v1, double v2, double expectedResult)
        {
//TODO: Implement the test yourself here
        }
```

### Unit Test 12
```csharp
        [Theory]
//TODO: InlineData is completely missing here, add it
        public void Sqrt_SinglePushedValue_ShouldCalculateSquareRoot(double v, double expectedResult)
        {
//TODO: Implement the test yourself here
        }
    }
}
```

### Unit Test 13

Implement a UnitTest to make sure an exception is thrown if you try to call the Add operator with two few values pushed to the calculator.

### Unit Test 14+

* Implement the operator sin, cos and tan
* Tweak the implementation of the calculator to allow a fluent interface like:

```csharp
var result = calc.Push(5).Push(2).Push(7).Add().Mul().Result();

result.Should().Be(45);
```

## When you are done

Put your implementation in a public GitRepository and share the URL with your instructor and ask for a Code Review.