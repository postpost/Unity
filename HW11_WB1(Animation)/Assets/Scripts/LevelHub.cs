using NUnit.Framework;
using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHub : MonoBehaviour
{
    private GameObject _currentCanvas;

    private void Start()
    {
        _currentCanvas = this.gameObject;
    }

    public void OpenLevel(int index)
    {
          SceneManager.LoadScene(index);
    }

    //public void OpenLevelMenu(GameObject canvas)
    //{
    //    _currentCanvas = this.gameObject;
    //    if(_currentCanvas != canvas)
    //    {
    //        canvas.SetActive(true);
    //        gameObject.SetActive(false);
    //        _currentCanvas = canvas;
    //    }
    //}

    //public void SetBackToPlayMenu(GameObject canvasOn)
    //{
    //    _currentCanvas = this.gameObject;
    //    if(_currentCanvas != canvasOn)
    //    {
    //        _currentCanvas.SetActive(false);
    //        _currentCanvas = canvasOn;
    //        canvasOn.SetActive(true);
    //    }
    //}

    public void OnPauseClicked(GameObject pauseCanvas)
    {
        Pause();
        SetCanvas(pauseCanvas);
    }

    public void OnRestartClicked()
    {
        Unpause();
        SetCanvas(this.gameObject);
    }

    private void SetCanvas(GameObject canvas)
    {
        _currentCanvas.SetActive(false);
        _currentCanvas = canvas;
        _currentCanvas.SetActive(true);
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }

    private void Unpause()
    {
        Time.timeScale = 1.0f;
    }
}
