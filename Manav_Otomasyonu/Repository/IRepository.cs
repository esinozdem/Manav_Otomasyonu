using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manav_Otomasyonu.Repository
{
    //metotları Standartlaştırmak için ınterface Oluşturduk.
    public interface IRepository<T>
    {
        List<T> Get();
        T GetById(int id);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
