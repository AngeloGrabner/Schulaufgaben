namespace Program
{
    public struct DupeAndCount
    {
        public string name = "";
        public int num = -1;
        public int count = 1;
    }
    public static class HandleDupes
    {
        public static List<DupeAndCount> allDupes = new();

        public static int getDupesOf(string value, bool isNumber)
        {
            if (isNumber)
            {
                for (int i = 0; i < allDupes.Count; i++)
                {
                    if (allDupes[i].num == int.Parse(value))
                    {
                        return allDupes[i].count;
                    }
                }
                return -1;
            }
            else
            {
                for (int i = 0; i < allDupes.Count; i++)
                {
                    if (allDupes[i].name == value)
                    {
                        return allDupes[i].count;
                    }
                }
                return -1;
            }
            
        }
        public static void add(string value, bool isNumber)
        {
            if (isNumber)
            {
                for (int i = 0; i < allDupes.Count; i++)
                {
                    if (allDupes[i].num == int.Parse(value))
                    {
                        DupeAndCount temp = allDupes[i];
                        temp.count++;
                        allDupes[i] = temp;
                        return;
                    }
                }
                DupeAndCount temp2 = new();
                temp2.name = value;
                allDupes.Add(temp2);
            }
            else
            {
                for (int i = 0; i < allDupes.Count; i++)
                {
                    if (allDupes[i].name == value)
                    {
                        DupeAndCount temp = allDupes[i];
                        temp.count++;
                        allDupes[i] = temp;
                        return;
                    }
                }
                DupeAndCount temp2 = new();
                temp2.name = value;
                allDupes.Add(temp2);
            }
        }
    }
}
