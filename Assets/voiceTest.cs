using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;

public class voiceTest : MonoBehaviour
{
    public BiometricInputManager biometricInputManager;

    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;
    // Start is called before the first frame update
    void Start()
    {
        keywordActions.Add("yes", Yes);
        keywordActions.Add("Yes", Yes);
        keywordActions.Add("yeah", Yes);
        keywordActions.Add("Yeah", Yes);


        keywordActions.Add("no", No);
        keywordActions.Add("No", No);
        keywordActions.Add("now", No);
        keywordActions.Add("noe", No);


        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray(), ConfidenceLevel.Low);
        keywordRecognizer.OnPhraseRecognized += OnKeywordsRecognized;
        keywordRecognizer.Start();
    }
    private void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Keyword: " + args.text);
        keywordActions[args.text].Invoke();
    }


    private void Yes()
    {
        biometricInputManager.LieDetection();
        //Debug.Log("Yes");
    }
    private void No()
    {
        biometricInputManager.LieDetection();
        //Debug.Log("No");
    }
    


    // Update is called once per frame
    void Update()
    {
        
    }
}
