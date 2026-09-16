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
                string sql = "INSERT INTO jogo (nome, franquia, genero_principal, data_lancamento, nota) VALUES (@nome, @franquia, @genero, @data_lancamento, @nota)";
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
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
            }
        }
    }

    public void LerJogos()
    {
        using (var conexaoMySql = new MySqlConnection(conexao))
        {
            conexaoMySql.Open();
            string sql = "SELECT * FROM jogo";
            using (var comando = new MySqlCommand(sql, conexaoMySql))
            {
                using (var jogos = comando.ExecuteReader())
                {
                    while (jogos.Read())
                    {
                        Console.WriteLine($"ID: {jogos["id"]} | Nome: {jogos["nome"]} | Franquia: {jogos["franquia"]} | Gênero: {jogos["genero_principal"]} | Data de Lançamento: {jogos["data_lancamento"]} | Nota: {jogos["nota"]}");
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
                string sql = item_mudar switch
                {
                    1 => "UPDATE jogo SET nome = @novo_valor WHERE id = @id",
                    2 => "UPDATE jogo SET franquia = @novo_valor WHERE id = @id",
                    3 => "UPDATE jogo SET genero_principal = @novo_valor WHERE id = @id",
                    4 => "UPDATE jogo SET data_lancamento = @novo_valor WHERE id = @id",
                    5 => "UPDATE jogo SET nota = @nova_nota WHERE id = @id",
                    _ => "Item inválido para atualização."
                };

                using (var comando = new MySqlCommand(sql, conexaoMySql))
                {
                    comando.Parameters.AddWithValue("@id", id);
                    if (item_mudar == 5)
                    {
                        comando.Parameters.AddWithValue("@nova_nota", nova_nota);
                    }
                    else
                    {
                        comando.Parameters.AddWithValue("@novo_valor", novo_valor);
                    }

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
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao atualizar o jogo: {ex.Message}");
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
                string sql = "DELETE FROM jogo WHERE id = @id";
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