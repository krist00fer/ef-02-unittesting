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

## Step By Step Instructions

By know you should have created your "empty" solution and should be able to execute the commands `dotnet build` to build your solution, and `dotnet test` to run all unittests in your solution. Let's get started.

1. Open your solution in Visual Studio Code by executing

```
code .
```

2. Visual Studio Code will ask you `"Required assets to build and debug are missing from 'ef2'. Add them?` answer `Yes`.

3. Visual Studio Code is now open and on the left side you should see or be able to open the "Explorer View" that gives you a graphical view of all files in the current solution. Look around and make sure you can find the following files `/src/EF2.UnitTesting/Class1.cs` and `/src/EF2.UnitTestin.Tests/UnitTest1.cs`. Rename the files by right clicking on them and select `Rename`:

   * Class1.cs -> RpnCalculator.cs
   * UnitTest1.cs -> RpnCalculator.Tests.cs

4. Replace the content of `RpnCalculator.Tests.cs` with the following code:

```csharp
using System;
using Xunit;
using FluentAssertions;

namespace EF2.UnitTesting.Tests
{
    public class RpnCalculatorTests
    {
        [Fact]
        public void Result_EmptyCalc_ShouldReturnZero()
        {
            throw new NotImplementedException();
        }
    }
}
```

5. Replace the content of `RpnCalculator.cs` with the following code:

```csharp
using System;

namespace EF2.UnitTesting
{
    public class RpnCalculator
    {
    }
}
```

6. Save all your files and then in your terminal window execute `dotnet build` to see that your solution still compiles. Execute `dotnet test` to make sure your test can run. Notice that your only test should fail at this point since your have not implemented it. In fact you implemented it by saying `throw new NotImplementedException();` wich is the reason why your test currently fail, but this is expected at this time.

```
22:17 $ dotnet build
Microsoft (R) Build Engine version 16.1.76+g14b0a930a7 for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 36.03 ms for /Users/kristofer/ef2/src/EF2.UnitTesting.Tests/EF2.UnitTesting.Tests.csproj.
  Restore completed in 35.8 ms for /Users/kristofer/ef2/src/EF2.UnitTesting/EF2.UnitTesting.csproj.
  EF2.UnitTesting -> /Users/kristofer/ef2/src/EF2.UnitTesting/bin/Debug/netstandard2.0/EF2.UnitTesting.dll
  EF2.UnitTesting.Tests -> /Users/kristofer/ef2/src/EF2.UnitTesting.Tests/bin/Debug/netcoreapp2.2/EF2.UnitTesting.Tests.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:02.33
✔ ~/ef2 
22:34 $ dotnet test
Test run for /Users/kristofer/ef2/src/EF2.UnitTesting.Tests/bin/Debug/netcoreapp2.2/EF2.UnitTesting.Tests.dll(.NETCoreApp,Version=v2.2)
Microsoft (R) Test Execution Command Line Tool Version 16.1.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
[xUnit.net 00:00:00.49]     EF2.UnitTesting.Tests.RpnCalculatorTests.Peak_EmptyCalc_ShouldReturnNull [FAIL]                                                                      
  X EF2.UnitTesting.Tests.RpnCalculatorTests.Peak_EmptyCalc_ShouldReturnNull [5ms]                                                                                               
  Error Message:
   System.NotImplementedException : The method or operation is not implemented.
  Stack Trace:
     at EF2.UnitTesting.Tests.RpnCalculatorTests.Peak_EmptyCalc_ShouldReturnNull() in /Users/kristofer/ef2/src/EF2.UnitTesting.Tests/RpnCalculator.Tests.cs:line 12
                                                                                                                                                                                 
Test Run Failed.
Total tests: 1
     Failed: 1
 Total time: 1.0621 Seconds
```

> From here on, when I referr to "build your solution", "test your solution" or the combination "build and test your solution" I refer to any commands that will trigger a build or your tests to run. Feel free to continue using the terminal window to do so or have a look at the built in features in Visual Studio Code or one of the many available Extensions.

> A common misstake is forget to save your files before you build and/or test your solution. So remember to save your files!

7. Remember our mantra: Red->Green->Refactor . We need to be in the state where one or more unit tests are failing in order to be allowed to change our code. Right now we have one test that is failing but it's due to the test not being written correctly, so let's fix that. In `RpnCalculator.Tests.cs`, edit your test to look like this:

```csharp
        [Fact]
        public void Result_EmptyCalc_ShouldReturnZero()
        {
            RpnCalculator calc = new RpnCalculator();

            double result = calc.Result();

            result.Should().Be(0);
        }
```

8. Notice that we are tryign to call a method `Result()` that doesn't yet exists and Visual Studio Code warns you of this by showing red "squiggles" under the method name Result(). You can ask Visual Studio Code to implement that method by placing the cursor on top of the missing method and then clicking on the "light bulb" on the left hand side of the row and selecting `Generate Method 'RpnCalculator.Result'`. An even faster way would be to place the cursor over the missing method and clicking the keyboard shortcut `<Ctrl> + .` on Windows/Linux or `<Command> + .` on Mac. No matter how you do it, the result should be visible in `RpnCalculator.cs` and should look like this:

```csharp
        public double Result()
        {
            throw new NotImplementedException();
        }
```

> From now on, when the instructions says: "Implement the missing method", you are asked to do exactly what we did right now in order to get a new method that just throws an exception of type `NotImplementedException`.

9. Save your files, compile and test your solution. Your solution should compile at this point but the test `Peak_EmptyCalc_ShouldReturnZero` should fail due to the method not being implemented. This time though, it's the `Result` method that's not implemented and we can be happy, since we now have a proper Unit Test that signals that something is wrong and doesn't work according to the specifications, so we can go ahead and fix it. We are now at "red state" in our mantra *Red*->Green-> Refactor. So celebrate some and then continue to next step.

10. The failing test says, that an empty/cleared calculator should return 0 if someone ask for the latest result. What is the *easiest* way to fix our failing test? ... Implement the Result-method as following in `RpnCalculator.cs`, save and test your solution:

```csharp
        public double Result()
        {
            return 0;
        }
```

11. Yeahaaa! We've just fixed our first failing Unit Test. OK the test and the implementation was trivial but still if you don't look at it as only a test, but also as a specification, we now have documentation that says that an empty calculator should return the result 0. So this moved us to Green in our mantra: Red->*Green*->Refactor. So if all tests are working (we only have one) we are allowed to refactor our code. Refactor means to change without changing the observed behaviour.

12. So if all tests are working (we only have one) we are allowed to refactor our code. Refactor means to change without changing the observed behaviour. So let's look at both our implementation code and the unit test code, is there anything we could make more simple or more effective? Probably not much at this time, so let's keep going. We need to get to the a state where one or more Unit Tests are failing and right now the best we can do is probably to write another Unit Test.

> From now on, when the instructions mentions a test that need to be changed or implemented we expect you to do that in the file `RpnCalculator.Tests.cs` and any implementation that need to be changed or implemented should be done in the file `RpnCalculator.cs`.

13. Implement the following test that will test if we can push a value to our calculator. Since the method Push doesn't exist, use the same method as above in step 8 above, to implement the Push method. Then compile and test your solution.

```csharp
        [Fact]
        public void Push_EmptyCalc_ShouldWork()
        {
            RpnCalculator calc = new RpnCalculator();
            
            calc.Push(0d);
        }
```
> We are using a trick here to tell Visual Studio Code that our method `Push` should accept decimal values aka. double in .NET. `0d`in c# means that we are refering to zero as a double.

> Notice that most often our unit tests are setup in three steps: `setup, act, assert` or sometimes referred to as `given, when, then`. In this test, we are given a new calculator, we act by pusing to it and nothing should really happen so the `assert`or `then` stage of our test isn't valid in this test other than it shouldn't throw an exception.

14. Once again, we have a test that fails and it is a possitive fail, meaning it fails due to the right reasons, so we need to fix it. Pushing a zero to the calculator shouldn't throw an exception... but how do we fix it? It's quite simple, just remove the line that throws the exception.

```csharp
        public void Push(double v)
        {
        }
```

15. Ok, that felt wierd again, but it's true, this is the least code we can fix in order to adher to the requirements aka. our unit tests. So we moved from `red` to `green` state and can now start thinking about refactoring. Can we make our code better or easier. Well our implementation is quite basic and probably hard to make any easier, but what about our test class. Seems like if all (two) of our tests start with the line `RpnCalculator calc = new RpnCalculator();`. Perhaps just a coincidence but let's keep an eye on it, to see if it becomes a trend.

16. Time to implement a new Unit Test. What about looking at what should happen with the `Result()` method if we first push some number? Implement the following test and then compile and test your solution.

```csharp
        [Fact]
        public void Result_WithPushedZero_ShouldReturnZero()
        {
            RpnCalculator calc = new RpnCalculator();
            calc.Push(0);

            double result = calc.Result();

            result.Should().Be(0);
        }
```

17. Something unexpected should have happened here. We added a new test, but it didn't fail?!?! Seems like we are testing something that already exists, so we need to continue implement another unit test to get us to that `red` state where some test is failing. So keep the above test and add a new one according to this. Compile and test your solution:

```csharp
        [Fact]
        public void Result_WithPushedOne_ShouldReturnOne()
        {
            RpnCalculator calc = new RpnCalculator();
            calc.Push(1);

            double result = calc.Result();

            result.Should().Be(1);
        }
```

18. Looks like we implemented a test that is complicated enough this time. If you look at this and the previous test the are in fact the same test but with just a different number being pushed, hmmmm interesting. But we are happy because we can go ahead and change our implementation so it fixes the "requirements", i.e. the failing unit test. Somehow we need to remember what value that has been pushed so we then can return it when we call the Result method. Update your RpnCalculator class to look like this. Compile and test:

```csharp
    public class RpnCalculator
    {
        double lastValue = 0;

        public double Result()
        {
            return lastValue;
        }

        public void Push(double v)
        {
            lastValue = v;
        }
    }

```

19. We are back at a `green` state and should consider refactoring our code. Our implemenation of our calculator still looks very simple (even too simple) so there isn't much we can do there. Our test file start to show some resemblance of recurring patterns that could be simplified. The test framework we are currently using, Xunit, provide us with a way of creating parameterized unit tests. That would be very welcome in order to simplify the two test methods that test that Result should return the last pushed value. We do understand the value of having both (since only one of them made our implementation fail) so we don't want to remove any of them but simplify them. At the same time, we can now certainly say that all tests that we have created need a calculator to work on, so if we can do that once that would also simplify the tests a lot. Replace or change the content of your RpnCalculator.cs so it looks like this. Build and test:

```csharp
using System;
using Xunit;
using FluentAssertions;

namespace EF2.UnitTesting.Tests
{
    public class RpnCalculatorTests
    {
        private RpnCalculator calc;

        public RpnCalculatorTests()
        {
            calc = new RpnCalculator();
        }

        [Fact]
        public void Result_EmptyCalc_ShouldReturnZero()
        {
            double result = calc.Result();

            result.Should().Be(0);
        }

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
    }
}

```

20. So what did we do there? Somehow it looked like we cut one test, but when we test the solution we still have 4 tests that got successfully executed. The answer lies within the last test that is now "flagged" with the `Theory` attribute instead of the `Fact`that we've used for the other tests. This is a feature of Xunit that allow us to add input variables and different values to the same test, so we are still running the same tests, just simplified the code. We also simplified the creation of the RpnCalculator that we use in every class and now it's available by default in every test we do. Awesome, there isn't much more we can refactor at this point so let's continue.

21. Time to write some more specifications (or Unit Tests) to drive our code foward. Implement the following test and let Visual Studio Code implement the implementation of the missing method `Stack()`. Test your solution.

```csharp
        [Fact]
        public void Stack_EmptyCalc_ShouldReturnEmtpyArray()
        {
            double[] result = calc.Stack();

            result.Should().BeEmpty();
        }
```

22. The new test fails as we want it to, let's fix it. What is the simplest way? Just return an empty array! Replace your implementation with the following. Test your solution.

```csharp
        public double[] Stack()
        {
            return new double[0];
        }
```

23. Anything we can make better or refactor? Not much, let's continue with the following test. Implement it and test your solution.

```csharp
        [Fact]
        public void Stack_PushedValues_ShouldReturnAnArrayWithThePushedValues()
        {
            calc.Push(1);
            calc.Push(2);
            calc.Push(3);

            double[] result = calc.Stack();

            result.Should().BeEquivalentTo(1, 2, 3);
        }
```

24. As expected the new test fails :-) And we are happy since we can fix something. This time the implementation isn't as obvious or simple but the sneaky way we can fix this test is actually by doing this in our implementation. Update your implementation accordingly and test your solution.

```csharp
        public double[] Stack()
        {
            if (lastValue != 0)
                return new double[]{1, 2, 3};
            
            return new double[0];
        }
```

25. At this point you might think that we are cheating, but we are really not. The implementation doesn't have to be more complex in order to meet the requirements. The unit tests are too simple or too few. So let's continue add another few unit tests by making our previous unit test into a parameterized one. Change the implementation of the last test as following and then test your solution again.

```csharp
        [Theory]
        [InlineData(1, 2, 3, 1, 2, 3)]
        [InlineData(4, 5, 6, 4, 5, 6)]
        [InlineData(7, 8, 9, 7, 8, 9)]
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

25. By doing this change of our test, we actually implemented 2 additional tests. The ones where we push 4, 5 & 6 and another test where we push 7, 8 & 9. This good news again. Tests are failing and this time it's two of them (the two last parameterized versions of our last test). So we are allowed to code.

> You might thing that the test is overly complicated done since we are creating parameters for both the pushed values and the expected values even though they are always expected to be the same. In tests it's a good practice not to reuse parameters with values for the expected result since we want to be very explicit of what the effect of executing this test should be. But this test would work equally good if we re-used v1, v2 and V3 instead of introducing expectedV1, expectedV2 and expected V3.

26. Now we are getting to a point where there is starting to get hard to cheat with the implementation, or that a correct implementation actually is the most easy way to fix our failing unit tests. So let's change our implementation to the following. Build and test once you are done.

```csharp
using System;
using System.Collections.Generic;

namespace EF2.UnitTesting
{
    public class RpnCalculator
    {
        Stack<double> internalStack = new Stack<double>();

        public double Result()
        {
            return internalStack.Peek();
        }

        public void Push(double v)
        {
            internalStack.Push(v);
        }

        public double[] Stack()
        {
            return internalStack.ToArray();
        }
    }
}
```

27. The above implementation is probably what many developers would come up with without too much trouble. The problem now is that we did miss one of the requirements and the Unit Tests (or one of them) are showing us what we missed. As we execute the tests we can see the below message and it tells us that we missed to implement the use case when a stack is zero and what should happen then:

```
[xUnit.net 00:00:00.67]     EF2.UnitTesting.Tests.RpnCalculatorTests.Result_EmptyCalc_ShouldReturnZero [FAIL]                                                                    
  X EF2.UnitTesting.Tests.RpnCalculatorTests.Result_EmptyCalc_ShouldReturnZero [2ms]                                                                                             
  Error Message:
   System.InvalidOperationException : Stack empty.
  Stack Trace:
     at System.Collections.Generic.Stack`1.ThrowForEmptyStack()
   at System.Collections.Generic.Stack`1.Peek()
   at EF2.UnitTesting.RpnCalculator.Result() in /Users/kristofer/ef2/src/EF2.UnitTesting/RpnCalculator.cs:line 12
   at EF2.UnitTesting.Tests.RpnCalculatorTests.Result_EmptyCalc_ShouldReturnZero() in /Users/kristofer/ef2/src/EF2.UnitTesting.Tests/RpnCalculator.Tests.cs:line 20                                          
```

28. Time to feel greatful again, the Unit Tests has saved us from missing that important requirement and we can implement it as below. Test your solution once you are done.

```csharp
        public double Result()
        {
            if (internalStack.Count == 0)
                return 0;
                
            return internalStack.Peek();
        }
```

29. Perfect all tests are successful again and we can describe another requirement. Implement the following test and let Visual Studio Code help you implement the missing `Pop()` method. Build and test once you are done.

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

30. The new test fails, so let's fix it. Test when done.

```csharp
        public void Pop()
        {
            internalStack.Pop();
        }
```

> Reminder: Don't forget to look for opporunities to refactor your code and make it easier.

31. That was an easy implementation, let's continue with the test. Build and test when done.

```csharp
        [Fact]
        public void Pop_WithEmptyCalc_ShouldThrowException()
        {
            calc.Pop();
        }
```

32. The above unittest actually fails, even though Pop actually throws an exception. The problem is that we haven't told the Unit Testing Framework that we do expect an exception here. In this tutorial we are using the package called FluentAssertions to make our "assertions" a bit easier. Luckily for us FluentAssertions contain an easy way for us to test for exceptions as well. Tweak the test implementation to the following. Test when done.

```csharp
        [Fact]
        public void Pop_WithEmptyCalc_ShouldThrowException()
        {
            Action act = () => calc.Pop();

            act.Should().Throw<InvalidOperationException>();
        }
```

33. Since we do like Unit Tests that fail, we feel a bit sad since the above unit test actually succeeds, meaning we didn't test anything that wasn't already implemented. It turns out that our `internalStack` that we are using will throw an exception for us, so we don't need to implement anything else.

34. Implement the following test and let Visual Studio Implement the missing `Clear` method. Test when done.

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

35. Fix the new failing test with the following implementation:

```csharp
        public void Clear()
        {
            internalStack.Clear();
        }
```

> We are getting up to speed! From now on the instructions will not tell you to build and/or test your code. Whenever you implement a new test och change your implementation, you should do that by default.

> You should also let Visual Studio Code implement any new/missing methods for you as we go on.

> We haven't forgotten that we should look out for refactoring opportunities, right?

36. New tests for the Add method

```csharp
        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(-1, -2, -3)]
        [InlineData(0, 0, 0)]
        public void Add_WithTwoPushedValues_ShouldCalculateSum(double v1, double v2, double expectedResult)
        {
            calc.Push(v1);
            calc.Push(v2);
            
            calc.Add();

            calc.Result().Should().Be(expectedResult);
        }
```

> As said above, don't forget to test your solution and make sure you have failing tests before you go on with the implementation.

37. Implementation of the Add method

```csharp
        public void Add()
        {
            var v1 = internalStack.Pop();
            var v2 = internalStack.Pop();

            var result = v1 + v2;
            
            internalStack.Push(result);
        }
```

38. So is it ok to implement more than one Unit Test at a time? Yes it is, in fact that was what we just did since we implemented our test as a `Theory`. Just remember to always try and solve the failing unit tests as easy/lazy as you possible can. So let's go ahead and add the test for the three other common math operators.

```csharp

        [Theory]
        [InlineData(2, 1, 1)]
        [InlineData(10, -20, -10)]
        [InlineData(5, 0, 5)]
        public void Sub_WithTwoPushedValues_ShouldCalculateDifference(double v1, double v2, double expectedResult)
        {
            calc.Push(v1);
            calc.Push(v2);
            
            calc.Sub();

            calc.Result().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(0, 5, 0)]
        [InlineData(-5, -5, 25)]
        public void Mul_WithTwoPushedValues_ShouldCalculateProduct(double v1, double v2, double expectedResult)
        {
            calc.Push(v1);
            calc.Push(v2);
            
            calc.Mul();

            calc.Result().Should().Be(expectedResult);
        }

        [Theory]
        [InlineData(2, 2, 1)]
        [InlineData(9, 2, 4.5)]
        [InlineData(-5, 2, -2.5)]
        public void Div_WithTwoPushedValues_ShouldCalculateQuotient(double v1, double v2, double expectedResult)
        {
            calc.Push(v1);
            calc.Push(v2);
            
            calc.Div();

            calc.Result().Should().Be(expectedResult);
        }
```

39. If everything worked we should now have 9 Unit Tests that fails (3x3 parameterized tests), so this is our lucky day. We have a lot to implement.

```csharp
        public void Sub()
        {
            var v1 = internalStack.Pop();
            var v2 = internalStack.Pop();

            var result = v2 - v1;

            internalStack.Push(result);
        }

        public void Mul()
        {
            var v1 = internalStack.Pop();
            var v2 = internalStack.Pop();

            var result = v1 * v2;

            internalStack.Push(result);
        }

        public void Div()
        {
            var v1 = internalStack.Pop();
            var v2 = internalStack.Pop();

            var result = v2 / v1;

            internalStack.Push(result);
        }
```

40. That's awesome we now have 23 unit tests that succeed. BTW, have you noticed any repeating patterns that we could refactor? Indeed if we look into our implementation it looks a lot like if we are repeating ourselves over and over again with the different operators. But since we are in a `green` state we are ok and safe to do refactoring of our code, so let's add a new private method and change the implementation of our methods `Add()`, `Sub()`, `Mul()` and `Div()`. Here is the whole new imlementation of our calculator.

```csharp
using System;
using System.Collections.Generic;

namespace EF2.UnitTesting
{
    public class RpnCalculator
    {
        Stack<double> internalStack = new Stack<double>();

        public double Result()
        {
            if (internalStack.Count == 0)
                return 0;

            return internalStack.Peek();
        }

        public void Push(double v)
        {
            internalStack.Push(v);
        }

        public double[] Stack()
        {
            return internalStack.ToArray();
        }

        public void Pop()
        {
            internalStack.Pop();
        }

        public void Clear()
        {
            internalStack.Clear();
        }

        public void Add()
        {
            ExecuteTwoValueOperator((v1, v2) =>  v1 + v2);
        }

        public void Sub()
        {
            ExecuteTwoValueOperator((v1, v2) =>  v2 - v1);
        }

        public void Mul()
        {
            ExecuteTwoValueOperator((v1, v2) =>  v1 * v2);
        }

        public void Div()
        {
            ExecuteTwoValueOperator((v1, v2) =>  v2 / v1);
        }

        private void ExecuteTwoValueOperator(Func<double, double, double> op)
        {
            double v1 = internalStack.Pop();
            double v2 = internalStack.Pop();

            var result = op(v1, v2);

            internalStack.Push(result);
        }
    }
}
```

41. Even though we made quite big changes, we can feel safe that we didn't break anything since the Unit Tests are still working. Let's add one of the last tests.

```csharp
        [Theory]
        [InlineData(100, 10)]
        [InlineData(9, 3)]
        [InlineData(0, 0)]
        public void Sqrt_SinglePushedValue_ShouldCalculateSquareRoot(double v, double expectedResult)
        {
            calc.Push(v);

            calc.Sqrt();

            calc.Result().Should().Be(expectedResult);
        }
```

42. And the implementation

```csharp
        public void Sqrt()
        {
            double v = internalStack.Pop();

            var result = Math.Sqrt(v);

            internalStack.Push(result);
        }
```

43. And we are almost done, there are a few more things that could be implemented but that will be up to you to do on your own. Things you can have a look at:

    * What happens if a math operator doesn't have enough pushed values on the stack?
    * What if you divide by zero?
    * Can you create a test that proves that a complex calculation work, like the one given in the beginning ((4+6) / (7-2) + 8) x 10 = 100?

Thank you for being patient and going through this step by step. As you get more and more proficient in Test Driven Development, you might skip a step here and there, but perhaps adding a bit more complex tests or by using parameterized unit tests more often, but over all this is how Test Driven Development is done. You drive an implementation by being the first tester of your own code and the result is 100% tested code that you can be very proud of.

-- The End --
