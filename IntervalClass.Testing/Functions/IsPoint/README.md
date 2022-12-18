# Testing IsPoint function

## Designations

|Designation|Meaning|
|-|-|
|`-Inf`|`double.NegativeInfinity`|
|`+Inf`|`double.PositiveInfinity`|
|`NaN`|`double.NaN`|
|`<number>`|common number|
|`<number1>, <number2>`|common numbers & `number1` is less or equal than `number2`|

## The tests guaranteed behavior

|Argument|Result|
|-|-|
|`Empty`|`False`|
|`[0, +Inf]`|`False`|
|`[-Inf, 0]`|`False`|
|`[-Inf, +Inf]`|`False`|
|`[<number1>, <number2>]`|`False`|
|`[<number>, <number>]`|`True`|
