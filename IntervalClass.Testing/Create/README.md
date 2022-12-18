# Interval creation testing

## Designations

|Designation|Meaning|
|:-:|:-:|
|`-Inf`|`double.NegativeInfinity`|
|`+Inf`|`double.PositiveInfinity`|
|`NaN`|`double.NaN`|
|`<number>`|common number|
|`<number1>, <number2>`|common numbers & `number1` is less or equals than `number2`|

## The tests guaranteed behavior

### Creating intervals without arguments 
|Result|
|:-:|
|`Interval.Empty`|

### Creating intervals with only one argument
|Argument|Result|
|:-:|:-:|
|`NaN`|`IntervalClassException`|
|`+Inf`|`IntervalClassException`|
|`-Inf`|`IntervalClassException`|
|`<number>`|`[<number>, <number>]`|

### Creating intervals by two arguments
|Argument 1|Argument 2|Result|
|:-:|:-:|:-:|
|`NaN`|`NaN`|`IntervalClassException`|
|`NaN`|`-Inf`|`IntervalClassException`|
|`NaN`|`+Inf`|`IntervalClassException`|
|`NaN`|`<number>`|`IntervalClassException`|
|`-Inf`|`NaN`|`IntervalClassException`|
|`-Inf`|`-Inf`|`IntervalClassException`|
|`-Inf`|`+Inf`|`[-Inf, +Inf]`|
|`-Inf`|`<number>`|`[-Inf, <number>]`|
|`+Inf`|`NaN`|`IntervalClassException`|
|`+Inf`|`-Inf`|`IntervalClassException`|
|`+Inf`|`+Inf`|`IntervalClassException`|
|`+Inf`|`<number>`|`IntervalClassException`|
|`<number>`|`NaN`|`IntervalClassException`|
|`<number>`|`-Inf`|`IntervalClassException`|
|`<number>`|`+Inf`|`[<number>, +Inf]`|
|`<number>`|`<number>`|`[<number>, <number>]`|
|`<number1>`|`<number2>`|`[<number1>, <number2>]`|
|`<number2>`|`<number1>`|`IntervalClassException`|
