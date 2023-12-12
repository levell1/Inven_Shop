
public class GoldManager
{
    public string AbbreviateGold(int goldAmount)
    {
        if (goldAmount >= 1000)
        {
            string gold = string.Empty;
            float value = goldAmount;

            if (goldAmount >= 1000 && goldAmount < 1000000)
            {
                value = goldAmount / 1000f;
                gold = "K";
            }

            string sum = value.ToString() + gold;
            return sum;
        }
        return goldAmount.ToString();
    }
}
