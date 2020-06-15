using System;
using System.Collections.Generic;

namespace Resistors
{
    public enum ResistorRange
    {
        E24 = 24,
        E48 = 48,
        E96 = 96
    } 
    
    public class PreferredResistors
    {
        private List<double> _preferredValues;

        private ResistorRange _range;

        public ResistorRange Range
        { 
            get { return _range; }
            
            set
            {
                // if different, set and recalculate series values
                if (value != _range)
                {
                    _range = value;
                    calculateSeries();
                }
            }
        }

        public PreferredResistors()
        {
            // default to E96
            Range = ResistorRange.E96;
        }

        private void calculateSeries()
        {
            _preferredValues = new List<double>();

            int series = (int)Range;
            
            int dp = (Range == ResistorRange.E24) ? 1 : 2;

            double root = 1.0 / series;

            for (int i=0; i < series; i++)
            {
                _preferredValues.Add(Math.Round(Math.Pow(Math.Pow(10.0, i), root), dp));
            }

            // replace calculated E24 values at indices 10 thru 16 with 'offical' values
            // https://en.wikipedia.org/wiki/E_series_of_preferred_numbers#E96
            if (_range == ResistorRange.E24)
            {
                double[] official = new double[] { 2.7, 3.0, 3.3, 3.6, 3.9, 4.3, 4.7 };

                for (int i=0; i < official.Length; i++)
                {
                    _preferredValues[10 + i] = official[i];
                }
            }
        }


        
    }
}
