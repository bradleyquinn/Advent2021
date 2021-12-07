namespace Advent.Days
{
    internal static class Day6
    {
        public static void RunDay6()
        {
            var school = new Ecosystem(puzzleInput, 256);

            Console.WriteLine($"Total Number of Fishies {school.FishCount}");
        }

        private class Ecosystem
        {
            private readonly int _numberOfDays;
            public Ecosystem(List<int> puzzleInput, int numberOfDays)
            {
                _numberOfDays = numberOfDays;

                var schools = puzzleInput.GroupBy(x => x).ToList();

                foreach (var school in schools)
                {
                    Schools.Add(new School
                    {
                        DaysLeftBeforeSpawn = school.Key,
                        FishInSchool = school.Count()
                    });
                }

                RunSimulation();
            }

            public List<School> Schools { get; set; } = new List<School>();
            public long FishCount => Schools.Sum(s => s.FishInSchool);

            private void RunSimulation()
            {
                for (int i = 0; i < _numberOfDays; i++)
                {
                    long newFishies = 0;

                    foreach (var school in Schools)
                    {
                        school.DaysLeftBeforeSpawn--;

                        if (school.DaysLeftBeforeSpawn == -1)
                        {
                            school.ResetSpawnDays();

                            newFishies += school.FishInSchool;
                        }
                    }

                    if (newFishies > 0)
                    {
                        Schools.Add(new School
                        {
                            FishInSchool = newFishies
                        }); 
                    }
                }
            }
        }

        private class School
        {
            public int DaysLeftBeforeSpawn { get; set; } = 8;
            public long FishInSchool { get; set; } = 0;

            public void ResetSpawnDays()
            {
                DaysLeftBeforeSpawn = 6;
            }
        }

        private static readonly List<int> testInput = new()
        {
            3,
            4,
            3,
            1,
            2
        };

        private static readonly List<int> puzzleInput = new()
        {
            5,
            4,
            3,
            5,
            1,
            1,
            2,
            1,
            2,
            1,
            3,
            2,
            3,
            4,
            5,
            1,
            2,
            4,
            3,
            2,
            5,
            1,
            4,
            2,
            1,
            1,
            2,
            5,
            4,
            4,
            4,
            1,
            5,
            4,
            5,
            2,
            1,
            2,
            5,
            5,
            4,
            1,
            3,
            1,
            4,
            2,
            4,
            2,
            5,
            1,
            3,
            5,
            3,
            2,
            3,
            1,
            1,
            4,
            5,
            2,
            4,
            3,
            1,
            5,
            5,
            1,
            3,
            1,
            3,
            2,
            2,
            4,
            1,
            3,
            4,
            3,
            3,
            4,
            1,
            3,
            4,
            3,
            4,
            5,
            2,
            1,
            1,
            1,
            4,
            5,
            5,
            1,
            1,
            3,
            2,
            4,
            1,
            2,
            2,
            2,
            4,
            1,
            2,
            5,
            5,
            1,
            4,
            5,
            2,
            4,
            2,
            1,
            5,
            4,
            1,
            3,
            4,
            1,
            2,
            3,
            1,
            5,
            1,
            3,
            4,
            5,
            4,
            1,
            4,
            3,
            3,
            3,
            5,
            5,
            1,
            1,
            5,
            1,
            5,
            5,
            1,
            5,
            2,
            1,
            5,
            1,
            2,
            3,
            5,
            5,
            1,
            3,
            3,
            1,
            5,
            3,
            4,
            3,
            4,
            3,
            2,
            5,
            2,
            1,
            2,
            5,
            1,
            1,
            1,
            1,
            5,
            1,
            1,
            4,
            3,
            3,
            5,
            1,
            1,
            1,
            4,
            4,
            1,
            3,
            3,
            5,
            5,
            4,
            3,
            2,
            1,
            2,
            2,
            3,
            4,
            1,
            5,
            4,
            3,
            1,
            1,
            5,
            1,
            4,
            2,
            3,
            2,
            2,
            3,
            4,
            1,
            3,
            4,
            1,
            4,
            3,
            4,
            3,
            1,
            3,
            3,
            1,
            1,
            4,
            1,
            1,
            1,
            4,
            5,
            3,
            1,
            1,
            2,
            5,
            2,
            5,
            1,
            5,
            3,
            3,
            1,
            3,
            5,
            5,
            1,
            5,
            4,
            3,
            1,
            5,
            1,
            1,
            5,
            5,
            1,
            1,
            2,
            5,
            5,
            5,
            1,
            1,
            3,
            2,
            2,
            3,
            4,
            5,
            5,
            2,
            5,
            4,
            2,
            1,
            5,
            1,
            4,
            4,
            5,
            4,
            4,
            1,
            2,
            1,
            1,
            2,
            3,
            5,
            5,
            1,
            3,
            1,
            4,
            2,
            3,
            3,
            1,
            4,
            1,
            1
        };
    }
}
