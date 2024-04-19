using NUnit.Framework.Internal;
using System.Runtime.CompilerServices;

namespace LT.DevScreen;

internal static class OneHundredPrisoners
{
    /// <summary>
    /// An integer array representing the prisoners in the problem.
    /// The index of an element represents the prisoner's position in the sequence of prisoners.
    /// The value of an element represents the prisoner's number.
    /// </summary>
    static int[] Prisoners = Enumerable.Range(1, 100).ToArray();

    /// <summary>
    /// Simulates a trial run of the 100 prisoners problem.
    /// Each prisoner has to find their own number in one of 100 drawers,
    /// but may open no more than 50 of the drawers.
    ///
    /// See readme.md for more information.
    /// </summary>
    /// <returns>
    /// True when all prisoners find their own number; false otherwise.
    /// </returns>
    public static bool RunSimulation()
    {
        // An integer array representing the drawers in the problem.
        // The index of an element represents the number of the drawer.
        // The value of an element represents the number inside the drawer.
        int[] Drawers = GetShuffledArray();

        int prisonerAttempts, prisonerNumber, drawerIndex, drawerNumber;
        bool doFreePrisoner = false;

        // each prisoner will attempt to find their number in a drawer within 50 attempts
        for(var i = 0; i < Prisoners.Length; i++)
        {
            // prisoner is getting ready to attempt to find their number in a drawer

            // get the prisoner's number
            prisonerNumber = Prisoners[i];
            // at this point the prisoner has made no attempts to find their number in a drawer
            prisonerAttempts = 0;
            // the first drawer the prisoner will try is the drawer labelled with their number
            drawerIndex = prisonerNumber;

            // the prisoner will get 50 chances to find their number in a drawer
            while (prisonerAttempts < 50)
            {
                // prisoner opens drawer to get the number in the drawer
                drawerNumber = Drawers[drawerIndex - 1];

                // since the prisoner has opened the drawer and seen the number inside, this constitutes an attempt having been made to find their number
                prisonerAttempts++;

                // if the number the prisoner found in the drawer is their number
                if (drawerNumber == prisonerNumber)
                {
                    // this prisoner has the hope of being freed
                    doFreePrisoner = true;
                    // move on to the next prisoner
                    break;
                }
                // if the number the prisoner found in the drawer is not their number
                else
                {
                    // determine the next drawer that should be checked is the drawer that is labelled with the number the prisoner found in the current drawer
                    drawerIndex = drawerNumber;
                }
            }

            // at this point the prisoner has either found their number in a drawer and has hope of being freed or the prisoner did not find their number in a drawer, which means, not only will this prisoner not be freed, but none of the prisoners will be freed

            // if this prisoner did not find their number in a drawer and has no hope of being freed
            if (!doFreePrisoner)
            {
                // return false to show that not all prisoners found their number in a drawer
                return false;
            }

            // if we made it here that means the prisoner did find their number in a drawer and we can reset the hopefulness of being freed to false for the next prisoner
            doFreePrisoner = false;
        }

        // if we made it here return true, which means that all prisoners found their number in a drawer and will be freed
        return true;
    }

    /// <summary>
    /// Generates a random sequence of integers from 1 to 100
    /// </summary>
    /// <returns></returns>
    private static int[] GetShuffledArray()
    {
        // create a list of numbers 1 through 100
        var list = new List<int>(Enumerable.Range(1, 100));

        // shuffle the list of numbers
        var random = new Random();
        var index = list.Count;
        int randomIndex, value;

        while (index-- > 1)
        {
            randomIndex = random.Next(index + 1);
            value = list[randomIndex];
            list[randomIndex] = list[index];
            list[index] = value;
        }

        // return as an array
        return list.ToArray();
    }
}