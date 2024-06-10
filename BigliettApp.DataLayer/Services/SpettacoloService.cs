using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Stores.Interfaces;

namespace BigliettApp.DataLayer.Services;

public class SpettacoloService (ISpettacoloStore spettacoloStore)
{
    public List<Spettacolo> Get()
    {
        return spettacoloStore.Get();
    }

    public Spettacolo Get(int id)
    {
        return spettacoloStore.Get(id);
    }

    public bool Create(SpettacoloCreateModel spettacoloDaCreare)
    {
        var spettacoloDaAggiungere = new Spettacolo(spettacoloDaCreare.Titolo.ToUpper(), spettacoloDaCreare.Descrizione ?? "", spettacoloDaCreare.DataOra,spettacoloDaCreare.Durata,spettacoloDaCreare.PrezzoBase);
        return spettacoloStore.Create(spettacoloDaAggiungere);
    }

    public bool Update(SpettacoloCreateModel nuovaVersione)
    {
        return spettacoloStore.Update(nuovaVersione);
    }

    public bool Delete(int id)
    {
        return spettacoloStore.Delete(id);
    }
}