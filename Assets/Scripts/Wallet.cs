using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _money = 0;

    public void AddMoney(int value)
    {
        if (value <= 0)
            return;

        _money += value;
    }
}