using System;

namespace BeerEncapsulator
{
    class Program
    {
        static void Main(string[] args)
        {
            BeerEncapsulator BeerFactory = new BeerEncapsulator();

            Console.WriteLine("Which is the initial beer volume? : ");
            double InitialBeerVolume = Convert.ToDouble(Console.ReadLine());
            BeerFactory.SetAvailableBeerVolume(InitialBeerVolume);

            Console.WriteLine("Which is the initial number of beer bottles? : ");
            int InitialNumberOfBottles = Convert.ToInt32(Console.ReadLine());
            BeerFactory.SetAvailableBeerBottles(InitialNumberOfBottles);

            Console.WriteLine("Which is the initial number of beer capsules? : ");
            int InitialNumberOfCapsules = Convert.ToInt32(Console.ReadLine());
            BeerFactory.SetAvailableCapsules(InitialNumberOfCapsules);

            Console.WriteLine("How much beer do you want to add? : ");
            double AddingBeer = Convert.ToInt32(Console.ReadLine());
            BeerFactory.addBeer(AddingBeer);

            Console.WriteLine("How many beer bottles do you want to produce? ");
            int DesiredNumberOfFilledBottles = Convert.ToInt32(Console.ReadLine());
            int NumberOfFilledBottles = BeerFactory.ProduceEncapsulatedBeerBottle(DesiredNumberOfFilledBottles);

            Console.WriteLine("Number of produced bottles: " + NumberOfFilledBottles);

            
        }
    }

    public class BeerEncapsulator
    {
        private int _availableBeerBottles;
        private int _availableCapsules;
        private double _availableBeerVolume;
        private int _NumberOfProducedBottles = 0;

        public void SetAvailableBeerVolume(double InitialBeerVolume)
        {
            if (InitialBeerVolume > 0)
            {
                _availableBeerVolume = InitialBeerVolume;
            }
        }

        public int SetAvailableCapsules(int Capsules)
        {
            if (Capsules > 0)
            {
                _availableCapsules = Capsules;
            }
            else
            {
                _availableCapsules = 0;
            }
            
            return _availableCapsules;
        }

        public int SetAvailableBeerBottles(int BeerBottles)
        {
            if (BeerBottles > 0)
            {
                _availableBeerBottles = BeerBottles;
            }
            else
            {
                _availableBeerBottles = 0;
            }
            return _availableBeerBottles;
        }



        public double addBeer(double _addBeerVolume)
        {
            if (_addBeerVolume>0)
            {
                _availableBeerVolume = _availableBeerVolume + _addBeerVolume;
            }
            
            return _availableBeerVolume;
        }


        public int ProduceEncapsulatedBeerBottle(int NumberOfDesiredBottles)
        {
            
            if (!IsComponentQuantityEnough(NumberOfDesiredBottles))
            {
                DisplayMissingComponents(NumberOfDesiredBottles);
                return 0;
            }

            while(_availableBeerBottles>=1 && _availableBeerVolume >= 0.33 && _availableCapsules >= 1)
            {
                _availableBeerBottles--;
                _availableBeerVolume = _availableBeerVolume - 0.33;
                _availableCapsules--;
                _NumberOfProducedBottles++;
            }

            return _NumberOfProducedBottles;
        }

        public bool IsComponentQuantityEnough(int NumberOfDesiredBottles)
        {
            if (_availableBeerBottles >= NumberOfDesiredBottles && _availableBeerVolume >= 0.33 * NumberOfDesiredBottles && _availableCapsules >= NumberOfDesiredBottles)
            {
                return true;
            }
            
            else
            {
                return false;
            }
        }

        public void DisplayMissingComponents(int NumberOfDesiredBottles)
        {
            int missingBottles = NumberOfDesiredBottles - _availableBeerBottles;
            double missingBeer = NumberOfDesiredBottles * 0.33 - _availableBeerVolume;
            int missingCapsules = NumberOfDesiredBottles - _availableCapsules;

            if (_availableBeerBottles < NumberOfDesiredBottles)
            {
                Console.WriteLine("{0} bottles are missing", missingBottles);
            }

            if (_availableBeerVolume < 0.33*NumberOfDesiredBottles)
            {
                Console.WriteLine("{0} L of beer are missing", missingBeer);
            }

            if (_availableCapsules < NumberOfDesiredBottles)
            {
                Console.WriteLine("{0} capsules are missing", missingCapsules);
            }
        }

    }
}
