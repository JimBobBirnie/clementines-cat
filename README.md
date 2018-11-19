# clementines-cat
This is my first quantum code.

I created this project to demonstrate very simple use of quantum gate programming.

It illustrates using the H gate to create superposition and it illustrates two different paradigms to running quantum code. 

CatMoodExperiment iterates in the Q# code and runs the same experiment N times and reports the counts of the different results. This is supposed to illustrate some kind of forecast like application where you run your simulation a nnumber of times to try to understand the most likely outcome.

WhoFedTheCat iterates outside of the C# code and outputs the result of each experiment inline. This is illustrating the strategy for an optimisation type problem where you run the quantum code, get a result and then try different inputs to see if you get a better result.

# Prerequisites

You need to have installed the Microsoft Quantum Development Kit. This is available from
https://www.microsoft.com/en-us/quantum/development-kit

# building and running

dotnet build

dotnet run

