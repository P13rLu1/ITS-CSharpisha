using System.Collections.Generic;

namespace AziendaAlberghieraVernazza.Stores.Interfaces;

public interface IStore <T> where T : class
{
    public List<T>? Get();
    public bool Aggiungi(T entity);
    public bool Cancella(int id);
}