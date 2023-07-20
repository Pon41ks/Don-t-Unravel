using UnityEngine.Events;

public static class GlobalEventManager 
{
    public static readonly UnityEvent OnCoinCollected = new();
    public static readonly UnityEvent<int> OnScoreAdded = new();
    public static readonly UnityEvent OnPlayerDied = new();
    public static readonly UnityEvent OnShopUpdated = new();
    public static void SendCoinCollected()
    {
        OnCoinCollected.Invoke();
    }
    public static void AddScore(int value)
    {
        OnScoreAdded.Invoke(value);
    }
    public static void SendPlayerDied()
    {
        OnPlayerDied.Invoke();
    }
    public static void SendUpdateShop()
    {
        OnShopUpdated.Invoke();
    }
}