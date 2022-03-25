using BCSExam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCSExam.Interface
{
    public interface IGuestRepo
    {
        Task<IEnumerable<Talktoguest>> GetAll();
        Task<IEnumerable<Customer>> Customers(string parkCode, string arriving);
        Task<IEnumerable<dynamic>> GetSpoken();
        Task<dynamic> Response(SpokenToGuest spoken);
    }
}
