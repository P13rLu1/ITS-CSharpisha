using BigliettApp.DataLayer.Models;

namespace BigliettApp.DataLayer.Stores.Interfaces;

public interface IClienteStore
{
    List<Cliente> Get();

    Cliente Get(int id);

    bool Create(Cliente clienteDaAggiungere);

    bool Update(ClienteCreateModel nuovaVersione);

    bool Delete(int id);
}