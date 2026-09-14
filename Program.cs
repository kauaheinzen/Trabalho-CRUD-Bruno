while (true)
{
    Console.Clear();

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
                Console.Write("Digite o nome do jogo: ");
                string nomeJogo = Console.ReadLine();
                Console.Write("Digite a franquia do jogo: ");
                string franquiaJogo = Console.ReadLine();
                Console.Write("Digite o gênero do jogo: ");
                string generoJogo = Console.ReadLine();
                Console.Write("Digite a data de lançamento do jogo (DD/MM/AAAA): ");
                string dataLancamentoJogo = Console.ReadLine();
                Console.Write("Digite a nota do jogo: ");
                double notaJogo = double.Parse(Console.ReadLine());

                Jogo_MySql jogo = new Jogo_MySql(nomeJogo, franquiaJogo, generoJogo, dataLancamentoJogo, notaJogo);
            }
        case "2":
            // Lógica para listar jogos
            break;
        case "3":
            // Lógica para atualizar jogo
            break;
        case "4":
            // Lógica para deletar jogo
            break;
        case "5":
            // Lógica para sair
            break;
        default:
            Console.WriteLine("Opção inválida!");
            continue;
    }




} 