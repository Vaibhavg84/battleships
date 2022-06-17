using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    // Imagine a game of battleships.
    //   The player has to guess the location of the opponent's 'ships' on a 10x10 grid
    //   Ships are one unit wide and 2-4 units long, they may be placed vertically or horizontally
    //   The player asks if a given co-ordinate is a hit or a miss
    //   Once all cells representing a ship are hit - that ship is sunk.
    public class Game
    {
        // ships: each string represents a ship in the form first co-ordinate, last co-ordinate
        //   e.g. "3:2,3:5" is a 4 cell ship horizontally across the 4th row from the 3rd to the 6th column
        // guesses: each string represents the co-ordinate of a guess
        //   e.g. "7:0" - misses the ship above, "3:3" hits it.
        // returns: the number of ships sunk by the set of guesses
        public static int Play(string[] ships, string[] guesses)
        {
            List<int> lstGuess = new List<int>();
            int ship_startingPos, ship_EndPos;
            List<int> shipsCordinates = new List<int>();
            Dictionary<string, List<int>> dicShips = new Dictionary<string, List<int>>();
            int count = 0;
            foreach (string ship in ships) // Ships Positions
            {
                count = count + 1;
                ship_startingPos = Convert.ToInt32(ship.Split(',')[0].Replace(":", ""));
                ship_EndPos = Convert.ToInt32(ship.Split(',')[1].Replace(":", ""));
                if (ship_EndPos - ship_startingPos < 8) // horizontal ship
                {
                    shipsCordinates = new List<int>();
                    for (int i = ship_startingPos; i <= ship_EndPos; i++)
                    {
                        shipsCordinates.Add(i);
                    }
                    dicShips.Add("Ship" + count, shipsCordinates);

                }
                else
                {
                    shipsCordinates = new List<int>();
                    for (int i = ship_startingPos; i <= ship_EndPos; i = i + 10)
                    {
                        shipsCordinates.Add(i);
                    }
                    dicShips.Add("Ship" + count, shipsCordinates);
                }
            }
            foreach (string guess in guesses)
            {
                lstGuess.Add(Convert.ToInt32(guess.Replace(":", "")));
            }
            foreach (int number in lstGuess)
            {
                foreach (var details in dicShips)
                {
                    if (details.Value.Contains(number))
                    {
                        details.Value.Remove(number);
                    }
                }
            }
            int shipsCount = 0;
            foreach (var details in dicShips)
            {
                if (details.Value.Count == 0)
                {
                    shipsCount = shipsCount + 1;
                }

            }
            return shipsCount;
        }
    }
}
