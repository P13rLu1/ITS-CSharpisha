using System.Collections.Generic;
using RistorApp.DataLayer.Models;

namespace RistorApp.DataLayer.Stores.Interfaces;

public interface IClienteStore
{
    List<Cliente> Get();

    Cliente Get(int id);

    bool Create(Cliente clienteDaAggiungere);

    bool Update(ClienteCreateModel nuovaVersione);

    bool Delete(int id);
}