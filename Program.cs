using ScreenSoundAPI.Modelos;
using System.Text.Json;
using ScreenSoundAPI.Filtros;

using (HttpClient client = new HttpClient())
{
    try
    {
        string response = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        
        var musicas = JsonSerializer.Deserialize<List<Musica>>(response)!;

        //LinqFilter.FiltrarTodosOsGenerosMusicais(musicas);
        //LinqOrder.ExibirListaDeArtistasOrdenados(musicas);
        //LinqFilter.FiltrarArtistasPorGeneroMusical(musicas, "rock");
        //LinqFilter.FiltrarMusicasDeUmArtista(musicas, "U2");

        var musicasPreferidasDoGuilherme = new MusicasPreferidas("Guilherme");
        musicasPreferidasDoGuilherme.AdicionarMusicasFavoritas(musicas[1]);
        musicasPreferidasDoGuilherme.AdicionarMusicasFavoritas(musicas[765]);
        musicasPreferidasDoGuilherme.AdicionarMusicasFavoritas(musicas[898]);
        musicasPreferidasDoGuilherme.AdicionarMusicasFavoritas(musicas[10]);
        musicasPreferidasDoGuilherme.AdicionarMusicasFavoritas(musicas[71]);

        musicasPreferidasDoGuilherme.ExibirMusicasFavoritas();

        musicasPreferidasDoGuilherme.GerarArquivoJson();


    }
    catch (Exception ex)
    {
        Console.WriteLine($"Temos um problema: {ex.Message}");
    }
}
