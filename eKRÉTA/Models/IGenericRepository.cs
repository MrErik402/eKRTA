using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKRÉTA.Models
{
    public interface IGenericRepository<T> where T : new()
    {
        //Definiáljuk azokat a metódusokat amiket majd meg kell valósítani. 
        
        
        //Visszaadja az összes elemet a megadott típusból.
        List<T> GetAll();

        //Beszúr egy új elemet a megadott típusból.
        void insert(T item);
        //Módosít egy elemet a megadott típusból.
        void update(T item);
        //Töröl egy elemet a megadott típusból.
        void delete(T item);


    }
}
