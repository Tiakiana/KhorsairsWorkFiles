using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RestfulClientScr : MonoBehaviour
{
    private static RestfulClientScr _inst;

    public static RestfulClientScr Inst
    {
        get
        {
            if (_inst == null)
            {
                _inst = FindObjectOfType<RestfulClientScr>();
                if (_inst == null)
                {
                    GameObject go = new GameObject();
                    go.name = typeof(RestfulClientScr).Name;
                    _inst = go.AddComponent<RestfulClientScr>();
                    DontDestroyOnLoad(go);
                }
            }
            return _inst;
        }
    }

    public IEnumerator Get(string url, System.Action<PlayerList> callBack)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    Debug.Log(www.downloadHandler.text);
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    PlayerList playerList = new PlayerList();
                    string res = "{ \"players\": " + www.downloadHandler.text + "}";
                    JsonUtility.FromJsonOverwrite(res, playerList);
                    callBack(playerList);
                }
            }
        }

    }

    //public IEnumerator GetMoves(string url, System.Action<MoveList> callBack)
    //{
    //    using (UnityWebRequest www = UnityWebRequest.Get(url))
    //    {
    //        yield return www.SendWebRequest();
    //        if (www.isNetworkError)
    //        {
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            if (www.isDone)
    //            {
    //                Debug.Log(www.downloadHandler.text);
    //                string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
    //                MoveList movelist = new MoveList();
    //                string res = "{ \"moves\": " + www.downloadHandler.text + "}";
    //                JsonUtility.FromJsonOverwrite(res, movelist);
    //                callBack(movelist);
    //                // Debug.Log(jsonResult);
    //            }
    //        }
    //    }
    //}



    public IEnumerator Post(string url, PlayerInfo pos) {
        string jsonData = JsonUtility.ToJson(pos);
        using (UnityWebRequest www = UnityWebRequest.Post(url, jsonData)) {
            www.SetRequestHeader("content-type", "Application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    Debug.Log("Uploaded");
                }
            }
        }
    }
    public IEnumerator Put(string url, PlayerInfo pos)
    {
        string jsonData = JsonUtility.ToJson(pos);
        using (UnityWebRequest www = UnityWebRequest.Put(url, jsonData))
        {
            www.SetRequestHeader("content-type", "Application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    Debug.Log("Uploaded");
                }
            }
        }
    }


    public IEnumerator Post(string url, PostObject pos)
    {
        string jsonData = JsonUtility.ToJson(pos);
        using (UnityWebRequest www = UnityWebRequest.Post(url, jsonData))
        {
            www.SetRequestHeader("content-type", "Application/json");
            www.uploadHandler.contentType = "application/json";
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            yield return www.SendWebRequest();
            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    Debug.Log("Uploaded");
                }
            }
        }
    }



}
