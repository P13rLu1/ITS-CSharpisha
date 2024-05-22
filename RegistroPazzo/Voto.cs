namespace ITS_CSharpisha;

public class Voto
{
    public string Materia { get; set; }
    public int VotoNumerico { get; set; }
    public string Data { get; set; }
    
    public Voto(string materia, int votoNumerico, string data)
    {
        Materia = materia;
        VotoNumerico = votoNumerico;
        Data = data;
    }
    
    public override string ToString()
    {
        return $"{Materia} ({VotoNumerico}) - {Data}";
    }
}