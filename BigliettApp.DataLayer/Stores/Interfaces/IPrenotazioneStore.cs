using BigliettApp.DataLayer.Models;

namespace BigliettApp.DataLayer.Stores.Interfaces;

public interface IPrenotazioneStore
{
    List<Prenotazione> Get();
    
    Prenotazione Get(int id);
    
    bool Create(Prenotazione prenotazioneDaAggiungere);
    
    bool Update(PrenotazioneCreateModel nuovaVersione);
    
    bool Delete(int id);
}