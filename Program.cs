namespace GuessGame
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose the max value");
            int maxN = ReadInt();

            var game = new Game(maxN);
            game.Start();
        }

        static public int ReadInt()
        {
            int.TryParse(Console.ReadLine(), out int value);
            return value;
        }
    }

    public class Game
    {
        private int _maxN;
        private int _randomNumber;
        private int _score;
        private int _guess;

        public Game(int maxN)
        {
            _maxN = maxN;
            _randomNumber = new Random().Next(maxN);
            _score = 0;
        }

        public void Start()
        {
            WriteRules();
            MakeGuess();
            while (!Finished())
            {
                GiveClue();
                MakeGuess();
            }
            WriteFinish();
        } 

        public void WriteRules()
        {
            Console.WriteLine("Make a guess between the number 0 and {0}", _maxN);
        }

        public void MakeGuess()
        {
            _guess = Program.ReadInt();
            UpdateScore(1);
        }

        public bool Finished()
        {
            return _guess == _randomNumber;
        }

        public void UpdateScore(int amount)
        {
            _score += amount;
        }

        public void GiveClue()
        {
            var clue = _guess > _randomNumber ? "Your guess was too high" : "Your guess was too low";
            Console.WriteLine(clue);
        }

        public void WriteFinish()
        {
            Console.WriteLine("You won! With a score of {0}", _score);
        }
    }
}