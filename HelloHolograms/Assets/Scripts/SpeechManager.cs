using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
	KeywordRecognizer keywordRecognizer = null;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

	// Use this for initialization
	void Start()
	{
        string[][] words =
        {
            new string[ ] {"Add one", "Cube1"},
            new string[ ] {"Add two", "Cube2"},
            new string[ ] {"Add three", "Cube3"} 
        
        };

	    foreach (var w in  words)
	    {
            keywords.Add(w[0], () =>
            {
                var direction = Camera.main.transform.forward;

                var origin = Camera.main.transform.position;

                var position = origin + direction * 2.0f;

                Instantiate(Resources.Load(w[1]), position, Quaternion.identity);

            });
        }

        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

		// Register a callback for the KeywordRecognizer and start recognizing!
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start();
	}

	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;
		if (keywords.TryGetValue(args.text, out keywordAction))
		{
			keywordAction.Invoke();
		}
	}
}