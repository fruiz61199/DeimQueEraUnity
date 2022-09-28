using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public bool gameOver;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject lossCanvas;
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameObject startMessageCanvas;
    [SerializeField] private GameObject arosContadorCanvas;
    [SerializeField] public TMP_Text startMessageTextTMP;
    [SerializeField] private TMP_Text arosCountTextTMP;
    public int aros;
    public bool canvasActivo = false;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ActivarStartCanvas();
        aros = 0;
    }

    public void ActivarStartCanvas()
    {
        startCanvas.SetActive(true);
        canvasActivo = true;
    }
    public void QuitarStartCanvas()
    {
        startCanvas.SetActive(false);
        canvasActivo = false;
        ActivarCanvasContador();
        ActivarMensajeInicial();
        Invoke("DesactivarMensajeInicial", 3f);
    }

    public void ActivarMensajeInicial()
    {
        startMessageCanvas.SetActive(true);
    }

    public void DesactivarMensajeInicial()
    {
        startMessageCanvas.SetActive(false);
    }
    public void ActivarCanvasContador()
    {
        arosContadorCanvas.SetActive(true);
        ArosCountText();
    }
    public void DesactivarCanvasContador()
    {
        arosContadorCanvas.SetActive(false);        
    }
    public void ArosCountText()
     {
         arosCountTextTMP.text = Convert.ToString(aros) + " / 25";
     }
    

    public void ChangeArosCount()
    {
        aros++;
        ArosCountText();
        CheckArosCount();
    }

    public void CheckArosCount()
    {
        if (aros == 25)
        {
            GameWon();
        }
    }
    public void GameWon()
    {
        winCanvas.SetActive(true);
        DesactivarCanvasContador();
        canvasActivo = true;
    }

    public void GameLoss()
    {
        lossCanvas.SetActive(true);
        DesactivarCanvasContador();
        canvasActivo = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        canvasActivo = false;
    }


    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Has salido del juego.");
    }
}