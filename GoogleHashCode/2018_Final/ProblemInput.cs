﻿namespace _2018_Final
{
    public class ProblemInput
    {
        public int Height { get; set; }

        public int Width { get; set; }

        public int MaxDistance { get; set; }

        public BuildingProject[] BuildingProjects { get; set; }
    }

    public class BuildingProject
    {
        public bool[,] Plan { get; set; }

        public BuildingType BuildingType { get; set; }

        public int Capacity { get; set; }

        public int UtilityType { get; set; }
    }

    public enum BuildingType
    {
        Residential,
        Utility
    }
}