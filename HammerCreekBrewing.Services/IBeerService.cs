using HammerCreekBrewing.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 


namespace HammerCreekBrewing.Services
{
    public interface IBeerService
    {
        //List<T> GetBeerOnTap<T>();
        //List<T> GetBeerOnTapInside<T>();
        //List<T> GetBeerOnTapGarage<T>();
        //List<T> GetBeerInFridge<T>();
        Task<List<T>> GetBeerOnTapAsync<T>();
        Task<List<T>> GetAllBeersAsync<T>();
        Task<T> GetBeerAsync<T>(int id);
    }
}
