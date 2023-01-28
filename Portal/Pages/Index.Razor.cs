namespace Portal.Pages
{
    public partial class Index
    {
        private int numOfPlayers = 2;
        public bool showNew = false;
        public string[] Name { get; set; } = new string[6];

        public int NumOfPlayers
        {
            get
            {
                return numOfPlayers;
            }
            set
            {
                if (value > 1 && 5 >= value)
                    numOfPlayers = value;
                else
                    numOfPlayers = 2;
            }
        }
        public void Save()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < NumOfPlayers; i++)
            {
                if (Name[i] == null)
                    Name[i] = "Player " + (i + 1);
                list.Add(Name[i]);
            }
            CommanderService.CreatePlayers(NumOfPlayers, list);
            showNew = false;
        }

        public void MakeNewGame() => showNew = true;
    }
}
