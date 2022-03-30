using System;
using System.Collections.Generic;

namespace Classes.Semantic
{
     /// <summary>
    /// ID izazova je dostupan na web prikazu.
    /// 1. Move methods to appropriate classes for good cohesion results.
    /// </summary>
    public class Pharmacist
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public List<Stocktake> StocktakesDone { get; set; }

        public bool HasAllVitaminsForDay(DateTime day)
        {
            foreach (var stocktake in StocktakesDone)
            {
                if (stocktake.DayOfStocktake.Date.Equals(day.Date))
                {
                    foreach (var vitamin in stocktake.Vitamins)
                    {
                        if (vitamin.Value <= 0) return false;
                    }
                }
            }

            return true;
        }

        public bool IsProfitableStocktakeForDay(Stocktake stocktake, DateTime day)
        {
            bool isDayOfStocktake = stocktake.DayOfStocktake.Date.Equals(day.Date);
            bool isProfitable = stocktake.Profit > 0;
            return isDayOfStocktake && isProfitable;
        }

        public List<string> GetAllStocktakeResourcesNames(Stocktake stocktake)
        {
            List<string> allResources = new List<string>();
            foreach (var medicine in stocktake.Medicines)
            {
                allResources.Add(medicine.Key);
            }
            foreach (var vitamin in stocktake.Vitamins)
            {
                allResources.Add(vitamin.Key);
            }
            return allResources;
        }
    }

    public class Stocktake
    {
        public Dictionary<string, int> Medicines { get; }
        public Dictionary<string, int> Vitamins { get; }
        public double Profit { get; }
        public DateTime DayOfStocktake { get; }

        public Stocktake(Dictionary<string, int> medicines, Dictionary<string, int> vitamins, double profit, DateTime dayOfStocktake)
        {
            Medicines = medicines;
            Vitamins = vitamins;
            Profit = profit;
            DayOfStocktake = dayOfStocktake;
        }

        public List<int> GetAllNotProfitablePharmacistStocktakeMonthsForYear(Pharmacist pharmacist, int year)
        {
            List<int> allNotProfitableMonths = new List<int>();
            foreach (var stocktake in pharmacist.StocktakesDone)
            {
                DateTime timeOfStocktake = stocktake.DayOfStocktake;
                if (stocktake.Profit <= 0 && timeOfStocktake.Year == year && !allNotProfitableMonths.Contains(timeOfStocktake.Month))
                {
                    allNotProfitableMonths.Add(timeOfStocktake.Month);
                }
            }
            return allNotProfitableMonths;
        }

    }
}