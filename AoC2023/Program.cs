﻿// See https://aka.ms/new-console-template for more information


using AoC2023.Day1;
using AoC2023.Helpers;

var sessionId = "53616c7465645f5ff9bbf90355d83d2afb839bfaff8059a3e85fabd70f26af0260fa841df8f6948133ca14aa6e6385000b7f8be2df0c2a24ab62a5f38cb99a2a";

var dataDay1 = await InputHelper.GetDataLines(1, sessionId);

var day1 = new Day1();

Console.WriteLine($"Day 1 - part 1: result {day1.ResolvePart1(dataDay1)}");
Console.WriteLine($"Day 1 - part 2: result {day1.ResolvePart2(dataDay1)}");

