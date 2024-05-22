namespace ITS_CSharpisha;

public class ClasseFrequentata
{
    public ClasseFrequentata(string nomeClasse, string annoScolastico)
    {
        NomeClasse = nomeClasse;
        AnnoScolastico = annoScolastico;
    }

    public string NomeClasse { get; set; }
    public string AnnoScolastico { get; set; }
    

    public override string ToString()
    {
        return $"{NomeClasse} ({AnnoScolastico})";
    }
    
    public bool Equals(ClasseFrequentata classe)
    {
        return NomeClasse == classe.NomeClasse && AnnoScolastico == classe.AnnoScolastico;
    }
    
}