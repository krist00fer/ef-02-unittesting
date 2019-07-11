### Example Details


> The below example illustrates a stack as a vertical list of values where new values are pushed to the bottom of the list. This is to align to how old HP calculators illustrated the stack, i.e. by adding new values on the bottom.

These are the steps needed to solve the below equation using a RPN Calculator with details how the internal stack of the calculator would look before and after each operation.

```
((4+6) / (7-2) + 8) x 11 = 110
```

| Stack before operation     | Operation                    | Stack after operation   |
| -------------------------- | ---------------------------- | ----------------------- |
| &nbsp;<br>&nbsp;<br>&nbsp; | &nbsp;<br>&nbsp;<br>Push 4   | &nbsp;<br>&nbsp;<br>4   |
| &nbsp;<br>&nbsp;<br>4      | &nbsp;<br>&nbsp;<br>Push 6   | &nbsp;<br>4 <br> 6      |
| &nbsp;<br>4 <br> 6         | &nbsp;<br>&nbsp;<br>Add      | &nbsp;<br>&nbsp;<br>10  |
| &nbsp;<br>&nbsp;<br>10     | &nbsp;<br>&nbsp;<br>Push 7   | &nbsp;<br>10<br>7       |
| &nbsp;<br>10<br>7          | &nbsp;<br>&nbsp;<br>Push 2   | 10<br>7<br>2            |
| 10<br>7<br>2               | &nbsp;<br>&nbsp;<br>Subtract | &nbsp;<br>10<br>5       |
| &nbsp;<br>10<br>5          | &nbsp;<br>&nbsp;<br>Divide   | &nbsp;<br>&nbsp;<br>2   |
| &nbsp;<br>&nbsp;<br>2      | &nbsp;<br>&nbsp;<br>Push 8   | &nbsp;<br>2<br>8        |
| &nbsp;<br>2<br>8           | &nbsp;<br>&nbsp;<br>Add      | &nbsp;<br>&nbsp;<br>10  |
| &nbsp;<br>&nbsp;<br>10     | &nbsp;<br>&nbsp;<br>Push 11  | &nbsp;<br>10<br>11      |
| &nbsp;<br>10<br>11         | &nbsp;<br>&nbsp;<br>Multiply | &nbsp;<br>&nbsp;<br>110 |
| &nbsp;<br>&nbsp;<br>110    | &nbsp;<br>&nbsp;<br>Result   | &nbsp;<br>&nbsp;<br>110 |
