public class Jogo_MySql
{ 
    private bool valido = true;

    private string nome;
    private string franquia;
    private string genero;
    private string data_lancamento;
    private double nota;

    private DateTime DataLancamentoConvertida;

    public string Nome
    {
        get { return nome; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("O nome do jogo não pode ser vazio.");
                valido = false;
            }
            else
            {
                nome = value;
            }
        }
    }
    public string Franquia
    {
        get { return franquia; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("A franquia do jogo não pode ser vazia.");
                valido = false;
            }
            else
            {
                franquia = value;
            }
        }
    }
    public string Genero
    {
        get { return genero; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("O gênero do jogo não pode ser vazio.");
                valido = false;
            }
            else
            {
                genero = value;
            }
        }
    }
    public string DataLancamento
    {
        get { return data_lancamento; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !DateTime.TryParse(value, out _))
            {
                Console.WriteLine("A data de lançamento do jogo não pode ser vazia e precisa ser do formato (DD/MM/AAAA).");
                valido = false;
            }
            else
            {
                data_lancamento = value;
                ConverterData(value);
            }
        }
    }
    public double Nota
    {
        get { return nota; }
        set
        {
            if (value < 0 || value > 99)
            {
                Console.WriteLine("A nota do jogo deve estar entre 0 e 99.");
                valido = false;
            }
            else
            {
                nota = value;
            }
        }
    }

    private void ConverterData(string data)
    {
        if (DateTime.TryParse(data, out DateTime dataConvertida))
        {
            DataLancamentoConvertida = dataConvertida;
        }
        else
        {
            Console.WriteLine("Formato de data inválido. Use o formato correto (dd/MM/yyyy).");
            valido = false;
        }
    }

    public Jogo_MySql(string nome, string franquia, string genero, string data_lancamento, double nota, MySql jogos)
    {
        Nome = nome;
        Franquia = franquia;
        Genero = genero;
        DataLancamento = data_lancamento;
        Nota = nota;

        if (valido)
        {
            jogos.CadastrarJogo(nome, franquia, genero, DataLancamentoConvertida, nota);
        }
        else
        {
            Console.WriteLine("Não foi possível inserir o jogo no banco de dados devido a dados inválidos.");
        }
    }
}