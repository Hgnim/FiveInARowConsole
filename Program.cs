using System.Text;
using System.Text.RegularExpressions;

namespace FiveInARowConsole
{
    class Program
    {
        static readonly string version = "1.0.2.20240307";
        static void Main(string[] args)
        {
            ConsoleWrite.def();
            ConsoleWrite.ConsoleLocWrite("五子棋", -1, -1, ConsoleWrite.defBack, ConsoleWrite.defFore, true);
            ConsoleWrite.ConsoleLocWrite("[开始]", -1, -1, ConsoleColor.Green, ConsoleColor.Black, true);
            ConsoleWrite.ConsoleLocWrite("[关于]", -1, -1, ConsoleColor.White, ConsoleColor.Black, true);
            int buttonID = 1;

            while (true)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.DownArrow)
                {
                    switch (buttonID)
                    {
                        case 1:
                            ConsoleWrite.ConsoleLocWrite("[开始]", 0, 1, ConsoleColor.White, ConsoleColor.Black, true);
                            ConsoleWrite.ConsoleLocWrite("[关于]", 0, 2, ConsoleColor.Green, ConsoleColor.Black, true);
                            buttonID = 2;
                            break;
                        case 2: break;
                    }
                }
                else if (cki.Key == ConsoleKey.UpArrow)
                {
                    switch (buttonID)
                    {
                        case 1:
                            break;
                        case 2:
                            ConsoleWrite.ConsoleLocWrite("[开始]", 0, 1, ConsoleColor.Green, ConsoleColor.Black, true);
                            ConsoleWrite.ConsoleLocWrite("[关于]", 0, 2, ConsoleColor.White, ConsoleColor.Black, true);
                            buttonID = 1;
                            break;
                    }
                }
                else if (cki.Key == ConsoleKey.Enter)
                {
                    switch (buttonID)
                    {
                        case 1:
                            goto play;
                        case 2:
                            Copyright cop=new Copyright();
                            ConsoleWrite.setCursor(0, 4);
                            Console.WriteLine("五子棋命令行版:");
                            Console.WriteLine("版本:V{0}", version);
                            Console.WriteLine(cop.GetC());
                            break;
                    }
                }
            }
        play:;

            int[,] locationStatus = new int[15, 15];//表示各坐标的状态，0：无棋子；1：O棋子；2：X棋子
            ConsoleWrite.def();

            //Console.WriteLine(consLoc);

            for (int line = 0; line <= 15 + 1; line++)
            {

                StringBuilder outputStr = new StringBuilder();

                if (line == 0 || line == 16)//输出首行和末尾行的目录
                {
                    outputStr = new StringBuilder();
                    string headStr = "";
                    for (int i = 0; i <= 16; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                headStr = " +"; break;
                            case 1:
                                headStr = "A"; break;
                            case 2:
                                headStr = "B"; break;
                            case 3:
                                headStr = "C"; break;
                            case 4:
                                headStr = "D"; break;
                            case 5:
                                headStr = "E"; break;
                            case 6:
                                headStr = "F"; break;
                            case 7:
                                headStr = "G"; break;
                            case 8:
                                headStr = "H"; break;
                            case 9:
                                headStr = "I"; break;
                            case 10:
                                headStr = "J"; break;
                            case 11:
                                headStr = "K"; break;
                            case 12:
                                headStr = "L"; break;
                            case 13:
                                headStr = "M"; break;
                            case 14:
                                headStr = "N"; break;
                            case 15:
                                headStr = "O"; break;
                            case 16:
                                headStr = "+"; break;
                        }
                        outputStr.Append(headStr);
                        outputStr.Append(" ");
                    }
                    ConsoleWrite.ConsoleLocWrite(outputStr.ToString(), -1, -1, ConsoleColor.Gray, ConsoleColor.Black, false);
                    //Console.BackgroundColor = ConsoleColor.Gray;
                    //Console.ForegroundColor = ConsoleColor.Black;
                    //Console.Write(outputStr.ToString());
                    ConsoleWrite.ConsoleLocWrite("", -1, -1, ConsoleWrite.defBack, ConsoleWrite.defFore, true);
                    //Console.BackgroundColor = defBack;
                    //Console.ForegroundColor = defFore;
                    //Console.WriteLine("");
                }
                else
                {
                    void doWrite(int id, int i)
                    {
                        switch (id)
                        {
                            case 0:
                                Console.Write("- "); break;
                            case 1:
                                Console.Write("= "); break;
                            case 2:
                                Console.Write(" - "); break;
                        }
                        locationStatus[i - 1, line - 1] = 0;
                        //Console.Write(" - ");
                    }
                    for (int i = 0; i <= 16; i++)
                    {
                        if (i == 0 || i == 16)//输出首列和尾列的目录
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;

                            if (line < 10 || line == 16)
                            {
                                Console.Write("{0} ", line);
                            }
                            else { Console.Write("{0}", line); }
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            if (i == 1)
                            {
                                doWrite(2, i);
                            }
                            else if (line == 4 || line == 12 || line == 8)
                            {
                                if (line == 4 && i == 4)
                                {
                                    doWrite(1, i);
                                }
                                else if (line == 4 && i == 12)
                                {
                                    doWrite(1, i);
                                }
                                else if (line == 12 && i == 4)
                                {
                                    doWrite(1, i);
                                }
                                else if (line == 12 && i == 12)
                                {
                                    doWrite(1, i);
                                }
                                else if (line == 8 && i == 8)
                                {
                                    doWrite(1, i);
                                }
                                else
                                {
                                    doWrite(0, i);
                                }
                            }
                            else
                            {
                                doWrite(0, i);
                            }

                        }
                    }
                    Console.BackgroundColor = ConsoleWrite.defBack;
                    Console.ForegroundColor = ConsoleWrite.defFore;
                    Console.WriteLine("");
                }
            }
            ConsoleWrite.ConsoleLocWrite("五子棋-游戏开始", 1 + 2 * (15 + 2) + 1, 0, ConsoleWrite.defBack, ConsoleWrite.defFore, true);
            //Console.SetCursorPosition(2*(15 + 2), consTopLoc + 1);
            //Console.BackgroundColor = defBack;
            //Console.ForegroundColor = defFore;
            //Console.WriteLine("五子棋-游戏开始");

            int playerID = 1;
            string inputRead; string[] inputReadS;
            string[] locationString = new string[2]; int[] locationInt = new int[2];
            string againString = ""; int[] gameOverDate = new int[4];
            while (true)
            {
                inputRead = ""; inputReadS = new string[0]; locationString = new string[2]; locationInt = new int[2];
                switch (playerID)
                {
                    case 1:
                        ConsoleWrite.ConsoleLocWrite("O", 1 + 2 * (15 + 2) + 1, 1, ConsoleColor.White, ConsoleColor.Blue, false);
                        break;
                    case 2:
                        ConsoleWrite.ConsoleLocWrite("X", 1 + 2 * (15 + 2) + 1, 1, ConsoleColor.White, ConsoleColor.Red, false);
                        break;
                }
                ConsoleWrite.ConsoleLocWrite("方出棋:               ", 1 + 2 * (15 + 2) + 1 + 1, 1, ConsoleWrite.defBack, ConsoleWrite.defFore, false);
                ConsoleWrite.setCursor(1 + 2 * (15 + 2) + 1 + 1 + (2 + 3 * 2), 1);
                inputRead = Console.ReadLine()!;
                if (inputRead == "")
                {
                    againString = "locationError";
                    goto again;
                }
                else if (inputRead.IndexOf(",") != -1)
                {
                    inputReadS = inputRead.Split(",");
                    if (new Regex("^[0-9]$").IsMatch(inputReadS[0]) == true && new Regex("^[a-oA-O]$").IsMatch(inputReadS[1]) == true)
                    {
                        locationString[0] = inputReadS[1];//将输入的位置数据按顺序写入变量。（字母，数字）
                        locationString[1] = inputReadS[0];
                    }
                    else if (new Regex("^[0-9]$").IsMatch(inputReadS[1]) == true && new Regex("^[a-oA-O]$").IsMatch(inputReadS[0]) == true)
                    {
                        locationString[0] = inputReadS[0];
                        locationString[1] = inputReadS[1];
                    }
                    else
                    {
                        againString = "locationError";
                        goto again;
                    }
                }
                else//如果没有逗号，则逐字分开
                {
                    string tempStr;
                    for (int i = 0; i < inputRead.Length; i++)
                    {
                        tempStr = inputRead.Substring(i, 1);
                        if (new Regex("^[0-9]$").IsMatch(tempStr) == true)
                        {
                            locationString[1] += tempStr;
                        }
                        else if (new Regex("^[a-oA-O]$").IsMatch(tempStr) == true)
                        {
                            locationString[0] += tempStr;
                        }
                    }
                }
                if (locationString[0] != null && locationString[1] != null && int.Parse(locationString[1]) >= 1 && int.Parse(locationString[1]) <= 15 && locationString[0].Length == 1)
                {
                    locationInt[1] = int.Parse(locationString[1]);
                    switch (locationString[0])
                    {//将字母转换为int值数据
                        case "a":
                        case "A":
                            locationInt[0] = 1; break;
                        case "b":
                        case "B":
                            locationInt[0] = 2; break;
                        case "c":
                        case "C":
                            locationInt[0] = 3; break;
                        case "d":
                        case "D":
                            locationInt[0] = 4; break;
                        case "e":
                        case "E":
                            locationInt[0] = 5; break;
                        case "f":
                        case "F":
                            locationInt[0] = 6; break;
                        case "g":
                        case "G":
                            locationInt[0] = 7; break;
                        case "h":
                        case "H":
                            locationInt[0] = 8; break;
                        case "i":
                        case "I":
                            locationInt[0] = 9; break;
                        case "j":
                        case "J":
                            locationInt[0] = 10; break;
                        case "k":
                        case "K":
                            locationInt[0] = 11; break;
                        case "l":
                        case "L":
                            locationInt[0] = 12; break;
                        case "m":
                        case "M":
                            locationInt[0] = 13; break;
                        case "n":
                        case "N":
                            locationInt[0] = 14; break;
                        case "o":
                        case "O":
                            locationInt[0] = 15; break;
                    }

                    if (locationStatus[locationInt[0] - 1, locationInt[1] - 1] == 0)
                    {
                        locationStatus[locationInt[0] - 1, locationInt[1] - 1] = playerID;
                        #region 判断是否获胜
                        int[] tempLoc;
                        int[] chessNumber = new int[4];//已经延伸的棋子个数
                        if (locationInt[0] - 1 - 1 >= 1 - 1 &&
                            locationStatus[locationInt[0] - 1 - 1, locationInt[1] - 1] == playerID)//向左延伸
                        {
                            chessNumber[0] += 2;
                            tempLoc = new int[2] { locationInt[0], locationInt[1] };
                            tempLoc[0]--;//继续向该方向移动坐标
                            for (int i = 0; i < 3; i++, tempLoc[0]--)
                            {
                                if (tempLoc[0] - 1 - 1 >= 1 - 1 &&
                                                            locationStatus[tempLoc[0] - 1 - 1, tempLoc[1] - 1] == playerID)//判断是否还有该方的棋子
                                {
                                    chessNumber[0]++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (chessNumber[0] >= 5)
                            {
                                gameOverDate[0] = tempLoc[0];
                                gameOverDate[1] = tempLoc[1];
                                gameOverDate[2] = 4;
                                gameOverDate[3] = playerID;
                                goto gameOver;
                            }
                        }
                        if (locationInt[0] - 1 - 1 >= 1 - 1 && locationInt[1] - 1 + 1 <= 15 - 1 &&
                            locationStatus[locationInt[0] - 1 - 1, locationInt[1] - 1 + 1] == playerID)//向左下延伸
                        {
                            chessNumber[1] += 2;
                            tempLoc = new int[2] { locationInt[0], locationInt[1] };
                            tempLoc[0]--; tempLoc[1]++;
                            for (int i = 0; i < 3; i++, tempLoc[0]--, tempLoc[1]++)
                            {
                                if (tempLoc[0] - 1 - 1 >= 1 - 1 && tempLoc[1] - 1 + 1 <= 15 - 1 &&
                            locationStatus[tempLoc[0] - 1 - 1, tempLoc[1] - 1 + 1] == playerID)
                                {
                                    chessNumber[1]++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (chessNumber[1] >= 5)
                            {
                                gameOverDate[0] = tempLoc[0];
                                gameOverDate[1] = tempLoc[1];
                                gameOverDate[2] = 1;
                                gameOverDate[3] = playerID;
                                goto gameOver;
                            }
                        }
                        if (locationInt[1] - 1 + 1 <= 15 - 1 &&
                            locationStatus[locationInt[0] - 1, locationInt[1] - 1 + 1] == playerID) //向下延伸
                        {
                            chessNumber[2] += 2;
                            tempLoc = new int[2] { locationInt[0], locationInt[1] };
                            tempLoc[1]++;
                            for (int i = 0; i < 3; i++, tempLoc[1]++)
                            {
                                if (tempLoc[1] - 1 + 1 <= 15 - 1 &&
                            locationStatus[tempLoc[0] - 1, tempLoc[1] - 1 + 1] == playerID)
                                {
                                    chessNumber[2]++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (chessNumber[2] >= 5)
                            {
                                gameOverDate[0] = tempLoc[0];
                                gameOverDate[1] = tempLoc[1];
                                gameOverDate[2] = 2;
                                gameOverDate[3] = playerID;
                                goto gameOver;
                            }
                        }
                        if (locationInt[0] - 1 + 1 <= 15 - 1 && locationInt[1] - 1 + 1 <= 15 - 1 &&
                            locationStatus[locationInt[0] - 1 + 1, locationInt[1] - 1 + 1] == playerID) //向右下延伸
                        {
                            chessNumber[3] += 2;
                            tempLoc = new int[2] { locationInt[0], locationInt[1] };
                            tempLoc[0]++; tempLoc[1]++;
                            for (int i = 0; i < 3; i++, tempLoc[0]++, tempLoc[1]++)
                            {
                                if (tempLoc[0] - 1 + 1 <= 15 - 1 && tempLoc[1] - 1 + 1 <= 15 - 1 &&
                           locationStatus[tempLoc[0] - 1 + 1, tempLoc[1] - 1 + 1] == playerID)
                                {
                                    chessNumber[3]++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (chessNumber[3] >= 5)
                            {
                                gameOverDate[0] = tempLoc[0];
                                gameOverDate[1] = tempLoc[1];
                                gameOverDate[2] = 3;
                                gameOverDate[3] = playerID;
                                goto gameOver;
                            }
                        }
                        if (locationInt[0] - 1 + 1 <= 15 - 1 &&
                            locationStatus[locationInt[0] - 1 + 1, locationInt[1] - 1] == playerID) //向右延伸
                        {
                            chessNumber[0] += 2;
                            tempLoc = new int[2] { locationInt[0], locationInt[1] };
                            tempLoc[0]++;
                            for (int i = 0; i < 3; i++, tempLoc[0]++)
                            {
                                if (tempLoc[0] - 1 + 1 <= 15 - 1 &&
                            locationStatus[tempLoc[0] - 1 + 1, tempLoc[1] - 1] == playerID)
                                {
                                    chessNumber[0]++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (chessNumber[0] >= 5)
                            {
                                gameOverDate[0] = tempLoc[0];
                                gameOverDate[1] = tempLoc[1];
                                gameOverDate[2] = 6;
                                gameOverDate[3] = playerID;
                                goto gameOver;
                            }
                        }
                        if (locationInt[0] - 1 + 1 <= 15 - 1 && locationInt[1] - 1 - 1 >= 1 - 1 &&
                            locationStatus[locationInt[0] - 1 + 1, locationInt[1] - 1 - 1] == playerID) //向右上延伸
                        {
                            chessNumber[1] += 2;
                            tempLoc = new int[2] { locationInt[0], locationInt[1] };
                            tempLoc[0]++; tempLoc[1]--;
                            for (int i = 0; i < 3; i++, tempLoc[0]++, tempLoc[1]--)
                            {
                                if (tempLoc[0] - 1 + 1 <= 15 - 1 && tempLoc[1] - 1 - 1 >= 1 - 1 &&
                            locationStatus[tempLoc[0] - 1 + 1, tempLoc[1] - 1 - 1] == playerID)
                                {
                                    chessNumber[1]++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (chessNumber[1] >= 5)
                            {
                                gameOverDate[0] = tempLoc[0];
                                gameOverDate[1] = tempLoc[1];
                                gameOverDate[2] = 9;
                                gameOverDate[3] = playerID;
                                goto gameOver;
                            }
                        }
                        if (locationInt[1] - 1 - 1 >= 1 - 1 &&
                            locationStatus[locationInt[0] - 1, locationInt[1] - 1 - 1] == playerID) //向上延伸
                        {
                            chessNumber[2] += 2;
                            tempLoc = new int[2] { locationInt[0], locationInt[1] };
                            tempLoc[1]--;
                            for (int i = 0; i < 3; i++, tempLoc[1]--)
                            {
                                if (tempLoc[1] - 1 - 1 >= 1 - 1 &&
                            locationStatus[tempLoc[0] - 1, tempLoc[1] - 1 - 1] == playerID)
                                {
                                    chessNumber[2]++;
                                }
                                else { break; }
                            }
                            if (chessNumber[2] >= 5)
                            {
                                gameOverDate[0] = tempLoc[0];
                                gameOverDate[1] = tempLoc[1];
                                gameOverDate[2] = 8;
                                gameOverDate[3] = playerID;
                                goto gameOver;
                            }
                        }
                        if (locationInt[0] - 1 - 1 >= 1 - 1 && locationInt[1] - 1 - 1 >= 1 - 1 &&
                            locationStatus[locationInt[0] - 1 - 1, locationInt[1] - 1 - 1] == playerID) //向左上延伸
                        {
                            chessNumber[3] += 2;
                            tempLoc = new int[2] { locationInt[0], locationInt[1] };
                            tempLoc[0]--; tempLoc[1]--;
                            for (int i = 0; i < 3; i++, tempLoc[0]--, tempLoc[1]--)
                            {
                                if (tempLoc[0] - 1 - 1 >= 1 - 1 && tempLoc[1] - 1 - 1 >= 1 - 1 &&
                            locationStatus[tempLoc[0] - 1 - 1, tempLoc[1] - 1 - 1] == playerID)
                                {
                                    chessNumber[3]++;
                                }
                                else { break; }
                            }
                            if (chessNumber[3] >= 5)
                            {
                                gameOverDate[0] = tempLoc[0];
                                gameOverDate[1] = tempLoc[1];
                                gameOverDate[2] = 7;
                                gameOverDate[3] = playerID;
                                goto gameOver;
                            }
                        }
                        #endregion
                        switch (playerID)
                        {
                            case 1:
                                ConsoleWrite.ConsoleLocWrite("O", 2 + locationInt[0] * 2 - 1, locationInt[1], ConsoleColor.White, ConsoleColor.Blue, false);

                                ConsoleWrite.ConsoleLocWrite("O", 1 + 2 * (15 + 2) + 1, 0, ConsoleColor.White, ConsoleColor.Blue, false);
                                ConsoleWrite.ConsoleLocWrite("方已出棋：(" + locationString[0] + "," + locationString[1] + ")     ", 1 + 2 * (15 + 2) + 1 + 1, 0, ConsoleWrite.defBack, ConsoleWrite.defFore, false);
                                break;
                            case 2:
                                ConsoleWrite.ConsoleLocWrite("X", 2 + locationInt[0] * 2 - 1, locationInt[1], ConsoleColor.White, ConsoleColor.Red, false);

                                ConsoleWrite.ConsoleLocWrite("X", 1 + 2 * (15 + 2) + 1, 0, ConsoleColor.White, ConsoleColor.Red, false);
                                ConsoleWrite.ConsoleLocWrite("方已出棋：(" + locationString[0] + "," + locationString[1] + ")     ", 1 + 2 * (15 + 2) + 1 + 1, 0, ConsoleWrite.defBack, ConsoleWrite.defFore, false);
                                break;
                        }
                    }
                    else
                    {
                        againString = "locationNotNull";
                        goto again;
                    }
                }
                else
                {
                    againString = "locationError";
                    goto again;
                }
            again:;
                if (againString != "")
                {
                    switch (againString)
                    {
                        case "locationError":
                            ConsoleWrite.ConsoleLocWrite("棋盘坐标错误，请重新输入", 1 + 2 * (15 + 2) + 1, 2, ConsoleWrite.defBack, ConsoleColor.DarkRed, false);
                            break;
                        case "locationNotNull":
                            ConsoleWrite.ConsoleLocWrite("棋盘坐标中已经存在棋子，请重新输入", 1 + 2 * (15 + 2) + 1, 2, ConsoleWrite.defBack, ConsoleColor.DarkRed, false);
                            break;
                    }
                    againString = "";
                }
                else
                {
                    switch (playerID)
                    {
                        case 1:
                            playerID = 2; break;
                        case 2:
                            playerID = 1; break;
                    }
                    ConsoleWrite.ConsoleLocWrite("                                        ", 1 + 2 * (15 + 2) + 1, 2, ConsoleWrite.defBack, ConsoleWrite.defFore, false);
                }
            }
        gameOver:;
            //编号对应朝向为下文
            //789 7左上；8上；9右上
            //4 6 4左；6右
            //123 1左下；2下；3右下
            if (gameOverDate != new int[4])
            {
                #region 绘制胜利棋子
                int[] tempLoc;
                if (gameOverDate[0] - 1 - 1 >= 1 - 1 &&
                    locationStatus[gameOverDate[0] - 1 - 1, gameOverDate[1] - 1] == playerID)//向左延伸
                {
                    if (gameOverDate[2] == 4 || gameOverDate[2] == 6)
                    {
                        tempLoc = new int[2] { gameOverDate[0], gameOverDate[1] };
                        for (int i = 0; i < 5; i++, tempLoc[0]--)
                        {
                            if (tempLoc[0] - 1 - 1 >= 1 - 1 &&
                                                        locationStatus[tempLoc[0] - 1, tempLoc[1] - 1] == playerID)//判断是否还有该方的棋子
                            {
                                switch (gameOverDate[3])
                                {
                                    case 1:
                                        ConsoleWrite.ConsoleLocWrite("O", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Blue, false); break;
                                    case 2:
                                        ConsoleWrite.ConsoleLocWrite("X", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Red, false); break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                if (gameOverDate[0] - 1 - 1 >= 1 - 1 && gameOverDate[1] - 1 + 1 <= 15 - 1 &&
                    locationStatus[gameOverDate[0] - 1 - 1, gameOverDate[1] - 1 + 1] == playerID)//向左下延伸
                {
                    if (gameOverDate[2] == 1 || gameOverDate[2] == 9)
                    {
                        tempLoc = new int[2] { gameOverDate[0], gameOverDate[1] };
                        for (int i = 0; i < 5; i++, tempLoc[0]--, tempLoc[1]++)
                        {
                            if (tempLoc[0] - 1 - 1 >= 1 - 1 && tempLoc[1] - 1 + 1 <= 15 - 1 &&
                        locationStatus[tempLoc[0] - 1, tempLoc[1] - 1] == playerID)
                            {
                                switch (gameOverDate[3])
                                {
                                    case 1:
                                        ConsoleWrite.ConsoleLocWrite("O", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Blue, false); break;
                                    case 2:
                                        ConsoleWrite.ConsoleLocWrite("X", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Red, false); break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                if (gameOverDate[1] - 1 + 1 <= 15 - 1 &&
                    locationStatus[gameOverDate[0] - 1, gameOverDate[1] - 1 + 1] == playerID) //向下延伸
                {
                    if (gameOverDate[2] == 2 || gameOverDate[2] == 8)
                    {
                        tempLoc = new int[2] { gameOverDate[0], gameOverDate[1] };
                        for (int i = 0; i < 5; i++, tempLoc[1]++)
                        {
                            if (tempLoc[1] - 1 + 1 <= 15 - 1 &&
                        locationStatus[tempLoc[0] - 1, tempLoc[1] - 1] == playerID)
                            {
                                switch (gameOverDate[3])
                                {
                                    case 1:
                                        ConsoleWrite.ConsoleLocWrite("O", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Blue, false); break;
                                    case 2:
                                        ConsoleWrite.ConsoleLocWrite("X", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Red, false); break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                if (gameOverDate[0] - 1 + 1 <= 15 - 1 && gameOverDate[1] - 1 + 1 <= 15 - 1 &&
                    locationStatus[gameOverDate[0] - 1 + 1, gameOverDate[1] - 1 + 1] == playerID) //向右下延伸
                {
                    if (gameOverDate[2] == 3 || gameOverDate[2] == 7)
                    {
                        tempLoc = new int[2] { gameOverDate[0], gameOverDate[1] };
                        for (int i = 0; i < 5; i++, tempLoc[0]++, tempLoc[1]++)
                        {
                            if (tempLoc[0] - 1 + 1 <= 15 - 1 && tempLoc[1] - 1 + 1 <= 15 - 1 &&
                       locationStatus[tempLoc[0] - 1, tempLoc[1] - 1] == playerID)
                            {
                                switch (gameOverDate[3])
                                {
                                    case 1:
                                        ConsoleWrite.ConsoleLocWrite("O", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Blue, false); break;
                                    case 2:
                                        ConsoleWrite.ConsoleLocWrite("X", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Red, false); break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                if (gameOverDate[0] - 1 + 1 <= 15 - 1 &&
                    locationStatus[gameOverDate[0] - 1 + 1, gameOverDate[1] - 1] == playerID) //向右延伸
                {
                    if (gameOverDate[2] == 6 || gameOverDate[2] == 4)
                    {
                        tempLoc = new int[2] { gameOverDate[0], gameOverDate[1] };
                        for (int i = 0; i < 5; i++, tempLoc[0]++)
                        {
                            if (tempLoc[0] - 1 + 1 <= 15 - 1 &&
                        locationStatus[tempLoc[0] - 1, tempLoc[1] - 1] == playerID)
                            {
                                switch (gameOverDate[3])
                                {
                                    case 1:
                                        ConsoleWrite.ConsoleLocWrite("O", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Blue, false); break;
                                    case 2:
                                        ConsoleWrite.ConsoleLocWrite("X", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Red, false); break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                if (gameOverDate[0] - 1 + 1 <= 15 - 1 && gameOverDate[1] - 1 - 1 >= 1 - 1 &&
                    locationStatus[gameOverDate[0] - 1 + 1, gameOverDate[1] - 1 - 1] == playerID) //向右上延伸
                {
                    if (gameOverDate[2] == 9 || gameOverDate[2] == 1)
                    {
                        tempLoc = new int[2] { gameOverDate[0], gameOverDate[1] };
                        for (int i = 0; i < 5; i++, tempLoc[0]++, tempLoc[1]--)
                        {
                            if (tempLoc[0] - 1 + 1 <= 15 - 1 && tempLoc[1] - 1 - 1 >= 1 - 1 &&
                        locationStatus[tempLoc[0] - 1, tempLoc[1] - 1] == playerID)
                            {
                                switch (gameOverDate[3])
                                {
                                    case 1:
                                        ConsoleWrite.ConsoleLocWrite("O", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Blue, false); break;
                                    case 2:
                                        ConsoleWrite.ConsoleLocWrite("X", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Red, false); break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                if (gameOverDate[1] - 1 - 1 >= 1 - 1 &&
                    locationStatus[gameOverDate[0] - 1, gameOverDate[1] - 1 - 1] == playerID) //向上延伸
                {
                    if (gameOverDate[2] == 8 || gameOverDate[2] == 2)
                    {
                        tempLoc = new int[2] { gameOverDate[0], gameOverDate[1] };
                        for (int i = 0; i < 5; i++, tempLoc[1]--)
                        {
                            if (tempLoc[1] - 1 - 1 >= 1 - 1 &&
                        locationStatus[tempLoc[0] - 1, tempLoc[1] - 1] == playerID)
                            {
                                switch (gameOverDate[3])
                                {
                                    case 1:
                                        ConsoleWrite.ConsoleLocWrite("O", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Blue, false); break;
                                    case 2:
                                        ConsoleWrite.ConsoleLocWrite("X", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Red, false); break;
                                }
                            }
                            else { break; }
                        }
                    }
                }
                if (gameOverDate[0] - 1 - 1 >= 1 - 1 && gameOverDate[1] - 1 - 1 >= 1 - 1 &&
                    locationStatus[gameOverDate[0] - 1 - 1, gameOverDate[1] - 1 - 1] == playerID) //向左上延伸
                {
                    if (gameOverDate[2] == 7 || gameOverDate[2] == 3)
                    {
                        tempLoc = new int[2] { gameOverDate[0], gameOverDate[1] };
                        for (int i = 0; i < 5; i++, tempLoc[0]--, tempLoc[1]--)
                        {
                            if (tempLoc[0] - 1 - 1 >= 1 - 1 && tempLoc[1] - 1 - 1 >= 1 - 1 &&
                        locationStatus[tempLoc[0] - 1, tempLoc[1] - 1] == playerID)
                            {
                                switch (gameOverDate[3])
                                {
                                    case 1:
                                        ConsoleWrite.ConsoleLocWrite("O", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Blue, false); break;
                                    case 2:
                                        ConsoleWrite.ConsoleLocWrite("X", 2 + tempLoc[0] * 2 - 1, tempLoc[1], ConsoleColor.Green, ConsoleColor.Red, false); break;
                                }
                            }
                            else { break; }
                        }
                    }
                }
                #endregion
                ConsoleWrite.ConsoleLocWrite("游戏结束！", 1 + 2 * (15 + 2) + 1, 3, ConsoleWrite.defBack, ConsoleWrite.defFore, true);
                switch (gameOverDate[3])
                {
                    case 1:
                        ConsoleWrite.ConsoleLocWrite("O", 1 + 2 * (15 + 2) + 1, 4, ConsoleColor.White, ConsoleColor.Blue, false); break;
                    case 2:
                        ConsoleWrite.ConsoleLocWrite("X", 1 + 2 * (15 + 2) + 1, 4, ConsoleColor.White, ConsoleColor.Red, false); break;
                }
                ConsoleWrite.ConsoleLocWrite("方胜利", 1 + 2 * (15 + 2) + 1 + 1, 4, ConsoleWrite.defBack, ConsoleWrite.defFore, true);

                ConsoleWrite.setCursor(0, 17);
            }
        }

        static class ConsoleWrite
        {
            static private int consTop;
            static private int consLeft;
            static public System.ConsoleColor defBack;
            static public System.ConsoleColor defFore;


            static public void ConsoleLocWrite(string str, int x, int y, System.ConsoleColor back, System.ConsoleColor fore, bool writeLine)
            {
                if (x != -1 && y != -1)
                {
                    Console.SetCursorPosition(consLeft + x, consTop + y);
                }
                Console.BackgroundColor = back;
                Console.ForegroundColor = fore;
                if (writeLine)
                {
                    Console.WriteLine(str);
                }
                else
                {
                    Console.Write(str);
                }
                Console.BackgroundColor = defBack;
                Console.ForegroundColor = defFore;
            }
            static public void setCursor(int x, int y)
            {
                Console.SetCursorPosition(consLeft + x, consTop + y);
            }
            static public void def()//初始化
            {
                Console.Clear();
                consTop = Console.CursorTop;
                consLeft = Console.CursorLeft;
                defBack = Console.BackgroundColor;
                defFore = Console.ForegroundColor;
            }
        }
    }
}

