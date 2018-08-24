using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LauncherScript : Photon.PunBehaviour
{
   //Private変数の定義はココで
    string _gameVersion = "Chapter12";   //ゲームのバージョン。仕様が異なるバージョンとなったときはバージョンを変更しないとエラーが発生する。
   //ログインボタンを押したときに実行される
    public void Connect()
    {
        if (!PhotonNetwork.connected)
        {                         //Photonに接続できていなければ
            PhotonNetwork.ConnectUsingSettings(_gameVersion);   //Photonに接続する
            Debug.Log("Photonに接続しました。");
            SceneManager.LoadScene("Lobby");    //Lobbyシーンに遷移
        }
    }
}