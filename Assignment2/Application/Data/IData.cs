using System.Collections.Generic;
using Application.Models;

namespace Application.Data {
    public interface IData {
        IList<Adult> GetAdults();
        void AddAdult(Adult adult);
    }
}