using MySqlConnector;
public class Jogo_MySql
{
    private string conexao = "Server=localhost;Database=Jogos;User Id=root;Password=Senac2026;";
    private bool valido = true;

    private string nome;
    private string franquia;
    private string genero;
    private string data_lancamento;
    private double nota;

    private DateTime? DataLancamentoConvertida;

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

    public Jogo_MySql(string nome, string franquia, string genero, string data_lancamento, double nota)
    {
        Nome = nome;
        Franquia = franquia;
        Genero = genero;
        DataLancamento = data_lancamento;
        Nota = nota;

        if (valido)
        {
            ConverterData(data_lancamento);
            using (var conexaoMySql = new MySqlConnection(conexao))
            {
                try
                {
                    conexaoMySql.Open();
                    string sql = "INSERT INTO Jogos (nome, franquia, genero, data_lancamento, nota) VALUES (@nome, @franquia, @genero, @data_lancamento, @nota)";
                    using (var comando = new MySqlCommand(sql, conexaoMySql))
                    {
                        comando.Parameters.AddWithValue("@nome", nome);
                        comando.Parameters.AddWithValue("@franquia", franquia);
                        comando.Parameters.AddWithValue("@genero", genero);
                        comando.Parameters.AddWithValue("@data_lancamento", DataLancamentoConvertida);
                        comando.Parameters.AddWithValue("@nota", nota);

                        comando.ExecuteNonQuery();
                    }
                }
                catch
                {
                    Console.WriteLine($"Erro ao inserir o jogo {nome} no banco de dados.");
                }
            }
        }
        else
        {
            Console.WriteLine("Não foi possível inserir o jogo no banco de dados devido a dados inválidos.");
        }
    }

    public void LerJogos()
    {
        using (var conexaoMySql = new MySqlConnection(conexao))
        {
            conexaoMySql.Open();
            string sql = "SELECT * FROM Jogos";
            using (var comando = new MySqlCommand(sql, conexaoMySql))
            {
                using (var jogos = comando.ExecuteReader())
                {
                    while (jogos.Read())
                    {
                        Console.WriteLine($"ID: {jogos["id"]}, Nome: {jogos["nome"]}, Franquia: {jogos["franquia"]}, Gênero: {jogos["genero"]}, Data de Lançamento: {jogos["data_lancamento"]}, Nota: {jogos["nota"]}");
                    }
                }
            }
        }
    }

    public void AtualizarJogo(int id, int item_mudar, string novo_valor = null, double nova_nota = -1)
    {
        if (valido)
        {
            using (var conexaoMySql = new MySqlConnection(conexao))
            {
                try
                {
                    conexaoMySql.Open();
                    string sql = "UPDATE Jogos SET  WHERE id = @id";
                    using (var comando = new MySqlCommand(sql, conexaoMySql))
                    {
                        comando.Parameters.AddWithValue("@id", id);

                        int linhasAfetadas = comando.ExecuteNonQuery();
                        if (linhasAfetadas > 0)
                        {
                            Console.WriteLine("Jogo atualizado com sucesso.");
                        }
                        else
                        {
                            Console.WriteLine("Nenhum jogo encontrado com o ID fornecido.");
                        }
                    }
                }
                catch
                {
                    Console.WriteLine($"Erro ao atualizar o jogo.");
                }
            }
        }
        else
        {
            Console.WriteLine("Não foi possível atualizar o jogo no banco de dados devido a dados inválidos.");
        }
    }

    public void DeletarJogo(int id)
    {
        using (var conexaoMySql = new MySqlConnection(conexao))
        {
            try
            {
                conexaoMySql.Open();
                string sql = "DELETE FROM Jogos WHERE id = @id";
                using (var comando = new MySqlCommand(sql, conexaoMySql))
                {
                    comando.Parameters.AddWithValue("@id", id);

                    int linhasAfetadas = comando.ExecuteNonQuery();
                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Jogo deletado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum jogo encontrado com o ID fornecido.");
                    }
                }
            }
            catch
            {
                Console.WriteLine($"Erro ao deletar o jogo.");
            }
        }
    }
}