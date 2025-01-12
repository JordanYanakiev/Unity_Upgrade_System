using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoTOUpgradesScreen : MonoBehaviour
{
    [SerializeField] private Button goToUpgradesScene;

    // Start is called before the first frame update
    void Start()
    {
        goToUpgradesScene.onClick.AddListener(GoToUpgradesScene);
    }

    private void GoToUpgradesScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
