using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoObject : MonoBehaviour {

    [SerializeField]
    private float m_speed = 3.0f;
    [SerializeField]
    private float m_colorSpeed = 1.0f;

    private PhotonView m_photonView = null;
    private Renderer m_render = null;
    private Color m_color = Color.white;

    private readonly Color[] MATERIAL_COLORS = new Color[]
    {
        Color.white, Color.red, Color.green, Color.blue, Color.green,
    };

    void Awake()
    {
        m_photonView = GetComponent<PhotonView>();
        m_render = GetComponent<Renderer>();
    }

    void Start()
    {
        int ownerID = m_photonView.ownerId;
        m_color = MATERIAL_COLORS[ownerID];
    }

    void Update()
    {
        // 持ち主でないのなら制御させない.
        if (!m_photonView.isMine)
        {
            return;
        }
        /*
        Vector3 pos = transform.position;

        pos.x += Input.GetAxis("Horizontal") * m_speed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * m_speed * Time.deltaTime;

        transform.position = pos;
        */
        // マテリアルの青の成分のみを時間経過によって変化させる.
        m_color.b += m_colorSpeed * Time.deltaTime;
        m_color.b = Mathf.Repeat(m_color.b, 1.0f);
        m_render.material.color = m_color;
    }

    void OnPhotonSerializeView(PhotonStream i_stream, PhotonMessageInfo i_info)
    {
        if (i_stream.isWriting)
        {
            //データの送信
            i_stream.SendNext(m_color.r);
            i_stream.SendNext(m_color.g);
            i_stream.SendNext(m_color.b);
            i_stream.SendNext(m_color.a);
        }
        else
        {
            //データの受信
            float r = (float)i_stream.ReceiveNext();
            float g = (float)i_stream.ReceiveNext();
            float b = (float)i_stream.ReceiveNext();
            float a = (float)i_stream.ReceiveNext();
            m_color = new Color(r, g, b, a);
            m_render.material.color = m_color;
        }
    }
} // class DemoObject