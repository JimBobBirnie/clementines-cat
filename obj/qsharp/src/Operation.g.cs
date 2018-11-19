#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("ClementinesCat", "MeasureCatMood () : (Result, Result, Result, Result)", new string[] { }, "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs", 172L, 6L, 68L)]
[assembly: OperationDeclaration("ClementinesCat", "CatMoodExperiment (count : Int) : (Int, Int)", new string[] { }, "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs", 4550L, 112L, 57L)]
[assembly: OperationDeclaration("ClementinesCat", "WhoFedTheCat () : (Bool, Bool, Bool, Bool)", new string[] { }, "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs", 5578L, 139L, 56L)]
#line hidden
namespace ClementinesCat
{
    public class MeasureCatMood : Operation<QVoid, (Result,Result,Result,Result)>
    {
        public MeasureCatMood(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Canon.ApplyToEach<>), typeof(Microsoft.Quantum.Primitive.AssertProb), typeof(Microsoft.Quantum.Primitive.H), typeof(Microsoft.Quantum.Canon.MResetZ), typeof(Microsoft.Quantum.Primitive.Release) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected Allocate Allocate
        {
            get
            {
                return this.Factory.Get<Allocate, Microsoft.Quantum.Primitive.Allocate>();
            }
        }

        protected ICallable MicrosoftQuantumCanonApplyToEach
        {
            get
            {
                return new GenericOperation(this.Factory, typeof(Microsoft.Quantum.Canon.ApplyToEach<>));
            }
        }

        protected ICallable<(QArray<Pauli>,QArray<Qubit>,Result,Double,String,Double), QVoid> AssertProb
        {
            get
            {
                return this.Factory.Get<ICallable<(QArray<Pauli>,QArray<Qubit>,Result,Double,String,Double), QVoid>, Microsoft.Quantum.Primitive.AssertProb>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.H>();
            }
        }

        protected ICallable<Qubit, Result> MicrosoftQuantumCanonMResetZ
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Canon.MResetZ>();
            }
        }

        protected Release Release
        {
            get
            {
                return this.Factory.Get<Release, Microsoft.Quantum.Primitive.Release>();
            }
        }

        public override Func<QVoid, (Result,Result,Result,Result)> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("ClementinesCat.MeasureCatMood", OperationFunctor.Body, _args);
                var __result__ = default((Result,Result,Result,Result));
                try
                {
#line 8 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var result = (Result.Zero, Result.Zero, Result.Zero, Result.Zero);
                    // The following using block creates a pair of fresh qubits and initializes it in |00〉.
#line 10 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var qubits = Allocate.Apply(4L);
                    //There are 4 qubits. One per member of the family so the 4 Qubits represent
                    //James, Josie, Clementine and Felicity
                    // By applying the Hadamard operator to each of the qubits we create state
                    // 1/2(|00〉+|01〉+|10〉+|11〉). 
#line 17 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    MicrosoftQuantumCanonApplyToEach.Apply((((ICallable)MicrosoftQuantumPrimitiveH), qubits));
                    //So now each qubit represents a 50% chance that the specified human will be 
                    //persuaded to feed the cat.
                    //When the cat eats, she immediately forgets she has eaten 
                    //(but remmebers which human she already asked to feed her)
                    //so she asks a different human to feed her
                    // We now assert that the probability for the events of finding the first qubit 
                    // in state |0〉 upon measurement in the standard basis is $1/2$. Note that this 
                    // assertion does not actually apply the measurement operation itself, i.e., it
                    // has no side effect on the state of the qubits.
#line 29 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    AssertProb.Apply((new QArray<Pauli>()
                    {Pauli.PauliZ}, new QArray<Qubit>()
                    {qubits[0L]}, Result.Zero, 0.5D, "Error: Outcomes of the measurement must be equally likely", 1E-05D));
                    // We now assert that the probability for the events of finding the second 
                    // qubit in state |0〉 upon measurement in the standard basis is $1/2$. 
#line 36 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    AssertProb.Apply((new QArray<Pauli>()
                    {Pauli.PauliZ}, new QArray<Qubit>()
                    {qubits[1L]}, Result.Zero, 0.5D, "Error: Outcomes of the measurement must be equally likely", 1E-05D));
                    // We now assert that the probability for the events of finding the third 
                    // qubit in state |0〉 upon measurement in the standard basis is $1/2$. 
#line 44 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    AssertProb.Apply((new QArray<Pauli>()
                    {Pauli.PauliZ}, new QArray<Qubit>()
                    {qubits[2L]}, Result.Zero, 0.5D, "Error: Outcomes of the measurement must be equally likely", 1E-05D));
                    // We now assert that the probability for the events of finding the third 
                    // qubit in state |0〉 upon measurement in the standard basis is $1/2$. 
#line 52 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    AssertProb.Apply((new QArray<Pauli>()
                    {Pauli.PauliZ}, new QArray<Qubit>()
                    {qubits[3L]}, Result.Zero, 0.5D, "Error: Outcomes of the measurement must be equally likely", 1E-05D));
                    // Now, we measure each qubit in Z-basis and immediately reset the qubits 
                    // to zero, using the canon operation MResetZ.
#line 60 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    result = (MicrosoftQuantumCanonMResetZ.Apply<Result>(qubits[0L]), MicrosoftQuantumCanonMResetZ.Apply<Result>(qubits[1L]), MicrosoftQuantumCanonMResetZ.Apply<Result>(qubits[2L]), MicrosoftQuantumCanonMResetZ.Apply<Result>(qubits[3L]));
                    //so if the result is One, she got fed by that human, if Zero she didn't
                    ;
#line hidden
                    Release.Apply(qubits);
#line hidden
                    __result__ = result;
                    // Finally, we return the result of the measurement. 
#line 67 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("ClementinesCat.MeasureCatMood", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<(Result,Result,Result,Result)> Run(IOperationFactory __m__)
        {
            return __m__.Run<MeasureCatMood, QVoid, (Result,Result,Result,Result)>(QVoid.Instance);
        }
    }

    public class CatMoodExperiment : Operation<Int64, (Int64,Int64)>
    {
        public CatMoodExperiment(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Canon.ApplyToEach<>), typeof(Microsoft.Quantum.Primitive.H), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Microsoft.Quantum.Primitive.ResetAll) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected Allocate Allocate
        {
            get
            {
                return this.Factory.Get<Allocate, Microsoft.Quantum.Primitive.Allocate>();
            }
        }

        protected ICallable MicrosoftQuantumCanonApplyToEach
        {
            get
            {
                return new GenericOperation(this.Factory, typeof(Microsoft.Quantum.Canon.ApplyToEach<>));
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.H>();
            }
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected Release Release
        {
            get
            {
                return this.Factory.Get<Release, Microsoft.Quantum.Primitive.Release>();
            }
        }

        protected ICallable<QArray<Qubit>, QVoid> ResetAll
        {
            get
            {
                return this.Factory.Get<ICallable<QArray<Qubit>, QVoid>, Microsoft.Quantum.Primitive.ResetAll>();
            }
        }

        public override Func<Int64, (Int64,Int64)> Body
        {
            get => (count) =>
            {
#line hidden
                this.Factory.StartOperation("ClementinesCat.CatMoodExperiment", OperationFunctor.Body, count);
                var __result__ = default((Int64,Int64));
                try
                {
#line 114 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var happyCatCount = 0L;
#line 115 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var sadCatCount = 0L;
#line 116 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    foreach (var test in new Range(1L, count))
                    {
#line 117 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                        var humans = Allocate.Apply(4L);
#line 118 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                        MicrosoftQuantumCanonApplyToEach.Apply((((ICallable)MicrosoftQuantumPrimitiveH), humans));
#line 119 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                        var numberOfHumansThatFedTheCat = 0L;
#line 120 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                        foreach (var human in new Range(0L, 3L))
                        {
#line 121 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                            var state = M.Apply<Result>(humans[human]);
#line 122 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                            if ((state == Result.One))
                            {
#line 123 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                                numberOfHumansThatFedTheCat = (numberOfHumansThatFedTheCat + 1L);
                            }
                        }

#line 126 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                        ResetAll.Apply(humans);
#line 127 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                        if ((numberOfHumansThatFedTheCat >= 2L))
                        {
#line 128 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                            happyCatCount = (happyCatCount + 1L);
                        }
                        else
                        {
#line 131 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                            sadCatCount = (sadCatCount + 1L);
                        }

#line hidden
                        Release.Apply(humans);
                    }

#line hidden
                    __result__ = (happyCatCount, sadCatCount);
#line 135 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("ClementinesCat.CatMoodExperiment", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<(Int64,Int64)> Run(IOperationFactory __m__, Int64 count)
        {
            return __m__.Run<CatMoodExperiment, Int64, (Int64,Int64)>(count);
        }
    }

    public class WhoFedTheCat : Operation<QVoid, (Boolean,Boolean,Boolean,Boolean)>
    {
        public WhoFedTheCat(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Canon.ApplyToEach<>), typeof(Microsoft.Quantum.Primitive.H), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Microsoft.Quantum.Primitive.ResetAll) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected Allocate Allocate
        {
            get
            {
                return this.Factory.Get<Allocate, Microsoft.Quantum.Primitive.Allocate>();
            }
        }

        protected ICallable MicrosoftQuantumCanonApplyToEach
        {
            get
            {
                return new GenericOperation(this.Factory, typeof(Microsoft.Quantum.Canon.ApplyToEach<>));
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.H>();
            }
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected Release Release
        {
            get
            {
                return this.Factory.Get<Release, Microsoft.Quantum.Primitive.Release>();
            }
        }

        protected ICallable<QArray<Qubit>, QVoid> ResetAll
        {
            get
            {
                return this.Factory.Get<ICallable<QArray<Qubit>, QVoid>, Microsoft.Quantum.Primitive.ResetAll>();
            }
        }

        public override Func<QVoid, (Boolean,Boolean,Boolean,Boolean)> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("ClementinesCat.WhoFedTheCat", OperationFunctor.Body, _args);
                var __result__ = default((Boolean,Boolean,Boolean,Boolean));
                try
                {
#line 141 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var jamesFedTheCat = false;
#line 142 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var josieFedTheCat = false;
#line 143 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var clementineFedTheCat = false;
#line 144 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var felicityFedTheCat = false;
#line 145 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var humans = Allocate.Apply(4L);
#line 146 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    MicrosoftQuantumCanonApplyToEach.Apply((((ICallable)MicrosoftQuantumPrimitiveH), humans));
#line 147 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var state0 = M.Apply<Result>(humans[0L]);
#line 148 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    jamesFedTheCat = (state0 == Result.One);
#line 150 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var state1 = M.Apply<Result>(humans[1L]);
#line 151 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    josieFedTheCat = (state1 == Result.One);
#line 153 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var state2 = M.Apply<Result>(humans[2L]);
#line 154 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    clementineFedTheCat = (state2 == Result.One);
#line 156 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    var state3 = M.Apply<Result>(humans[3L]);
#line 157 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    felicityFedTheCat = (state3 == Result.One);
#line 159 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    ResetAll.Apply(humans);
#line hidden
                    Release.Apply(humans);
#line hidden
                    __result__ = (jamesFedTheCat, josieFedTheCat, clementineFedTheCat, felicityFedTheCat);
#line 161 "/Users/jamesbirnie/code/Quantum/Samples/clementines-cat/Operation.qs"
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("ClementinesCat.WhoFedTheCat", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<(Boolean,Boolean,Boolean,Boolean)> Run(IOperationFactory __m__)
        {
            return __m__.Run<WhoFedTheCat, QVoid, (Boolean,Boolean,Boolean,Boolean)>(QVoid.Instance);
        }
    }
}