using MySqlConnector;
public class MySql
{
    private string conexao = "Server=localhost;Database=Jogos;User Id=root;Password=Senac2026;";

    public void CadastrarJogo(string nome, string franquia, string genero, DateTime data_lancamento, double nota)
    {
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
                    comando.Parameters.AddWithValue("@data_lancamento", data_lancamento);
                    comando.Parameters.AddWithValue("@nota", nota);

                    int linhasAfetadas = comando.ExecuteNonQuery();
                    if (linhasAfetadas > 0)
                    {
                        Console.WriteLine("Jogo cadastrado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao cadastrar o jogo.");
                    }
                }
            }
            catch
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados.");
            }
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

    public void DeletarJogo(string id)
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