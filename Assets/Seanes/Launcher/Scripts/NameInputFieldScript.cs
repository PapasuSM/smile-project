using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class NameInputFieldScript : Photon.PunBehaviour
{
    static string playerNamePrefKey = "PlayerName";
    InputField _inputField;
    
    void Start()
    {
        string defaultName = "";
        _inputField = this.GetComponent<InputField>();

        //前回プレイ開始時に入力した名前をロードして表示
        if (_inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }
    }
    
    public void SetPlayerName(string value)
    {
        string inputvalue = _inputField.text;
        Debug.Log(inputvalue);

        
        /*
        string playerName = value + " ";     //今回ゲームで利用するプレイヤーの名前を設定

        PlayerPrefs.SetString(playerNamePrefKey, value);    //今回の名前をセーブ

        Debug.Log(playerNamePrefKey);   //playerの名前の確認。（動作が確認できればこの行は消してもいい）
        print(value);
        */
        
    }
}