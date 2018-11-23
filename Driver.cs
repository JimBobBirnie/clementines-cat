using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClementinesCat
{
    class Driver
    {
        static void Main(string[] args)
        {
            var sim = new QuantumSimulator(throwOnReleasingQubitsNotInZeroState: true);

            int measurements = 100;

            var massExperimentResults = CatMoodExperiment.Run(sim, measurements).Result;
            var (happyCats, sadCats) = massExperimentResults;
            //there are 4 possible outcomes with the following probabilities (binomial theorem)
            //0 people fed the cat 1/15 (sad)
            //1 person fed the cat 4/15 (sad)
            //2 people fed the cat 6/15 (happy)
            //3 people fed the cat 4/15 (happy)
            //4 people fed the cat 1/15 (happy)
            System.Console.WriteLine("happy cats {0}", happyCats);
            System.Console.WriteLine("sad cats {0}", sadCats);

            for(int i = 0; i < measurements; i++){
                int countOfHumansThatFedTheCat = 0;
                var singleExperimentResults = WhoFedTheCat.Run(sim).Result;
                var (jamesFedTheCat, josieFedTheCat, clementineFedTheCat, felicityFedTheCat) 
                    = singleExperimentResults;
                countOfHumansThatFedTheCat = (jamesFedTheCat ? 1 : 0) + (josieFedTheCat ? 1 : 0) 
                    + (clementineFedTheCat ? 1 : 0) + (felicityFedTheCat ? 1 : 0);
                System.Console.WriteLine(countOfHumansThatFedTheCat >= 2 ? 
                    GetHappyOutome() : GetSadOutcome());
            }
        }



        static string GetHappyOutome()
        {
            return "I am INDIFFERENT to your feelings HUMAN!!!";
        }

        static string GetSadOutcome()
        {
            return "I am STILL INDIFFERENT to your feelings HUMAN, but now I am considering choosing A NEW HUMAN OWNER";
        }
    }
}