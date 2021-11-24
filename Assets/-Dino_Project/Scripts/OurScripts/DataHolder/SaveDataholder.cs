using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveDataholder : MonoBehaviour
{
    private DataHolder dataHolder;
    void Start()
    {
        dataHolder = GameObject.FindGameObjectWithTag("DataHolder").GetComponent<DataHolder>();
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string savePath = Application.persistentDataPath + "/FitnessPunch.fit";
        FileStream fileStream = new FileStream(savePath, FileMode.Create);
        binaryFormatter.Serialize(fileStream, dataHolder);
        fileStream.Close();
    }
}
