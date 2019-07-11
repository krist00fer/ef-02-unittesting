# Challenge Instructions - Hard

## Requirements
Create a RPN Calculator Class according to what was descibed earlier using *Test Driven Development*. The calculator should support the following operators:

Calculator Methods

* Push - Adds a value to the calculators stack
* Pop - Removes the last pushed value from the calculators stack
* Peak - Returns the last pushed value from the stack without removing it. Can be used to look at the result
* Stack - Returns a list of values representing the current internal stack
* Clear - Cleans the internal state of our calculator

Math Methods

* Add - Adds the two latest values pushed. `Push 2, Push 3 (add) -> 5`
* Sub - Subtracts the latest value pushed from the second last value pushed. `Push 5, Push 3, (sub) -> 2`
* Mul - Multiplies the two latest values pushed. `Push 2, Push 3, (mul) -> 6`
* Div - Divides the the second last value pushed by the last value pushed. `Push 5, Push 2, (div) -> 2.5`
* Sqrt - Calculates the square root of the last value pushed. `Push 9, (sqrt) -> 3`

Add 3 or more addional math methods of your own chosing

## Rules of engagement

1. *NO CODE SHOULD BE WRITTEN OR CHANGED BEFORE THERE IS A UNIT TEST THAT FAILS!*
2. To solve a failing unit test, *ONLY WRITE THE MINIMAL AMOUNT OF CODE NEEDED* to fix the failing Unit Test. Don't think ahead on what would be a good implementation until you have enough Unit Tests that demand you to make a proper implementation.
3. Don't cheat on rule 1.
4. Don't cheat on rule 2.

> By looking at the specification above, we kind of understand that we somehow need some kind of stack, but how many unit tests do you actually need to write before a proper "stack" is the simplest implementation? Challenge yourself to not jump to conclusions, but be almost "stupidly" simple when you fix your failing unit tests.

## When you are done

Make sure your code is available in a public GitHub repository and ask your instructor for a code review.

## Can I get another challenge?

Your instructor will have additional challenges for you as soon as you are done