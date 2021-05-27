using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes.Semantic
{
    /// <summary>
    /// CHALLENGE ID: 51
    /// ** Do not modify the namespace name or the Run class method headers. **
    /// ** Do not modify any constructor or the classes names. **
    /// 1. Identify all the names that contain meaningless words.
    /// 2. Remove or rename these identifiers into something meaningful.
    /// 3. Ensure there are no syntax errors and that the Run class is aware of any renaming of the other classes and their members.
    /// </summary>
    public class PharmacistInfo
    {
        public int PharmacistId { get; }
        public ISet<Stocktake> Stocktakes { get; } = new HashSet<Stocktake>();

        public bool HasStocktakes(List<Stocktake> stocktakeSet)
        {
            foreach (var stocktake in stocktakeSet)
            {
                if (!Stocktakes.Contains(stocktake)) return false;
            }

            return true;
        }

        public void AssignStocktake(Stocktake stocktakeData)
        {
            if (Stocktakes.Contains(stocktakeData)) throw new ThePharmacistAlreadyHasStocktakeException("Pharmacist: " + PharmacistId.ToString() + "Stock: " + stocktakeData);
            Stocktakes.Add(stocktakeData);
        }

    }

    public class ThePharmacistAlreadyHasStocktakeException : Exception
    {
        public ThePharmacistAlreadyHasStocktakeException(string pharmacistId) : base(pharmacistId)
        {
        }
    }

    public class Stocktake
    {
        private readonly string _nameStr;

        public Stocktake(string name)
        {
            _nameStr = name;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Stocktake other)) return false;
            return other._nameStr.Equals(_nameStr);
        }

        public override int GetHashCode()
        {
            return _nameStr.GetHashCode();
        }
    }

    #region Run
    public class Run
    {
        private readonly PharmacistInfo _pharmacist;

        public Run()
        {
            _pharmacist = new PharmacistInfo();
            _pharmacist.AssignStocktake(new Stocktake("Test 1"));
            _pharmacist.AssignStocktake(new Stocktake("Test 2"));
            _pharmacist.AssignStocktake(new Stocktake("Test 3"));
        }

        public void AddStock()
        {
            _pharmacist.AssignStocktake(new Stocktake("Test 1"));
        }

        public List<Stocktake> GetStock()
        {
            return _pharmacist.Stocktakes.ToList();
        }

        public bool HasStock(List<Stocktake> all)
        {
            return _pharmacist.HasStocktake(all);
        }
    }
    #endregion
}
