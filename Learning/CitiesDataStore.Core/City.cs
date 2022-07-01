namespace CitiesDataStore.Core
{
    public class City
    {
        public int Id;

        public string Name;

        public string Description;

        public int NumberOfPointsOfInterest;

        public City(int id, string name, string description, int numberOfPointsOfInterest)
        {
            Id = id;
            Name = name;
            Description = description;
            NumberOfPointsOfInterest = numberOfPointsOfInterest;
        }

        public City()
        {
        }

    }
}
