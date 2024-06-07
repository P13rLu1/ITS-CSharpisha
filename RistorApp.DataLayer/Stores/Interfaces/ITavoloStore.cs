using System.Collections.Generic;
using RistorApp.DataLayer.Models;

namespace RistorApp.DataLayer.Stores.Interfaces;

public interface ITavoloStore
{
    List<Tavolo> Get();
    
    Tavolo Get(int id);
    
    List<Tavolo> Get(List<Prenotazione> coincidenze, int postiRichiesti);
    
    bool Create(Tavolo tavoloDaAggiungere);
    
    bool Update(TavoloCreateModel nuovaVersione);
    
    bool Delete(int id);
}