Hangman Game 🎮

A console-based Hangman game built in C# with OOP principles, JSON-based persistence, and Spectre.Console for styling. This project includes features like error handling, FluentValidation for input validation, and a clean architecture.

📌 Features

✅ Object-Oriented Design (OOP) – Uses interfaces and classes for modularity✅ Generics & Methods – Improved reusability and flexibility✅ Error Handling – Includes try-catch blocks for robust error management✅ JSON Persistence – Saves game data (word list) to hangman_history.json✅ LINQ Support – Efficient data handling✅ Spectre.Console Styling – Beautiful console UI✅ Keyboard Navigation – User-friendly input handling✅ Branch Protection Rules – Encourages collaborative development via GitHub

🛠️ Installation & Setup

Clone the repository:

git clone https://github.com/yourusername/HangmanGame.git

Navigate to the project folder:

cd HangmanGame

Build & Run:

Open the project in Visual Studio or VS Code

Run the application using:

dotnet run

🎮 How to Play

The game selects a random word from the hangman_history.json file.

You have 6 attempts to guess the correct word.

Enter one letter at a time.

If you guess correctly, the letter is revealed.

If you run out of attempts, Game Over!

You can choose to play again or exit.

💂️🏻 Project Structure

HangmanGame/
│── Program.cs         # Entry point
│── HangmanGame.cs     # Core game logic
│── IGame.cs           # Interface for game structure
│── hangman_history.json # Stores word list
│── README.md          # Project documentation
│── .gitignore         # Git ignored files
│── UML_Diagram.png    # UML diagram of game logic (optional)

📝 Technologies Used

C# – Core programming language

.NET Core – Framework for the console application

Spectre.Console – Console UI styling

Figgle – ASCII text styling

JSON Serialization – Storing & loading game data

LINQ – Querying collections efficiently

🔍 UML & Flowchart (Optional)

If applicable, add UML diagrams or flowcharts to illustrate program flow.

🛠 Future Enhancements



🤝 Contribution

Contributions are welcome! Please follow these steps:

Fork the repository

Create a branch

git checkout -b feature-branch

Commit your changes

git commit -m "Added new feature"

Push to the branch

git push origin feature-branch

Create a Pull Request on GitHub

🔒 Branch Protection Rules

All development must be done via branches (no direct pushes to main)

Pull requests must be reviewed before merging

Unit tests should pass before merging PRs

🐜 License

This project is licensed under the MIT License.

👨‍💻 Author

Your NameGitHub: yourusernameLinkedIn: Your Profile
