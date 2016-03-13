﻿module OctalTests

open NUnit.Framework
open Octal

type OctalTests() =
    
    [<TestCase("1", ExpectedResult = 1)>]
    [<TestCase("10", ExpectedResult = 8)>]
    [<TestCase("17", ExpectedResult = 15)>]
    [<TestCase("11", ExpectedResult = 9)>]
    [<TestCase("130", ExpectedResult = 88)>]
    [<TestCase("2047", ExpectedResult = 1063)>]
    [<TestCase("7777", ExpectedResult = 4095)>]
    [<TestCase("1234567", ExpectedResult = 342391)>]
    member tests.Octal_converts_to_decimal(input) =
        Octal(input).toDecimal()

    [<TestCase("carrot")>]
    [<TestCase("8")>]
    [<TestCase("9")>]
    [<TestCase("6789")>]
    [<TestCase("abc1z")>]
    member tests.Invalid_octal_is_decimal_0(input) =
        Assert.That(Octal(input).toDecimal(), Is.EqualTo(0))