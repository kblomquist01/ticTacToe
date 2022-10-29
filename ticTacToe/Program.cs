using System;

namespace ticTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] row1 = new string[3] {"1", "2", "3"};
            string[] row2 = new string[3] {"4", "5", "6"};
            string[] row3 = new string[3] {"7", "8", "9"}; 
            
            string[][] board = new string[3][] {row1, row2, row3};
 
            bool play = true;
            int turnNum = 1;

            while(play)
            {
                // goes through each players turn then checks if they won
                if(play)
                {
                    turn("x", board);
                    play = winCondition("x", board, turnNum);
                    turnNum++;
                }
                if(play)
                {
                    turn("y", board);
                    play = winCondition("y", board, turnNum);
                    turnNum++;
                }
            }
            printBoard(board);
        }

        public static void turn(string player, string[][] board)
        {
        
            bool test = true;
            bool valid = false;

            while(test)
            {
                printBoard(board);

                Console.WriteLine("where do you want to place your " + player + " (1-9): ");
                int choice = Convert.ToInt32(Console.ReadLine());
                int spot = 0;
                // goes through each row (string[]) on the board
                for(int row = 1; row < 4; row += 1)
                {
                    // checks if the row contains your choice
                    if(row * 3 >= choice && choice > row * 3 - 3)
                    {
                        // goes through each index in each row
                        for(int collumn = 0; collumn < 3; collumn++)
                        {
                            // if choice is valid set choice to player character
                            valid = (test && int.TryParse(board[row - 1][collumn], out spot) && spot == choice);
                            if(valid)
                            {
                                board[row - 1][collumn] = player;
                                test = false;
                            }
                        }
                    }
                }

                if(!valid)
                {
                    Console.WriteLine("Please choose a VALID spot");
                }
            }
        }
        
        public static void printBoard(string[][] board)
        {
            // prints board
            Console.WriteLine(string.Join("|", board[0]));
            Console.WriteLine("-----");
            Console.WriteLine(string.Join("|", board[1]));
            Console.WriteLine("-----");
            Console.WriteLine(string.Join("|", board[2]));

        }
        
        public static bool winCondition(string player, string[][] board, int turnNum)
        {
            for(int row = 0; row < 3; row++)
            {
                for(int collumn = 0; collumn < 3; collumn++)
                {
                    // row doesnt matter here i just picked one so it would
                    //only test once per collumn
                    if(row == 0 && isBelow(player, collumn, board))
                    {
                        Console.WriteLine("Congrats! player " + player + " wins!");
                        return false;
                    }
                    // collumn doesnt matter here, i just picked one so that it would
                    // only test once per row
                    else if(collumn == 0 && isRight(player, row, board))
                    {
                        Console.WriteLine("Congrats! player " + player + " wins!");
                        return false;
                    }
                    // row and collumn number doesnt matter here, i just picked one so that
                    // it would only test these once
                    else if(row == 0 && collumn == 0 && isAngleRight(player, board))
                    {
                        Console.WriteLine("Congrats! player " + player + " wins!");
                        return false;
                    }
                    // row and collumn number doesnt matter here, i just picked one so that
                    // it would only test these once
                    else if(row == 0 && collumn == 0 && isAngleLeft(player, board))
                    {
                        Console.WriteLine("Congrats! player " + player + " wins!");
                        return false;
                    }
                }
            }
            // tests if it is a tie
            if(turnNum == 9)
            {
                Console.WriteLine("Its a tie!");
                return false;
            }
            else
            {
                // continue playing if you dont win
                return true;
            }
        }

        public static bool isBelow(string player, int collumn, string[][] board)
        {
            //tests if you have a vertical win
            for(int row = 0; row < 3; row++)
            {
                if(board[row][collumn] != player){
                    return false;
                }
            }
            return true;
        }
        public static bool isRight(string player, int row, string[][] board)
        {
            //tests if you have a horizontal win
            for(int collumn = 0; collumn < 3; collumn++)
            {
                if(board[row][collumn] != player){
                    return false;
                }
            }
            return true;
        }
        public static bool isAngleRight(string player, string[][] board)
        {
            //tests if you have a diagnal win from top left to bottom right
            for(int position = 0; position < 3; position++)
            {
                if(board[position][position] != player){
                    return false;
                }
            }
            return true;
        }
        public static bool isAngleLeft(string player, string[][] board)
        {
            //tests if you have a diagnal win from top right to bottom left
            for(int position = 0; position < 3; position++)
            {
                if(board[position][position * -1 + 2] != player){
                    return false;
                }
            }
            return true;
        }
    }
}
