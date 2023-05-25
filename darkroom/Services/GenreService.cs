using darkRoom.Models;
using Newtonsoft.Json;
using Supabase;

namespace darkRoom.Services;

public class GenreService
{
    private readonly Client _supabaseclient;
    public GenreService(Client supabaseclient)
    {
        _supabaseclient = supabaseclient;
    }

    public async Task<List<Genre>> GetAsync() {
        var result = await _supabaseclient.From<Genre>().Get();
        return result.Models;
    }
        

    // public async Task<Book?> GetAsync(string id) =>
    //     await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    // public async Task CreateAsync(Book newBook) =>
    //     await _booksCollection.InsertOneAsync(newBook);

    // public async Task UpdateAsync(string id, Book updatedBook) =>
    //     await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    // public async Task RemoveAsync(string id) =>
    //     await _booksCollection.DeleteOneAsync(x => x.Id == id);
}