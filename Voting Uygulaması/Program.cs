using System;
using System.Collections.Generic;

class VotingApp
{
    private Dictionary<string, bool> users;
    private Dictionary<string, HashSet<string>> categories;
    private Dictionary<string, Dictionary<string, int>> votes;

    public VotingApp()
    {
        users = new Dictionary<string, bool>();
        categories = new Dictionary<string, HashSet<string>>()
        {
            { "Film", new HashSet<string> { "Avengers", "Inception", "Titanic" } },
            { "Tech Stack", new HashSet<string> { "Python", "JavaScript", "Java" } },
            { "Spor", new HashSet<string> { "Football", "Basketball", "Tennis" } }
        };
        votes = new Dictionary<string, Dictionary<string, int>>();
        foreach (var category in categories.Keys)
        {
            votes[category] = new Dictionary<string, int>();
            foreach (var option in categories[category])
            {
                votes[category][option] = 0;
            }
        }
    }

    public void RegisterUser(string username)
    {
        if (!users.ContainsKey(username))
        {
            users[username] = true;
            Console.WriteLine($"Kullanıcı '{username}' başarıyla kaydedildi.");
        }
        else
        {
            Console.WriteLine($"Kullanıcı '{username}' zaten kayıtlı.");
        }
    }

    public void Vote(string username)
    {
        Console.WriteLine("Kategoriler:");
        foreach (var category in categories.Keys)
        {
            Console.WriteLine(category);
        }

        Console.Write("Lütfen oy vermek istediğiniz kategoriyi seçin: ");
        string selectedCategory = Console.ReadLine();

        if (!categories.ContainsKey(selectedCategory))
        {
            Console.WriteLine("Geçersiz kategori.");
            return;
        }

        Console.WriteLine($"Seçili kategori: {selectedCategory}");
        Console.WriteLine("Seçenekler:");
        foreach (var option in categories[selectedCategory])
        {
            Console.WriteLine(option);
        }

        Console.Write("Lütfen oy vermek istediğiniz seçeneği seçin: ");
        string selectedOption = Console.ReadLine();

        if (!categories[selectedCategory].Contains(selectedOption))
        {
            Console.WriteLine("Geçersiz seçenek.");
            return;
        }

        if (!votes[selectedCategory].ContainsKey(selectedOption))
        {
            votes[selectedCategory][selectedOption] = 1;
        }
        else
        {
            votes[selectedCategory][selectedOption]++;
        }

        Console.WriteLine($"'{selectedOption}' seçeneğine oy verildi.");
    }

    public void DisplayResults()
    {
        Console.WriteLine("Voting Sonuçları:");
        foreach (var category in categories.Keys)
        {
            Console.WriteLine($"{category} Kategorisi:");

            foreach (var option in categories[category])
            {
                int voteCount = votes[category][option];
                Console.WriteLine($"{option}: {voteCount} oy ({(voteCount / (float)users.Count) * 100:F2}%)");
            }

            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        VotingApp votingApp = new VotingApp();

        Console.Write("Lütfen kullanıcı adınızı girin: ");
        string username = Console.ReadLine();

        votingApp.RegisterUser(username);

        while (true)
        {
            Console.WriteLine("1. Oy Ver");
            Console.WriteLine("2. Sonuçları Göster");
            Console.WriteLine("3. Çıkış");

            Console.Write("Lütfen bir seçenek girin: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    votingApp.Vote(username);
                    break;
                case "2":
                    votingApp.DisplayResults();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Geçersiz seçenek.");
                    break;
            }
        }
    }
}
