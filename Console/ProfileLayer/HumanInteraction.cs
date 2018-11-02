using System;

namespace tic_tac_toe.Console.ProfileLayer
{
    public static class HumanInteraction
    {
        public static int GetSpotFromHuman(bool isAvailable, MarkEnum mark)
        {
            if (isAvailable)
            {
                System.Console.WriteLine("Choose an available space to mark a {0}", mark.ToString());
            }
            else
                System.Console.WriteLine("Space is already filled, please, choose an available space to mark a {0}", mark.ToString());
            Int32.TryParse(System.Console.ReadLine(), out var selectedSpace);
            while (selectedSpace < 1 || selectedSpace > 9)
            {
                System.Console.WriteLine("Space is out of boundary, please, choose an available space to mark a {0}", mark.ToString());
                Int32.TryParse(System.Console.ReadLine(), out selectedSpace);
            }
            return selectedSpace;
        }
    }
}