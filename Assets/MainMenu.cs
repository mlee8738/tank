using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace Tanks
{
    public class MainMenu : MonoBehaviourPunCallbacks
    {
        public static MainMenu instance;
        private GameObject m_ui;
        private TMP_InputField m_accountInput; // 新增 輸入匡
        private Button m_loginButton;
        private Button m_joinGameButton;
        void Awake()
        {
            if (instance != null)
            {
                DestroyImmediate(gameObject);
                return;
            }
            Debug.Log(transform);
            instance = this;

            m_ui = transform.FindAnyChild<Transform>("UI").gameObject;
            m_accountInput = transform.FindAnyChild<TMP_InputField>("AccountInput");
            m_loginButton = transform.FindAnyChild<Button>("LoginButton"); 
            m_joinGameButton = transform.FindAnyChild<Button>("JoinGameButton");
            ResetUI();
        }
        private void ResetUI() // 重置 UI
        {
            m_ui.SetActive(true);
            m_accountInput.gameObject.SetActive(true);
            m_loginButton.gameObject.SetActive(true);
            m_joinGameButton.gameObject.SetActive(false);
            m_accountInput.interactable = true;
            m_loginButton.interactable = true;
            m_joinGameButton.interactable = true;
        }
        public void Login() // 處理 登入伺服器流程
        {
            if (string.IsNullOrEmpty(m_accountInput.text))
            {
                Debug.Log("Please input your account!!");
                return;
            }

            
            m_accountInput.interactable = false;
            m_loginButton.interactable = false;
            m_joinGameButton.gameObject.SetActive(true);
            if (!GameManager.instance.ConnectToServer(m_accountInput.text))
            {
                Debug.Log("Connect to PUN Failed!!");
                m_accountInput.interactable = true;
                m_loginButton.interactable = true;                
            }
        }

        public override void OnConnectedToMaster()
        {
            m_joinGameButton.interactable = true;
        }
        public override void OnEnable()
        {
            // Always call the base to add callbacks
            base.OnEnable();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        public override void OnDisable()
        {
            // Always call the base to remove callbacks
            base.OnDisable();
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            m_ui.SetActive(!PhotonNetwork.InRoom);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
