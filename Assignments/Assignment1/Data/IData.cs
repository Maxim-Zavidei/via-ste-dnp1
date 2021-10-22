using System.Collections.Generic;
using Assignment1.Models;

namespace Assignment1.Data {
    public interface IData {
        IList<Adult> GetAdults();
        void AddAdult(Adult adult);
    }
}