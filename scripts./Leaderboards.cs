using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboards : MonoBehaviour
{
    public Transform entryContainer;
    public Transform entryTemplate;
    public List<HighscoreEntry> highscoreEntryList;
    public List<Transform> highscoreEntryTransformList;

    public void Awake()
    {
        AddHighscoreEntry(0);
        
        entryContainer = GameObject.Find("EntryContainer").transform;
        entryTemplate = entryContainer.Find("EntryTemplate");
        
        entryTemplate.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("highscoreTable1");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        if (highscores == null) { 


            // There's no stored table, initialize
            AddHighscoreEntry(0);
            AddHighscoreEntry(0);
            AddHighscoreEntry(0);
            AddHighscoreEntry(0);
            AddHighscoreEntry(0);
            AddHighscoreEntry(0);
            AddHighscoreEntry(0);
            AddHighscoreEntry(0);
            AddHighscoreEntry(0);
            AddHighscoreEntry(0);
            // Reload
            jsonString = PlayerPrefs.GetString("highscoreTable1");
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        
        if (highscores.highscoreEntryList.Count > 10)
            {
            for (int h = highscores.highscoreEntryList.Count; h>10; h--)
                {
                highscores.highscoreEntryList.RemoveAt(10);
            }
        }
        
        

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    public void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList){
        float templateHeight = 32f;
        Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);
        

            int rank = transformList.Count+1;
            string rankString;
            switch (rank) {
                default: 
                    rankString = rank + "TH"; break;

                case 1: rankString = "1ST"; break;
                case 2: rankString = "2ND"; break;
                case 3: rankString = "3RD"; break;

            }

            entryTransform.Find("EntryPos").GetComponent<Text>().text = rankString;

            int score = highscoreEntry.score;
            entryTransform.Find("EntryScore").GetComponent<Text>().text = score.ToString();

            transformList.Add(entryTransform);
    }

    public void AddHighscoreEntry(int score) {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score };
        
        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable1");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        
        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        
        if (highscores == null) {
            highscores = new Highscores() {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }
        

        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable1", json);
        PlayerPrefs.Save();
    }

    public class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }
    [System.Serializable] 
    public class HighscoreEntry {
        public int score;
        public string name;
    }
}
