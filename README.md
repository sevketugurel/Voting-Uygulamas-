# Voting App

Welcome to the Voting App! This simple console application allows users to register, vote for their favorite options in predefined categories, and view the voting results. The application is written in C# and uses dictionaries to manage users, categories, and votes.

## Features

### User Registration

Users can register with a unique username. The application checks for duplicate registrations and provides appropriate feedback.

```csharp
votingApp.RegisterUser(username);
```

### Voting

Users can vote for their preferred options in predefined categories. The application displays available categories and options, and users can make their selections.

```csharp
votingApp.Vote(username);
```

### Display Results

The application provides a summary of voting results for each category, including the number of votes for each option and the percentage of total votes.

```csharp
votingApp.DisplayResults();
```

## Usage

1. **Register User:**
   - Enter a unique username when prompted.
   - Duplicate usernames are not allowed.

2. **Vote:**
   - Choose the "Oy Ver" (Vote) option.
   - Select a category from the available options.
   - Choose an option within the selected category to vote for.

3. **Display Results:**
   - Choose the "Sonuçları Göster" (Display Results) option.
   - View the voting results for each category.

4. **Exit:**
   - Choose the "Çıkış" (Exit) option to exit the application.

## Example

```csharp
VotingApp votingApp = new VotingApp();

Console.Write("Enter your username: ");
string username = Console.ReadLine();

votingApp.RegisterUser(username);

while (true)
{
    Console.WriteLine("1. Vote");
    Console.WriteLine("2. Display Results");
    Console.WriteLine("3. Exit");

    Console.Write("Please choose an option: ");
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
            Console.WriteLine("Invalid option.");
            break;
    }
}
```

Feel free to explore and enhance this Voting App according to your needs!
