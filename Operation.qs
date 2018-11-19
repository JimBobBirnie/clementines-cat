namespace ClementinesCat
{
    open Microsoft.Quantum.Canon;
    open Microsoft.Quantum.Primitive;

    operation MeasureCatMood () : (Result, Result, Result, Result) {
        body {
            mutable result = (Zero, Zero, Zero, Zero);
            // The following using block creates a pair of fresh qubits and initializes it in |00〉.
            using(qubits = Qubit[4]) {

                //There are 4 qubits. One per member of the family so the 4 Qubits represent
                //James, Josie, Clementine and Felicity

                // By applying the Hadamard operator to each of the qubits we create state
                // 1/2(|00〉+|01〉+|10〉+|11〉). 
                ApplyToEach(H, qubits); 

                //So now each qubit represents a 50% chance that the specified human will be 
                //persuaded to feed the cat.
                //When the cat eats, she immediately forgets she has eaten 
                //(but remmebers which human she already asked to feed her)
                //so she asks a different human to feed her
               
                // We now assert that the probability for the events of finding the first qubit 
                // in state |0〉 upon measurement in the standard basis is $1/2$. Note that this 
                // assertion does not actually apply the measurement operation itself, i.e., it
                // has no side effect on the state of the qubits.
                AssertProb(
                    [PauliZ], [qubits[0]], Zero, 0.5, 
                    "Error: Outcomes of the measurement must be equally likely", 
                    1e-5
                );
                // We now assert that the probability for the events of finding the second 
                // qubit in state |0〉 upon measurement in the standard basis is $1/2$. 
                AssertProb(
                    [PauliZ], [qubits[1]], Zero, 0.5, 
                    "Error: Outcomes of the measurement must be equally likely", 
                    1e-5
                );

                // We now assert that the probability for the events of finding the third 
                // qubit in state |0〉 upon measurement in the standard basis is $1/2$. 
                AssertProb(
                    [PauliZ], [qubits[2]], Zero, 0.5, 
                    "Error: Outcomes of the measurement must be equally likely", 
                    1e-5
                );

                // We now assert that the probability for the events of finding the third 
                // qubit in state |0〉 upon measurement in the standard basis is $1/2$. 
                AssertProb(
                    [PauliZ], [qubits[3]], Zero, 0.5, 
                    "Error: Outcomes of the measurement must be equally likely", 
                    1e-5
                );

                // Now, we measure each qubit in Z-basis and immediately reset the qubits 
                // to zero, using the canon operation MResetZ.
                set result = (MResetZ(qubits[0]), MResetZ(qubits[1]), MResetZ(qubits[2]), MResetZ(qubits[3]));	

                //so if the result is One, she got fed by that human, if Zero she didn't


            }
            // Finally, we return the result of the measurement. 
            return result;
        }
    }
    // operation CatMoodExperiment(count: Int) : (Int){
    //     body {
    //         return 0;
    //     }
    // }

    // operation CatMoodExperiment(count: Int) : (Int){
    //     body {
    //         mutable happyCatCount = 0;
    //         mutable sadCatCount = 0;
    //         for (test in 1..count){

    //         }
    //         return 0;
    //     }
    // }

    // operation CatMoodExperiment(count: Int) : (Int){
    //     body {
    //         mutable happyCatCount = 0;
    //         mutable sadCatCount = 0;
    //         for (test in 1..count){

    //         }
    //         return 0;
    //     }
    // }

    //   operation CatMoodExperiment(count: Int) : (Int, Int){
    //     body {
    //         mutable happyCatCount = 0;
    //         mutable sadCatCount = 0;
    //         for (test in 1..count){
    //             using(humans = Qubit[4]) {
    //                 ApplyToEach(H, humans); 
    //                 ResetAll(humans);
    //             }
    //         }
    //         return (happyCatCount, sadCatCount);
    //     }
    // }

    operation CatMoodExperiment(count: Int) : (Int, Int){
        body {
            mutable happyCatCount = 0;
            mutable sadCatCount = 0;
            for (test in 1..count){
                using(humans = Qubit[4]) {
                    ApplyToEach(H, humans); 
                    mutable numberOfHumansThatFedTheCat = 0;
                    for(human in 0..3){
                        let state = M(humans[human]);
                        if (state == One){
                            set numberOfHumansThatFedTheCat = numberOfHumansThatFedTheCat + 1;
                        }
                    }
                    ResetAll(humans);
                    if (numberOfHumansThatFedTheCat >= 2){
                        set happyCatCount = happyCatCount + 1;
                    }
                    else {
                        set sadCatCount = sadCatCount + 1;
                    }
                }
            }
            return (happyCatCount, sadCatCount);
        }
    }

    operation WhoFedTheCat() : (Bool, Bool, Bool, Bool){
        body{
            mutable jamesFedTheCat = false;
            mutable josieFedTheCat = false;
            mutable clementineFedTheCat = false;
            mutable felicityFedTheCat = false;
            using(humans = Qubit[4]) {
                ApplyToEach(H, humans);
                let state0 = M(humans[0]);
                set jamesFedTheCat = state0 == One;

                let state1 = M(humans[1]);
                set josieFedTheCat = state1 == One;

                let state2 = M(humans[2]);
                set clementineFedTheCat = state2 == One;

                let state3 = M(humans[3]);
                set felicityFedTheCat = state3 == One;

                ResetAll(humans);
            }
            return (jamesFedTheCat, josieFedTheCat, clementineFedTheCat, felicityFedTheCat);
        }
    }

}
