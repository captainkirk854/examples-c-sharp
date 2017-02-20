using System.Collections.ObjectModel;  // For ObservableCollection class ..
using SimpleMVVM.BoilerPlate;

namespace SimpleMVVM.Models
{
    public class Database
    {
        private static ObservableCollection<StarTrekCharacter> RowsOfData()
        {
            var Kirk = new StarTrekCharacter
            {
                Appellation = "James T. Kirk",
                Description = "The best, most charismatic of all StarFleet captains.",
                Alliance = "StarFleet",
                Race = "Human"
            };

            var Spock = new StarTrekCharacter
            {
                Appellation = "Spock",
                Description = "The finest of all StarFleet first officers.",
                Alliance = "StarFleet",
                Race = "Vulcan"
            };

            var Picard = new StarTrekCharacter
            {
                Appellation = "Jean-Luc Picard",
                Description = "Surprisingly not too shabby.",
                Alliance = "StarFleet",
                Race = "Human"
            };

            var Riker = new StarTrekCharacter
            {
                Appellation = "William T. Riker",
                Description = "Was Number One to Picard but will always be Number Two to Spock. Grew a beard to not be like Kirk and succeeded.",
                Alliance = "StarFleet",
                Race = "Human"
            };

            var Data = new StarTrekCharacter
            {
                Appellation = "Data",
                Description = "Product of Dr. Noonien Soong",
                Alliance = "StarFleet",
                Race = "Artificial Lifeform"
            };

            var Hugh = new StarTrekCharacter
            {
                Appellation = "Hugh",
                Description = "We are Hugh",
                Alliance = "Borg",
                Race = "Borg"
            };

            var Characters = new ObservableCollection<StarTrekCharacter>();
            Characters.Add(Kirk);
            Characters.Add(Spock);
            Characters.Add(Picard);
            Characters.Add(Riker);
            Characters.Add(Data);
            Characters.Add(Hugh);

            return Characters;
        }

        public static ObservableCollection<StarTrekCharacter> Select()
        {
            return RowsOfData();
        }
    }
}
