using System.Collections.Generic;
using System.Linq;
using RegistroMenoPazzo.Models;

namespace RegistroMenoPazzo.Stores;

internal class StudenteStore
{
    private readonly List<Studente> _studenti = [];

    internal List<Studente> Get()
    {
        return _studenti;
    }

    internal Studente? Get(string input)
    {
        return _studenti
            .FirstOrDefault(studente => studente.Nome == input ||
                                        studente.Cognome == input ||
                                        studente.Id.ToString() == input);

        //if (input == null)
        //{
        //    return null;
        //}

        //var studenteTrovato = _studenti.Find(studente => studente.Nome == input);
        //if (studenteTrovato != null)
        //{
        //    return studenteTrovato;
        //}
        //studenteTrovato = _studenti.Find(studente => studente.Cognome == input);
        //if (studenteTrovato != null)
        //{
        //    return studenteTrovato;
        //}

        //studenteTrovato = _studenti.Find(studente => studente.Id.ToString() == input);
        //return studenteTrovato ?? null;
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