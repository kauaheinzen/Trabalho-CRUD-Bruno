MySql jogos = new MySql();
bool sair = false;

Console.Clear();

while (true)
{
    if (sair)
    {
        Console.WriteLine("Até logo!");
        break;
    }


    Console.WriteLine("================================");
    Console.WriteLine("=        MENU PRINCIPAL        =");
    Console.WriteLine("================================");
    Console.WriteLine("1. Cadastrar Jogo ");
    Console.WriteLine("2.  Listar Jogos  ");
    Console.WriteLine("3. Atualizar Jogo ");
    Console.WriteLine("4.  Deletar Jogo  ");
    Console.WriteLine("5.      Sair      ");
    Console.Write("Escolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            while (true)
            {
                try
                {
                    Console.Write("Digite o nome do jogo: ");
                    string? nomeJogo = Console.ReadLine();
                    Console.Write("Digite a franquia do jogo: ");
                    string? franquiaJogo = Console.ReadLine();
                    Console.Write("Digite o gênero do jogo: ");
                    string? generoJogo = Console.ReadLine();
                    Console.Write("Digite a data de lançamento do jogo (DD/MM/AAAA): ");
                    string? dataLancamentoJogo = Console.ReadLine();
                    Console.Write("Digite a nota do jogo: ");
                    double notaJogo = double.Parse(Console.ReadLine());

                    Jogo_MySql jogo = new Jogo_MySql(nomeJogo, franquiaJogo, generoJogo, dataLancamentoJogo, notaJogo, jogos);
                }
                catch
                {
                    Console.WriteLine("Dados inválidos. Por favor, tente novamente.");
                }
                
                Console.Write("Você deseja continuar cadastrando? [S/N]: ");
                string resposta = Console.ReadLine().ToUpper();
                if (resposta != "S" && resposta != "SIM")
                {
                    break;
                }
            }
            break;

        case "2":
            jogos.LerJogos();
            break;

        case "3":
            while (true)
            {
                try
                {
                    Console.WriteLine("Escolha o item que deseja atualizar:");
                    Console.WriteLine("1. Nome");
                    Console.WriteLine("2. Franquia");
                    Console.WriteLine("3. Gênero");
                    Console.WriteLine("4. Data de Lançamento");
                    Console.WriteLine("5. Nota");
                    Console.WriteLine("6. Cancelar");

                    Console.Write("Escolha uma opção: ");
                    string itemMudar = Console.ReadLine();

                    if (itemMudar == "6")
                    {
                        Console.WriteLine("Atualização cancelada.");
                        break;
                    }

                    Console.Write("Digite o ID do jogo que deseja atualizar: ");
                    int idJogo = int.Parse(Console.ReadLine());
                    
                    switch (itemMudar)
                    {
                        case "1":
                            Console.Write("Digite o novo nome: ");
                            string novoNome = Console.ReadLine();
                            jogos.AtualizarJogo(idJogo, 1, novoNome);
                            break;
                        case "2":
                            Console.Write("Digite a nova franquia: ");
                            string novaFranquia = Console.ReadLine();
                            jogos.AtualizarJogo(idJogo, 2, novaFranquia);
                            break;
                        case "3":
                            Console.Write("Digite o novo gênero: ");
                            string novoGenero = Console.ReadLine();
                            jogos.AtualizarJogo(idJogo, 3, novoGenero);
                            break;
                        case "4":
                            Console.Write("Digite a nova data de lançamento (DD/MM/AAAA): ");
                            string novaDataLancamento = Console.ReadLine();
                            jogos.AtualizarJogo(idJogo, 4, novaDataLancamento);
                            break;
                        case "5":
                            Console.Write("Digite a nova nota: ");
                            double novaNota = double.Parse(Console.ReadLine());
                            jogos.AtualizarJogo(idJogo, 5, null, novaNota);
                            break;
                        default:
                            Console.WriteLine("Opção inválida!");
                            continue;
                    }

                    if (itemMudar == "6")
                    {
                        break;
                    }

                }
                catch
                {
                    Console.WriteLine("Dados inválidos. Por favor, tente novamente.");
                }
            }
            break;

            

        case "4":
            try
            {
                Console.Write("Digite o ID do jogo que deseja deletar: ");
                string idDeletar = Console.ReadLine();
                jogos.DeletarJogo(idDeletar);
            }
            catch
            {
                Console.WriteLine("ID inválido. Por favor, tente novamente.");
            }

            break;

        case "5":
            sair = true;
            break;

        default:
            Console.WriteLine("Opção inválida!");
            continue;
    }
} 