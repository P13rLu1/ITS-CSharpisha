using BigliettApp.DataLayer.Models;

namespace BigliettApp.DataLayer.Stores.Interfaces;

public interface ISpettacoloStore
{
    List<Spettacolo> Get();
    
    Spettacolo Get(int id);
    
    bool Create(Spettacolo tavoloDaAggiungere);
    
    bool Update(SpettacoloCreateModel nuovaVersione);
    
    bool Delete(int id);
}