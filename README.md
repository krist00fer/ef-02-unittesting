# Engineering Fundamentals Lightning Hack 2 - Unit Testing

> This repository and its content is meant to be used as a continuation of a leader lead training. 

Unit Testing is, or should be, a fundamental part of any software engineering projects. But in order to even have a discussion around if we need Unit Testing or not, we need to come to a common ground about what it is and what it isn’t. We need to understand how code look like that actually enables us to unit test it, because not all code does.

One of the better ways to learn what Unit Testing is write code using a methodology called Test Driven Development, TDD. Please notice that TDD and Unit Testing isn’t at all synonyms and shouldn’t be used as such. Just because you’ve written Unit Tests doesn’t mean you implement a TDD approach and even if you use TDD (incorrectly), you might end up with tests that doesn’t follow the convention of being Unit Tests.

Perhaps a bold statement, but this exercise will use the TDD approach to force you to think of Unit Tests “in the right way” and hopefully some will find that TDD is the way to go in many projects to come. Others might think that TDD isn’t for me and that will also be an accepted outcome, but the goal of this exercise is to have everyone agree upon what Unit Testing is and how it can be used to drive testable code by using TDD.

## Setting up your environment

> This training will use .NET Core and C# but almost any programming language and tools will work. If you decide to go with another programming language the same principles apply and you should try to follow the instructions given none the less. A unit test is the same in all programming languages and Test Drivven Development doesn't demand you to use any specific language or tool.

> All examples are based on .NET Core version 2.2.300. Check your own version by executing `dotnet --version` from a terminal window of your choice

Execute the below statements to create a new .NET Core solution with two projects in the folder of your choice.

```bash
# Create a folder for your solution
mkdir ef2
cd ef2

# Create the .NET Core Solution
dotnet new sln --name EF2.UnitTesting

# Create Class Library to hold implementation and add to solution
dotnet new classlib --output src/EF2.UnitTesting/
dotnet sln add src/EF2.UnitTesting/

# Create Unit Test Project using the Xunit template and add to solution
dotnet new xunit --output src/EF2.UnitTesting.Tests/
dotnet sln add src/EF2.UnitTesting.Tests/

# Add references needed
dotnet add src/EF2.UnitTesting.Tests/ reference src/EF2.UnitTesting/
dotnet add src/EF2.UnitTesting.Tests/ package FluentAssertions
```

After that is done you should end up with a folder structure like this or very similar:

```
.
├── EF2.UnitTesting.sln
└── src
    ├── EF2.UnitTesting
    │   ├── Class1.cs
    │   └── EF2.UnitTesting.csproj
    └── EF2.UnitTesting.Tests
        ├── EF2.UnitTesting.Tests.csproj
        └── UnitTest1.cs
```

> I've omitted the folders named `obj` and they included files in the above tree structure. The files in the `obj` folder is used by the .NET Core tooling and doesn't provide any additional value to us right now, so just ignore them.

Make sure you can build your solution by executing:

```
dotnet build
```

... and make sure also are able to test your project by executing:

```
dotnet test
```

You should be greeted with a message similar to this

```
Test run for .../src/EF2.UnitTesting.Tests/bin/Debug/netcoreapp2.2/EF2.UnitTesting.Tests.dll(.NETCoreApp,Version=v2.2)
Microsoft (R) Test Execution Command Line Tool Version 16.1.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
                                                                                                                                                                                 
Test Run Successful.
Total tests: 1
     Passed: 1
 Total time: 1.0512 Seconds

```

> The Xunit template that we used to create our Unit Testing project puts a sample test in there for us to have a look at. That's why you see one test that has been executed successfully.

## The challenge

You are asked to create a re-usable library and class that implement the features of a sk. Reverse Polish Notation Calculator, RPN Calculator, a type of calculator that some of you might have been exposed to if you ever bought a calculator from HP. 

Normal notation would write:

1 + 2 

While in Reverse Polish Notation you would write:

1 2 +

I.e. you first state what the values are and then what operator to apply.

> Internally most of the implementation of such calculator will use a collection called a “stack”. A stack has the ability to push information to it and then retrieve values by issuing a pop. Think of it as a pile of papers on your desk. Let’s say you “push” a paper with the letter A onto the “stack” of papers, then you “push” another paper whit the letter B onto the same “stack” of papers. Later on you can take or “pop” the paper on the top and you’ll retrieve the paper marked B. Next time you “pop” another paper from the “stack” you’ll receive the paper with an A on. It’s quite common to refer to these kind of behavior in a "queue" or "collection" as “First In, Last Out”.

Since our calculator will be a RPN Calculator it should have the same behavior, so you'll first "push" the values you want to operate on. When you later apply an operator, like “add”, “subtract”, “multiply”, “divide”, “square root”, etc. the internals of the calculator should “pop” the correct number of needed values to correctly execute the calculation. This in turn means that in order to execute an “add” operation, there need to be at least two numbers pushed to the calculator, while a “square root” operation would only need a single number.

The result of any successful operation should be pushed back to the calculator’s internal “stack” so that it can get used again for later calculations.

### Exampe: 1 + 2 = 3
```
Push 1
Push 2
Add
Show Result = 3
```

### Example: (1 + 5) x 3 = 18
```
Push 1
Push 5
Add
Push 3
Multiply
Show Result = 18
```

### Example: ((4+6) / (7-2) + 8) x 10 = 100
```
Push 4
Push 6
Add
Push 7
Push 2
Subtract
Divide
Push 8
Add
Push 10
Multiply
Show Result = 100
```
(Click [here](docs/example-details.md) for a detailed walk through of the internals of our calculator during this example)

## Time to decide what kind of challenge level-you want

### [Hard](docs/instructions-hard.md)

If you are used to writing code and feel that you grasp the context of Test Driven Development, then this is the level for you. Click [here](docs/instructions-hard.md) for your instructions.

### [Medium](docs/instructions-medium.md)

If you feel that you've been writing quite some code and have some understanding on what Unit Testing means, but never have tried Test Driven Development, then this is the level for you. Click [here](docs/instructions-medium.md) for your instructions.

### [Easy](docs/instructions-easy.md)

If you don't feel comfortable writing code or this is the first time you see Unit Tests, then this is the level that will get you through the exercise. Click [here](docs/instructions-easy.md)
