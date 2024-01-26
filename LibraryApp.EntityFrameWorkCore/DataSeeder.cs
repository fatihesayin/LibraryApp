using LibraryApp.Domain;
using LibraryApp.Utils;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.EntityFrameWorkCore
{
    public static class DataSeeding
    {
        public static async Task Seed(this DbContext context, IGuidGenerator guidGenerator)
        {
            if (!await context.Set<Book>().AnyAsync())
            {
                var books = new List<Book>
                {
                    new Book(guidGenerator.Create(), "Miguel de Cervantes", "Don Kişot", string.Empty),
                    new Book(guidGenerator.Create(), "George Orwell", "1984", string.Empty),
                    new Book(guidGenerator.Create(), "Stefan Zweig", "Satranç", string.Empty),
                    new Book(guidGenerator.Create(), "Lev Tolstoy", "Savaş ve Barış", string.Empty),
                    new Book(guidGenerator.Create(), "Fyodor Dostoyevsky", "Suç ve Ceza", string.Empty),
                    new Book(guidGenerator.Create(), "Harper Lee", "Bülbülü Öldürmek", string.Empty),
                    new Book(guidGenerator.Create(), "Aldous Huxley", "Cesur Yeni Dünya", string.Empty),
                    new Book(guidGenerator.Create(), "Charles Perrault", "Uyuyan Güzel", string.Empty),
                    new Book(guidGenerator.Create(), "Dan Brown", "Melekler ve Şeytanlar", string.Empty),
                    new Book(guidGenerator.Create(), "J.K. Rowling", "Harry Potter", string.Empty),
                    new Book(guidGenerator.Create(), "Gabriel Garcia Marquez", "Yüzyıllık Yalnızlık", string.Empty),
                    new Book(guidGenerator.Create(), "Jane Austen", "Aşk ve Gurur", string.Empty),
                    new Book(guidGenerator.Create(), "Leo Tolstoy", "Anna Karenina", string.Empty),
                    new Book(guidGenerator.Create(), "Ernest Hemingway", "Yaşlı Adam ve Deniz", string.Empty),
                    new Book(guidGenerator.Create(), "F. Scott Fitzgerald", "Muhteşem Gatsby", string.Empty),
                    new Book(guidGenerator.Create(), "Mark Twain", "Tom Sawyer'ın Maceraları", string.Empty),
                    new Book(guidGenerator.Create(), "Jules Verne", "Denizler Altında Yirmi Bin Fersah", string.Empty),
                    new Book(guidGenerator.Create(), "Agatha Christie", "Doğu Ekspresinde Cinayet", string.Empty),
                    new Book(guidGenerator.Create(), "J.R.R. Tolkien", "Yüzüklerin Efendisi", string.Empty),
                    new Book(guidGenerator.Create(), "Haruki Murakami", "Norveç Ormanı", string.Empty),
                    new Book(guidGenerator.Create(), "Virginia Woolf", "Mrs Dalloway", string.Empty),
                    new Book(guidGenerator.Create(), "Albert Camus", "Yabancı", string.Empty),
                    new Book(guidGenerator.Create(), "Homer", "İlyada", string.Empty),
                    new Book(guidGenerator.Create(), "Homer", "Odysseia", string.Empty),
                    new Book(guidGenerator.Create(), "William Golding", "Sineklerin Tanrısı", string.Empty),
                    new Book(guidGenerator.Create(), "J.D. Salinger", "Çavdar Tarlasında Çocuklar", string.Empty),
                    new Book(guidGenerator.Create(), "Ray Bradbury", "451 Fahrenheit", string.Empty),
                    new Book(guidGenerator.Create(), "H.G. Wells", "Zaman Makinesi", string.Empty),
                    new Book(guidGenerator.Create(), "Anton Çehov", "Kısa Öyküler", string.Empty),
                    new Book(guidGenerator.Create(), "Charlotte Brontë", "Jane Eyre", string.Empty),
                    new Book(guidGenerator.Create(), "Emily Brontë", "Wuthering Heights", string.Empty),
                    new Book(guidGenerator.Create(), "Herman Melville", "Moby Dick", string.Empty),
                    new Book(guidGenerator.Create(), "John Steinbeck", "Gazap Üzümleri", string.Empty),
                    new Book(guidGenerator.Create(), "Margaret Atwood", "Damızlık Kızın Öyküsü", string.Empty),
                    new Book(guidGenerator.Create(), "George R.R. Martin", "Buz ve Ateşin Şarkısı: Taht Oyunları", string.Empty),
                    new Book(guidGenerator.Create(), "Ayn Rand", "Atlas Silkindi", string.Empty),
                    new Book(guidGenerator.Create(), "Kurt Vonnegut", "Sirenlerin Dönüşü", string.Empty),
                    new Book(guidGenerator.Create(), "Tolstoy", "Kreutzer Sonat", string.Empty),
                    new Book(guidGenerator.Create(), "John Green", "Bir Fault Hatası", string.Empty),
                    new Book(guidGenerator.Create(), "Orhan Pamuk", "Beyaz Kale", string.Empty),
                    new Book(guidGenerator.Create(), "Philip K. Dick", "Androidler Elektrikli Koyun Düşler Mi?", string.Empty),
                    new Book(guidGenerator.Create(), "Roald Dahl", "Charlie'nin Çikolata Fabrikası", string.Empty),
                    new Book(guidGenerator.Create(), "Mario Puzo", "Baba", string.Empty),
                    new Book(guidGenerator.Create(), "Suzanne Collins", "Açlık Oyunları", string.Empty),
                    new Book(guidGenerator.Create(), "Stephen King", "The Shining", string.Empty),
                    new Book(guidGenerator.Create(), "J.D. Salinger", "Franny ve Zooey", string.Empty),
                    new Book(guidGenerator.Create(), "Dante Alighieri", "İlahi Komedya", string.Empty),
                    new Book(guidGenerator.Create(), "Voltaire", "Candide", string.Empty),
                    new Book(guidGenerator.Create(), "Kazuo Ishiguro", "Bana Kalan Gece", string.Empty),
                    new Book(guidGenerator.Create(), "H.P. Lovecraft", "Cthulhu'nun Çağrısı", string.Empty),
                    new Book(guidGenerator.Create(), "Ken Kesey", "Sisler İçindeki Dehşet", string.Empty),
                    new Book(guidGenerator.Create(), "Anne Frank", "Anne Frank'ın Hatıra Defteri", string.Empty),
                    new Book(guidGenerator.Create(), "Khaled Hosseini", "Uçurtma Avcısı", string.Empty),
                    new Book(guidGenerator.Create(), "Erich Maria Remarque", "Batı Cephesinde Yeni Bir Şey Yok", string.Empty),
                    new Book(guidGenerator.Create(), "Toni Morrison", "Sev", string.Empty),
                    new Book(guidGenerator.Create(), "Charles Dickens", "İki Şehrin Hikayesi", string.Empty),
                    new Book(guidGenerator.Create(), "Dostoyevski", "Karamazov Kardeşler", string.Empty),
                    new Book(guidGenerator.Create(), "Harper Lee", "Bülbülü Öldürmek", string.Empty),
                    new Book(guidGenerator.Create(), "Victor Hugo", "Sefiller", string.Empty),
                    new Book(guidGenerator.Create(), "Mikhail Bulgakov", "Usta ve Margarita", string.Empty),
                    new Book(guidGenerator.Create(), "William Faulkner", "As I Lay Dying", string.Empty),
                    new Book(guidGenerator.Create(), "John Milton", "Kayıp Cennet", string.Empty),
                    new Book(guidGenerator.Create(), "Yevgeny Zamyatin", "Biz", string.Empty)
                };

                context.Set<Book>().AddRange(books);
                var borrows = new List<Borrow>();
                Random rnd = new Random();
                borrows.AddRange(books.Where(o => o.Name.ToLower().StartsWith("s") || o.Name.ToLower().StartsWith("m") || o.Name.ToLower().StartsWith("b")).Select(o => new Borrow(guidGenerator.Create(), o.Id, DateTime.UtcNow.AddDays(rnd.Next(15)), GenerateName(10))));
                context.Set<Borrow>().AddRange(borrows);
                await context.SaveChangesAsync();
            }
        }
        public static string GenerateName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };
            string Name = "";
            Name += consonants[r.Next(consonants.Length)].ToUpper();
            Name += vowels[r.Next(vowels.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += consonants[r.Next(consonants.Length)];
                b++;
                Name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return Name;
        }
    }
}