using System.Collections.Generic;
using RegistroMenoPazzo.Models;

namespace RegistroMenoPazzo.Stores;

internal class StudenteStore
{
    private readonly List<Studente> _studenti = [];
    
    internal List<Studente> Get()
    {
        return _studenti;
    }
    
    internal bool AggiungiStudente(Studente item)
    {
        _studenti.Add(item);
        return true;
    }
    
    internal bool CancellaStudente(int id)
    {
        var daEliminare = _studenti.Find(studente => studente.Id == id);
        return daEliminare != null && _studenti.Remove(daEliminare);
    }
}