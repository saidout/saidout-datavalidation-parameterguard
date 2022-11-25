
# SaidOut.DataValidation.ParameterGuard [![NuGet Version](https://img.shields.io/nuget/v/SaidOut.DataValidation.ParameterGuard.svg?style=flat)](https://www.nuget.org/packages/SaidOut.DataValidation.ParameterGuard/)
Parameter guards for .NET that checks that a parameter meets the requirements and throws an `ArgumentException` if it doesn't.


---
## Table of Content
 * [Classes](#classes)
   * [SaidOut.DataValidation.ParameterGuard.Extensions.CollectionExtension](#collectionextension)
   * [SaidOut.DataValidation.ParameterGuard.Extensions.ComparableExtension](#comparableextension)
   * [SaidOut.DataValidation.ParameterGuard.Extensions.GeneralExtension](#generalextension)
   * [SaidOut.DataValidation.ParameterGuard.Extensions.StringExtension](#stringextension)
   * [SaidOut.DataValidation.ParameterGuard.GuardHelper](#guardhelper)

---
## Classes
 * [SaidOut.DataValidation.ParameterGuard.Extensions.CollectionExtension](#collectionextension) Parameter guards for collection parameters.
 * [SaidOut.DataValidation.ParameterGuard.Extensions.ComparableExtension](#comparableextension) Check a parameter against lower and upper boundaries.
 * [SaidOut.DataValidation.ParameterGuard.Extensions.GeneralExtension](#generalextension) Parameter guards for class and enum parameters.
 * [SaidOut.DataValidation.ParameterGuard.Extensions.StringExtension](#stringextension) Parameter guards for string parameters.
 * [SaidOut.DataValidation.ParameterGuard.GuardHelper](#guardhelper) Helper class that compare `paramX` against `paramY`.

All extensions methods that beings with `Check...` also return the parameter value being checked.  
This makes it possible in constructor to check and assign parameters in one statement.  

Example
```cs
    public class Person
    {
        public Person(int age, ...)  
        {  
            Age = age.CheckIsEqualOrGreaterThan(0);  
            ...  
        }  
  
        public int Age { get; }  
        ...
    }  
```

---
### CollectionExtension
Parameter guards for collection parameters.

| Name | Description |
|--------|-------------|
| `CheckIsNotNullOrEmpty` | Will throw an exception if `paramValue` is null or empty.

Example
```cs
    public void MethodA(IEnumerable<string> data)  
    {  
        data.CheckIsNotNullOrEmpty();  
        ...  
    }  
```

---
### ComparableExtension
Check a parameter against lower and upper boundaries.

| Name | Description |
|--------|-------------|
| `CheckIsInsideRange` | Will throw an exception if `paramValue` is outside the range [`lowerBound`, `upperBound`]. |
| `CheckIsGreaterThan` | Will throw an exception if `paramValue` is equal or less than `lowerBound`. |
| `CheckIsEqualOrGreaterThan` | Will throw an exception if `paramValue` is less than `lowerBound`. |
| `CheckIsLessThan` | Will throw an exception if `paramValue` is equal or greater than `upperBound`. |
| `CheckIsEqualOrLessThan` | Will throw an exception if `paramValue` is greater than `upperBound`. |

Example
```cs
    public void MethodA(int guess, int age)  
    {  
        guess.CheckIsInsideRange(0, 100);  
        age.CheckIsEqualOrGreaterThan(0);
        ...  
    }  
```


---
### GeneralExtension
Parameter guards for class and enum parameters.

| Name | Description |
|--------|-------------|
| `CheckIsNotNull` | Will throw an exception if `paramValue` is null. |
| `CheckIsDefinedInEnum` | Will throw an exception if `paramValue` is not a defined value for the enum type `TEnum`. |
| `CheckIsInWhitelist` | Will throw an exception if `paramValue` is not in the `whitelist`. |

Example
```cs
    public Ctor(CustomData data, TestEnum val, string input)  
    {  
        _data = data.CheckIsNotNull();  
        _val = val.CheckIsDefinedInEnum();  
        _input = input.CheckIsInWhitelist(/* whitelist = */ new[] { "ab", "ef", "hf" });  
        ...  
    }  
```


---
### StringExtension
Parameter guards for string parameters.

| Name | Description |
|--------|-------------|
| `CheckIsNotNullOrBlank` | Will throw an exception if `paramValue` is null or a blank string. |
| `CheckMatchRegexPattern` |Will throw an exception if `paramValue` does not match the `regexPattern`. |
| `CheckIsHexString` | Will throw an exception if `paramValue` is not an hex string representing a byte array with number of bytes in the range [`minByteSize`, `maxByteSize`]. |

Example
```cs
    public void MethodA(string nonBlankInput, string hexValA, string hexValB, string hexValC)  
    {  
        nonBlankInput.CheckIsNotNullOrBlank();  
        hexValA.CheckMatchRegexPattern();  
        // The hex string byte size representation of hexValB should be 10 or greater  
        hexValB.CheckIsHexString(10);  
        // The hex string byte size representation of hexValC should be in the range [5, 15]  
        hexValC.CheckIsHexString(5, 15);  
        ...  
    }  
```


---
### GuardHelper
Helper class that compare `paramX` against `paramY`.

| Name | Description |
|--------|-------------|
| `ThrowIfParamXIsLessThanParamY` | Will throw an exception if `paramX` is less than `paramY`. |
| `ThrowIfParamXIsEqualOrLessThanParamY` | Will throw an exception if `paramX` is equal or less than `paramY`. |
| `ThrowIfParamXIsGreaterThanParamY` | Will throw an exception if `paramX` is greater than `paramY`. |
| `ThrowIfParamXIsEqualOrGreaterThanParamY` | Will throw an exception if `paramX` is equal or greater than `paramY`. |

Example
```cs
    public void MethodA(int minValue, int maxValue)  
    {  
        GuardHelper.ThrowIfParamXIsGreaterThanParamY(minValue, maxValue)
        ...  
    }  
```
