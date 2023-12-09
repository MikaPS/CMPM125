using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int totalScenes = 2; // start counting from 0
    // Moves to next scene
    public void NextScene() {
        if (SceneManager.GetActiveScene().buildIndex < totalScenes) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // Crafting.craftingManager.openWindow();
            // Crafting.craftingManager.closeWindow();
        } else {
            LevelSelect();
        }
    }
    // Goes back a scene
    public void PrevScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    // Restarts the scene
    public void RestartScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Returns to level select screen
    public void LevelSelect() {
        SceneManager.LoadScene(0);
    }

    // Moves to level 1
    public void Level1() {
        SceneManager.LoadScene(1);
    }
    // Moves to level 2
    public void Level2() {
        SceneManager.LoadScene(2);
    }

    public void playScenes() {
        if (SceneManager.GetActiveScene().buildIndex == 1) {
            NextScene();
        } else if (SceneManager.GetActiveScene().buildIndex == 2) {
            PrevScene();
        }
    }
}
