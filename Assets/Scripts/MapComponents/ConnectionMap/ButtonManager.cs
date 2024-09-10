using System;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public ChangeScene changeScene;
    public TMP_InputField mapCode;
    public TextMeshProUGUI text;

    private readonly string baseUrl = "http://10.101.0.39:8080/api/v1/session/code";

    public async void OnClick()
    {
        string url = $"{baseUrl}/{mapCode.text}";

        Debug.Log($"Requesting URL: {url}");

        try
        {
            
            string jsonString = await FetchMapData(url);

           
            Debug.Log(jsonString);
            MapLoader.mapFile = jsonString;

            
            changeScene.scene_changer("SampleScene");
        }
        catch (HttpRequestException httpEx)
        {
            HandleException("HTTP Request Error", httpEx);
        }
        catch (TaskCanceledException taskEx)
        {
            HandleException("Request Timeout", taskEx);
        }
        catch (Exception ex)
        {
            HandleException("General Error", ex);
        }
    }

    private async Task<string> FetchMapData(string url)
    {
        using (HttpClient httpClient = new HttpClient())
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }

    private void HandleException(string message, Exception ex)
    {
        MapLoader.Warn = true;
        if (text != null)
        {
            text.gameObject.SetActive(true);
        }
        Debug.LogError($"{message}: {ex.Message}");
    }

    public void Quit()
    {
        changeScene.quit();
    }
}
