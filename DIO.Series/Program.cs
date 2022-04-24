using DIO.Series.Enums;
using DIO.Series.Models;
using DIO.Series.Repositories;

public class Program 
{
	static SerieRepository serieRepository = new SerieRepository();

	static void Main(string[] args)
	{
		try
		{
			menu();
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}

	private static void menu()
	{
		string opcaoUsuario = ObterOpcaoUsuario().ToUpper();

		while (opcaoUsuario != "X")
		{
			switch (opcaoUsuario)
			{
				case "1":
					ListarSeries();
					break;
				case "2":
					InserirSerie();
					break;
				case "3":
					AtualizarSerie();
					break;
				case "4":
					ExcluirSerie();
					break;
				case "5":
					VisualizarSerie();
					break;
				case "C":
					Console.Clear();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			opcaoUsuario = ObterOpcaoUsuario().ToUpper();
		}
	}

	private static string ObterOpcaoUsuario()
	{
		Console.WriteLine();
		Console.WriteLine("------ DIO Séries -----");
		Console.WriteLine("Informe a sua opção:");

		Console.WriteLine("1 - Listar séries");
		Console.WriteLine("2 - Inserir nova série");
		Console.WriteLine("3 - Atualizar série");
		Console.WriteLine("4 - Excluir série");
		Console.WriteLine("5 - Visualizar série");
		Console.WriteLine("C - Limpar tela");
		Console.WriteLine("X - Sair");
		Console.WriteLine();

		string opcaoUsuario = Console.ReadLine().ToUpper();
		Console.WriteLine();

		return opcaoUsuario;
	}

	private static void ListarSeries()
	{
		Console.WriteLine("Séries:");

		var lista = serieRepository.GetAll();

		if (!lista.Any()) 
		{
			Console.WriteLine("Nenhuma série cadastrada.");
			return;
		}

		foreach (var serie in lista)
			Console.WriteLine($"#ID {serie.Id}: - {serie.Titulo}");
	}

	private static void InserirSerie() 
	{
		Console.WriteLine("Inserir uma nova série");

		serieRepository.Insert(SolicitarInformacoesDaSerie());
	}

	private static void AtualizarSerie() 
	{
		int id = ObterIdInformadoPeloUsuario();

		serieRepository.Update(id, SolicitarInformacoesDaSerie(id));
	}

	private static void ExcluirSerie() 
	{
		int id = ObterIdInformadoPeloUsuario();

		serieRepository.Delete(id);
	}

	private static void VisualizarSerie() 
	{
		int id = ObterIdInformadoPeloUsuario();

		Console.WriteLine(serieRepository.GetId(id));
	}

	private static void ListarGeneros() 
	{
		foreach (int i in Enum.GetValues(typeof(Genero)))
			Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
	}

	private static Serie SolicitarInformacoesDaSerie(int? id = null) 
	{
		ListarGeneros();
		Console.Write("Digite o gênero entre as opções acima: ");
		int idGenero = int.Parse(Console.ReadLine());

		Console.Write("Digite o título da série: ");
		string titulo = Console.ReadLine();

		Console.Write("Digite o ano de início da série: ");
		int ano = int.Parse(Console.ReadLine());

		Console.Write("Digite a descrição da série: ");
		string descricao = Console.ReadLine();

		return new Serie(id == null ? serieRepository.NextId() : id.Value,
			(Genero)idGenero,
			titulo,
			descricao,
			ano);
	}

	private static int ObterIdInformadoPeloUsuario() 
	{
		Console.Write("Informe o ID da série: ");

		return int.Parse(Console.ReadLine());
	}
}