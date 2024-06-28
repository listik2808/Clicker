using UnityEngine;

public static class SaveProgress
{
    public static void SaveProgressInt(string kay,int count)
    {
        PlayerPrefs.SetInt(kay, count);
    }

    public static int LoadInt(string kay)
    {
        if (PlayerPrefs.HasKey(kay))
            return PlayerPrefs.GetInt(kay);
        else
            return 0;
    }

    public static void SaveProgressProduct(int index,int result)
    {

        PlayerPrefs.SetInt(index.ToString(), result);
    }

    public static int LoadIntProduct(int index)
    {
        if (PlayerPrefs.HasKey(index.ToString()))
            return PlayerPrefs.GetInt(index.ToString());
        else
            return 0;
    }

    public static void DeletSaveProgress()
    {
        PlayerPrefs.DeleteAll();
    }
}
