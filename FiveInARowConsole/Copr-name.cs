class Copyright
{
    public string GetC()
    {
        int[] dateInt=new int[2]{2023,2024};
        string date;
        string owner="谢宏铭,";

        if (dateInt[0]!=dateInt[1])
            date=dateInt[0].ToString()+ "-" +dateInt[1].ToString();
        else
            date=dateInt[0].ToString();
        return "Copyright (C) " + date + " " + owner + " All rights reserved.";
    }
}
//FiveInARowConsole
//name
