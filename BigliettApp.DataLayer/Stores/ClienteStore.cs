using BigliettApp.DataLayer.Models;
using BigliettApp.DataLayer.Stores.Interfaces;

namespace BigliettApp.DataLayer.Stores
{
    public class ClienteStore : IClienteStore
    {
        private readonly List<Cliente> _clienti =
        [
            new Cliente("Giovanni", "Romano", "giovanniromano@gmail.com", "3278749376"),
            new Cliente("Francesco", "Pellegrino", "francescopellegrino@gmail.com" , "3278749376"),
            new Cliente("Davide", "Botrugno", "davidebotrugno@linksmt.it", "3278749376")
        ];

        public List<Cliente> Get()
        {
            return _clienti;
        }

        public Cliente Get(int id)
        {
            var clienteTrovato = _clienti.FirstOrDefault(cliente => cliente.Id == id);
            
            if (clienteTrovato == null)
            {
                throw new Exception($"Cliente con id {id} non trovato");
            }
            return clienteTrovato;
        }

        public bool Create(Cliente clienteDaAggiungere)
        {
            _clienti.Add(clienteDaAggiungere);
            return true;
        }

        public bool Update(ClienteCreateModel nuovaVersione)
        {
            var vecchiaVersione = Get(nuovaVersione.Id);
            
            vecchiaVersione.Nome = nuovaVersione.Nome;
            vecchiaVersione.Cognome = nuovaVersione.Cognome;
            vecchiaVersione.Email = nuovaVersione.Email;
            vecchiaVersione.Telefono = nuovaVersione.Telefono;

            return true;
        }

        public bool Delete(int id)
        {
            var clienteDaRimuovere = Get(id);
            if (clienteDaRimuovere == null)
            {
                throw new Exception($"Cliente con id {id} non trovato");
            }
            return _clienti.Remove(clienteDaRimuovere); 
        }
    }
}